
var map;
var marker_source;
var marker_layer;

$(document).ready(function () {

    proj4.defs("EPSG:23240","+proj=utm +zone=40 +ellps=clrk80 +towgs84=-346,-1,224,0,0,0,0 +units=m +no_defs");
    ol.proj.proj4.register(proj4);

    map = new ol.Map({

        target: 'map',
        layers: [
            new ol.layer.Tile({
                source: new ol.source.XYZ({
                    url: 'http://mt0.google.com/vt/lyrs=s&hl=en&x={x}&y={y}&z={z}'
                })
            })
        ],
        view: new ol.View({
            center: ol.proj.fromLonLat([56.6717082,23.2231416]),
            projection:'EPSG:3857',
            zoom: 8
        })
    });

    marker_source=new ol.source.Vector({});

    var labelStyle = new ol.style.Style({
        text: new ol.style.Text({
            font: '14px Calibri,sans-serif',
            overflow: true,
            fill: new ol.style.Fill({
                color: '#000',
            }),
            offsetY: 30,
            stroke: new ol.style.Stroke({
                color: '#fff',
                width: 3,
            }),
        }),
    });
    var markerStyle =new ol.style.Style({
        image: new ol.style.Icon(/** @type {olx.style.IconOptions} */ ({
            //anchor: [0.5, -1.5],
            anchorXUnits: 'fraction',
            anchorYUnits: 'pixels',
            opacity: 0.75,
            src: 'images/ic_map_marker.png'
        }))
    });
    var style = [markerStyle, labelStyle];



    marker_layer=new ol.layer.Vector({
        name:"marker",
        source:marker_source,
        style:function (feature) {
            labelStyle.getText().setText(feature.get('name'));
            return style;
        },

    });
    map.addLayer(marker_layer);

    map.on('singleclick', function (event) {
        map.forEachFeatureAtPixel(event.pixel, function(feature,layer) {
               var property=feature.getProperties()['extent'];
            location.replace(RootPath() + "/gis/buffer?extent=" + property);   
            },
            {
                layerFilter: function (layer) {
                    return true;
                }
            }
        );
    });
    map.on("pointermove", function (evt) {
        var hit = this.forEachFeatureAtPixel(evt.pixel, function(feature, layer) {
            return true;
        });
        if (hit) {
            this.getTargetElement().style.cursor = 'pointer';
        } else {
            this.getTargetElement().style.cursor = '';
        }
    });
    proccessRequest();

});
var gs_query;
var gs_unique;

function proccessRequest() {

    $.ajax({
        url : "./request/gs_unique.xml",
        type: "GET",
        success: function(data, textStatus, jqXHR)
        {
            //data - response from server
            gs_unique=xmlToString(data);

            uniqueQuery(gs_unique);


        },
        error: function (jqXHR, textStatus, errorThrown)
        {

        }
    });

    $.ajax({
        url : "./request/gs_query.xml",
        type: "GET",
        success: function(data, textStatus, jqXHR)
        {
            //data - response from server
            gs_query=xmlToString(data);

        },
        error: function (jqXHR, textStatus, errorThrown)
        {

        }
    });
    function uniqueQuery(gs_unique){
        $.ajax({
            url: 'http://localhost:8080/geoserver/wps',
            data: gs_unique,
            type: 'POST',
            contentType: "text/xml",
            dataType: "text",
            success: function(data, textStatus, jqXHR)
            {

                var features=new ol.format.GeoJSON().readFeatures(data,{'dataProjection':"EPSG:23240",'featureProjection':"EPSG:3857"});
                featureQuery(features);

            },
            error : function (xhr, ajaxOptions, thrownError){
                console.log(xhr.status);
                console.log(thrownError);
            }
        });

    }
    function featureQuery(features){


        for(var i=0;i<features.length;i++) {
            var f=features[i];
            var properties=f.getProperties();
            var property=properties['value'];
            var query='estate_serial = '+property;
            var sendXML=gs_query.replace("CQL_FILTER",query);
            $.ajax({
                url: 'http://localhost:8080/geoserver/wps',
                data: sendXML,
                type: 'POST',
                contentType: "text/xml",
                dataType: "text",
                success: function(data, textStatus, jqXHR)
                {

                    var fs=new ol.format.GeoJSON().readFeatures(data,{'dataProjection':"EPSG:23240",'featureProjection':"EPSG:3857"});
                    var fs_extent=ol.extent.createEmpty();
                    for(var i=0;i<fs.length;i++){
                        var feature=fs[i];
                        fs_extent=ol.extent.extend(fs_extent,feature.getGeometry().getExtent());
                    }

                   var  marker_feature=new ol.Feature({geometry:new ol.geom.Point([(fs_extent[0]+fs_extent[2])/2,(fs_extent[1]+fs_extent[3])/2]),value:property,extent:fs_extent.toString()});

                   intersectsQuery(marker_feature,fs_extent.toString());



                },
                error : function (xhr, ajaxOptions, thrownError){

                }
            });


        }
    }
    function intersectsQuery(marker_feature,extentString) {
        var extent=extentString.split(",");
        var coordinates=new Array();
        coordinates.push([Number(extent[0]),Number(extent[1])]);
        coordinates.push([Number(extent[2]),Number(extent[3])]);
        var extent=ol.extent.boundingExtent(coordinates);

        var geometry=ol.geom.Polygon.fromExtent(extent);
        var query=buildIntersectsFilter(geometry);
        console.log(query);

        fetch('http://localhost:8080/geoserver/wfs', {
            method: 'POST',
            body:   query,
        })
            .then(function (response) {
                return response.json();
            })
            .then(function (json) {
                var features =new  ol.format.GeoJSON().readFeatures(json,{'dataProjection':"EPSG:23240",'featureProjection':"EPSG:3857"});
                if(features.length>0) {
                    var feature=features[0];
                    var properties=feature.getProperties();
                    marker_feature.setProperties({name:properties['Name']});
                }
                else {
                    marker_feature.setProperties({name:''});
                }
                marker_source.addFeature(marker_feature);
            });


    }
    function buildIntersectsFilter(geometry){
        var reversedGeometry=geometry.clone().transform(map.getView().getProjection(),"EPSG:23240");
        //var reversedGeometry=reverseGeometry(convertedGeometry);

        var featureRequest = new ol.format.WFS().writeGetFeature({
            srsName: 'EPSG:23240',
            featureNS: 'test',
            featurePrefix: 'test',
            outputFormat: 'application/json',
            featureTypes: ['roads'],
            filter: new ol.format.filter.Intersects("Shape",reversedGeometry,"EPSG:23240")
        });

        var body=new XMLSerializer().serializeToString(featureRequest);
        return body;

    }



    function xmlToString(xmlData) {

        var xmlString;
        //IE
        if (window.ActiveXObject){
            xmlString = xmlData.xml;
        }
        // code for Mozilla, Firefox, Opera, etc.
        else{
            xmlString = (new XMLSerializer()).serializeToString(xmlData);
        }
        return xmlString;
    }


}


