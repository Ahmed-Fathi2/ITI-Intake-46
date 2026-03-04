navigator.geolocation.getCurrentPosition(
    function(pos) {
        initMap(pos.coords.latitude, pos.coords.longitude);
    },
    function(err) {
        if(err.code === 1){
            alert("Please enable location service");
        } else {
            console.error(err);
        }
    }
);
