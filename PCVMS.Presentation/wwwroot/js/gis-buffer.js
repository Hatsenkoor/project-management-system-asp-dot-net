
var map;
var building_source;
var road_source;
var buffer_source;
var result_source;
var parser;
var select_tool;

var building_layer;
var road_layer;
var buffer_layer;
var result_layer;

var container;
var content;
var closer;
var overlay;
var selectedFeatures=new Array();
var features_extent;

$(document).ready(function () {

    features_extent=getUrlParameter("extent");

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
    var extent=features_extent.split(",");
    var coordinates=new Array();
    coordinates.push([Number(extent[0]),Number(extent[1])]);
    coordinates.push([Number(extent[2]),Number(extent[3])]);

    map.getView().fit(ol.extent.boundingExtent(coordinates),map.getSize());

    select_tool=new  ol.interaction.Select({multi:true});
    map.addInteraction(select_tool);

    select_tool.on('select', function (e) {
        //selectedFeatures= e.target.getFeatures();
        var features=e.target.getFeatures().getArray();
        selectedFeatures=new Array();

        var remove_features=new Array();
        for(var i=0;i<features.length;i++) {
            var f=features[i];
            var layer = f.getLayer(map);
            if(layer.get("name") == 'road') {
                selectedFeatures.push(f);
            }
            else {
                remove_features.push(f);
            }
        }

        for(var i=0;i<remove_features.length;i++) {
            var f=remove_features[i];
            select_tool.getFeatures().remove(f);
         /*   var index = select_tool.getFeatures().getArray().indexOf(f);
            if (index > -1) {
                select_tool.getFeatures().getArray().splice(index, 1);
            }*/
        }

      /* if(selectedFeatures.length==0) {
            select_tool.getFeatures().clear();
        }
*/
    });

    ol.Feature.prototype.getLayer = function(map) {
        var this_ = this, layer_, layersToLookFor = [];
        /**
         * Populates array layersToLookFor with only
         * layers that have features
         */
        var check = function(layer){
            var source = layer.getSource();
            if(source instanceof ol.source.Vector){
                var features = source.getFeatures();
                if(features.length > 0){
                    layersToLookFor.push({
                        layer: layer,
                        features: features
                    });
                }
            }
        };
        //loop through map layers
        map.getLayers().forEach(function(layer){
            if (layer instanceof ol.layer.Group) {
                layer.getLayers().forEach(check);
            } else {
                check(layer);
            }
        });
        layersToLookFor.forEach(function(obj){
            var found = obj.features.some(function(feature){
                return this_ === feature;
            });
            if(found){
                //this is the layer we want
                layer_ = obj.layer;
            }
        });
        return layer_;
    };


    building_source = new ol.source.Vector({
         loader: function (extent, resolution, projection) {
            var url = "http://localhost:8080/geoserver/wfs?service=WFS"
         + "&version=2.0.0&request=GetFeature"
         + '&outputFormat=text/javascript'
         + "&typename=test:organization_layout"
         + "&format_options=callback:loadBuilding"
         + '&srsname=EPSG:23240&bbox='
         + features_extent
         +',EPSG:3857';
         $.ajax({url: url, dataType: 'jsonp', jsonp: false});
         },
        strategy: ol.loadingstrategy.bbox
    });
    road_source = new ol.source.Vector({
        loader: function (extent, resolution, projection) {
            var url = "http://localhost:8080/geoserver/wfs?service=WFS"
                + "&version=2.0.0&request=GetFeature"
                + '&outputFormat=text/javascript'
                + "&typename=test:roads"
                + "&format_options=callback:loadRoad"
                + '&srsname=EPSG:23240&bbox='
                +features_extent
                +',EPSG:3857';
            $.ajax({url: url, dataType: 'jsonp', jsonp: false});
        },
        strategy: ol.loadingstrategy.bbox
    });
    result_source = new ol.source.Vector({
        loader: function (extent, resolution, projection) {
            var url = "http://localhost:8080/geoserver/wfs?service=WFS"
                + "&version=2.0.0&request=GetFeature"
                + '&outputFormat=text/javascript'
                + "&typename=test:result"
                + "&format_options=callback:loadResult"
                + '&srsname=EPSG:4326&bbox='
                + features_extent
                +',EPSG:3857';
            $.ajax({url: url, dataType: 'jsonp', jsonp: false});
        },

    });


    window.loadBuilding = function (response) {
        building_source.clear();
        var features=new ol.format.GeoJSON().readFeatures(response,{'dataProjection':"EPSG:23240",'featureProjection':"EPSG:3857"});
        building_source.addFeatures(features);

    };

    window.loadRoad = function (response) {
        road_source.clear();
        var features=new ol.format.GeoJSON().readFeatures(response,{'dataProjection':"EPSG:23240",'featureProjection':"EPSG:3857"});
        road_source.addFeatures(features);

        //map.getView().fit(road_source.getExtent());
    };

    window.loadResult = function (response) {
        result_source.clear();
        var features=new ol.format.GeoJSON().readFeatures(response,{'dataProjection':"EPSG:4326",'featureProjection':"EPSG:3857"});
        result_source.addFeatures(features);

    };

    building_layer = new ol.layer.Vector({
        name:'parcel',
        source: building_source,
        style : new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'rgba(50,205,50, 1.0)',
                width: 2
            }),
            fill:  new ol.style.Fill({
                color: 'rgba(255,255,255,1)'
            })
        })
     });
    map.addLayer(building_layer);

    road_layer = new ol.layer.Vector({
        name:'road',
        source: road_source,
        style: new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'rgba(211,211,211, 1.0)',
                width: 2
            }),
            fill:  new ol.style.Fill({
                color: 'rgba(255,255,255,1)'
            })
        })
    });
    map.addLayer(road_layer);


    buffer_source =new ol.source.Vector({});
    buffer_layer=new ol.layer.Vector({
        name:'buffer',
        source:buffer_source,
        style : new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'rgba(254,192,64, 1.0)',
                width: 2
            }),
            fill:  new ol.style.Fill({
                color: 'rgba(255,255,255,0)'
            })
        })
    });
    map.addLayer(buffer_layer);

    //result_source =new ol.source.Vector({});
    result_layer=new ol.layer.Vector({
        name:'result',
        source:result_source,
        style: new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'rgba(255,0,0, 1.0)',
                width: 2
            }),
            fill:  new ol.style.Fill({
                color: 'rgba(255,255,255,0)'
            })
        })
    });
    map.addLayer(result_layer);



    parser = new jsts.io.OL3Parser();
    parser.inject(
        ol.geom.Point,
        ol.geom.LineString,
        ol.geom.LinearRing,
        ol.geom.Polygon,
        ol.geom.MultiPoint,
        ol.geom.MultiLineString,
        ol.geom.MultiPolygon
    );

    container = document.getElementById('popup');
    content = document.getElementById('popup-content');
    closer = document.getElementById('popup-closer');

    closer.onclick = function() {
        overlay.setPosition(undefined);
        closer.blur();
        return false;
    };

    overlay = new ol.Overlay({
        element: container,
        autoPan: true,
        autoPanAnimation: {
            duration: 250
        }
    });
    map.addOverlay(overlay);

    map.on('pointermove', function(evt) {
        if (evt.dragging) {
            return;
        }
        //var pixel = map.getEventPixel(evt.originalEvent);
       displayFeatureInfo(evt);
    });

   /* map.on('singleclick', function(evt) {
        displayFeatureInfo(evt);
    });*/

    $("#btn_apply").click(function () {
       var distance=$("#text_distance").val();
       proccess(distance);
    });
    $("#btn_save").click(function () {
        transactWFS('insert',result_source.getFeatures());
    })

});
var displayFeatureInfo = function(evt) {
    var features={};
    var pixel=evt.pixel;
    map.forEachFeatureAtPixel(pixel, function(feature,layer) {
        features[layer.get('name')]=feature;
    },
        {
            layerFilter: function (layer) {
                return true;
            }
        }
    );
   // console.log(features);
    content.innerHTML='';

    var keys=Object.keys(features);

    for(var i=0;i<keys.length;i++) {
        var key=keys[i];
        var feature=features[key];
        var properties=feature.getProperties();

        var contentHTML="";


        if(key=='road') {

            contentHTML+='<p>'+key+':'+properties.Name+'(name)</p>';
        }
        else if(key=='parcel') {
            contentHTML+='<p>'+key+':'+properties.location_type_code+'(type)</p>';
        }
        else if(key=='result') {
            contentHTML+='<p>'+key+':'+properties.percentage_of_area+'%(percent)</p>';
        }
        else if(key=='buffer') {

        }

        content.innerHTML+=contentHTML;
    }

    if(content.innerHTML=="") {
        overlay.setPosition(undefined);
        return;

    }

    overlay.setPosition(evt.coordinate);


};
function proccess(distance) {
    if(selectedFeatures.length==0) {
        alert("Please select features");
        return;

    }

   var features=selectedFeatures;
   buffer_source.clear();
   result_source.clear();
   for(var i=0;i<features.length;i++) {
       var feature=features[i];
       var buffer_polygon=buffer(feature,Number(distance));
       var f=new ol.Feature(buffer_polygon);
       buffer_source.addFeature(f);
       intersects(f,building_source);
   }
}
function buffer(feature,distance) {
  var geometry=feature.getGeometry();
  var jstsGeom = parser.read(geometry);
  var buffer_polygon = jstsGeom.buffer(distance);
  return parser.write(buffer_polygon);
}
function intersects(buffer_feature,building_source) {
    var features=building_source.getFeatures();
    var buffer_geometry=buffer_feature.getGeometry();
    var jsts_buffer_geom = parser.read(buffer_geometry);
    for(var i=0;i<features.length;i++) {
        var building_feature=features[i];
        var building_geometry=building_feature.getGeometry();
        var jsts_building_geom = parser.read(building_geometry);
        var jsts_intersect=jsts_buffer_geom.intersection(jsts_building_geom);


        var intersects_geom=parser.write(jsts_intersect);

        if(intersects_geom.flatCoordinates.length==0)
            continue;

        var portion=100*intersects_geom.getArea()/building_geometry.getArea();
        //console.log(portion.toFixed(2));
        var f= new ol.Feature(intersects_geom);
        f.setProperties({percentage_of_area:portion.toFixed(2)});
        result_source.addFeature(f);
    }



}
var formatWFS = new ol.format.WFS();

var formatGML = new ol.format.GML({
    featureNS: 'test',
    featureType: 'result',
    srsName: 'EPSG:4326'
});
var transactWFS = function (p, features) {

    var converted_features=new Array();
    for(var i=0;i<features.length;i++) {
        var f=features[i];
        var f_clone=f.clone();

        var revertGeometry =reverseGeometry(f_clone.getGeometry().transform('EPSG:3857',"EPSG:4326"));
        f_clone.setGeometry(revertGeometry);

        converted_features.push(f_clone);
    }

    switch (p) {
        case 'insert':
            node = formatWFS.writeTransaction(converted_features, null, null, formatGML);
            break;
        case 'update':
            node = formatWFS.writeTransaction(null, converted_features, null, formatGML);
            break;
        case 'delete':
            node = formatWFS.writeTransaction(null, null, converted_features, formatGML);
            break;
    }
    s = new XMLSerializer();
    str = s.serializeToString(node);


    $.ajax('http://localhost:8080/geoserver/wfs', {
        type: 'POST',
        dataType: 'xml',
        processData: false,
        contentType: 'text/xml',
        data: str
    }).done(function () {
        console.log("success");
    });
}
function reverseGeometry(geometry) {
    var reversed_geometry;
    if(geometry instanceof ol.geom.Polygon) {
        var coordinates=geometry.getLinearRing(0).getCoordinates();
        var new_coordinates=new Array();
        for(var i=0;i<coordinates.length;i++) {
            var coordinate=coordinates[i];
            var new_coordinate=new Array();
            new_coordinate.push(coordinate[1],coordinate[0]);
            new_coordinates.push(new_coordinate);
        }
        reversed_geometry=new ol.geom.Polygon([new_coordinates]);

    }
    else if(geometry instanceof  ol.geom.Point){
        var coordinates=geometry.getCoordinates();
        reversed_geometry=new ol.geom.Point([coordinates[1],coordinates[0]]);
    }

    return reversed_geometry;
}

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};



