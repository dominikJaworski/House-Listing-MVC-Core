//var map_script = $('script[src*=Details.cshtml]');
//var lat = map_script.attr()


//var mymap = L.map('mapid').setView([51.505, -0.09], 13);

//var redIcon = L.Icon({

//})

$(document).ready(function () {
    var mymap = L.map('mapid').setView([window.latitude, window.longitude], 16);
    
    L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
        attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://mapbox.com">Mapbox</a>',
        minZoom: 10,
        maxZoom: 20,
        id: 'mapbox.streets',
        accessToken: 'pk.eyJ1IjoiZG9tbWFwcGVyIiwiYSI6ImNqY3k1dGttZzB5bXAycXFzZno0b2NhZjkifQ.Q6OTMJ15_k1C7dUjTZviug'
    }).addTo(mymap);
    var marker = L.marker([window.latitude, window.longitude]).addTo(mymap);
});
