  let map;
        let marker;

        function initMap() {
            map = new google.maps.Map(document.getElementById("map"), {
                center: { lat: 30.0444, lng: 31.2357 },
                zoom: 12
            });
            
            marker = new google.maps.Marker({
                position: { lat: 30.0444, lng: 31.2357 },
                map: map,
                title: "القاهرة"
            });
        }

        function goToCairo() {
            const pos = { lat: 30.0444, lng: 31.2357 };
            marker.setPosition(pos);
            map.setCenter(pos);
            map.setZoom(15);
            marker.setTitle("القاهرة");
        }

        function goToAlex() {
            const pos = { lat: 31.2001, lng: 29.9187 };
            marker.setPosition(pos);
            map.setCenter(pos);
            map.setZoom(15);
            marker.setTitle("الإسكندرية");
        }

        function goToLuxor() {
            const pos = { lat: 25.6872, lng: 32.6396 };
            marker.setPosition(pos);
            map.setCenter(pos);
            map.setZoom(15);
            marker.setTitle("الأقصر");
        }

        function goToMyLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(
                    function(position) {
                        const pos = {
                            lat: position.coords.latitude,
                            lng: position.coords.longitude
                        };
                        marker.setPosition(pos);
                        map.setCenter(pos);
                        map.setZoom(15);
                        marker.setTitle("موقعك الحالي");
                    },
                    function() {
                        alert("مشكلة اثناء الحصول علي عنانك");
                    }
                );
            }
        }