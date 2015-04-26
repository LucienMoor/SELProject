

var myCenter;


function initialize(lat, lng, nbOffer) {
    var mapProp = {
        zoom: 7,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (pos) {
            myCenter = new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude);
            map.setCenter(myCenter);
        });
         

    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
        myCenter = new google.maps.LatLng(47, 6.93);
        map.setCenter(myCenter);
    }


    

    var offer = new Array();
    var markers = new Array();
    var latitude = lat;
    var longitude = lng;
    for(i=0;i<nbOffer;i++)
    {
        offer[i] = new google.maps.LatLng(latitude[i], longitude[i]);
        markers[i] = new google.maps.Marker({
            position: offer[i],
        });
    }

    for (i = 0; i < nbOffer; i++)
    {
        markers[i].setMap(map);
    }


}
