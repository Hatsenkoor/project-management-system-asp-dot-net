
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
                source: new ol.source.OSM(),
            })
        ],
        view: new ol.View({
            center: ol.proj.fromLonLat([56.6717082,23.2231416]),
            projection:'EPSG:3857',
            zoom: 8
        })
    });

    marker_source=new ol.source.Vector({});
    marker_layer=new ol.layer.Vector({
        name:"marker",
        source:marker_source,
        style:new ol.style.Style({
            image: new ol.style.Icon(/** @type {olx.style.IconOptions} */ ({
                //anchor: [0.5, -1.5],
                anchorXUnits: 'fraction',
                anchorYUnits: 'pixels',
                opacity: 0.75,
                src: '../../images/ic_map_marker.png'
            }))
        })

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
        url: "http://localhost:55181/js/gis/request/gs_unique.xml",
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
        url: "http://localhost:55181/js/gis/request/gs_query.xml",
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
                    marker_source.addFeature(marker_feature);

                },
                error : function (xhr, ajaxOptions, thrownError){

                }
            });


        }
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


