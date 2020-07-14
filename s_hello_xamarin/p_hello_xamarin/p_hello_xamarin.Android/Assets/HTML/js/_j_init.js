var s_map_;

//Map script callback
function GetMap() {
    s_map_ = new Microsoft.Maps.Map('#myMap',
        {
            credentials: 'AuZIBmC5pvcoKCjQUsa7WG__SmbOcU9eCJUa1qfjEMfXjBVkmspXebJahDhrp6sm',
            center: new Microsoft.Maps.Location(15.62916511, 32.56757639),
            setLang: 'ar-SA',
            mapTypeId: Microsoft.Maps.MapTypeId.canvasLight,
            showMapTypeSelector: false,
            showLocateMeButton: false,
            showZoomButtons: false,
            zoom: 12
        });

    //Add your post map load code here.
    var center = s_map_.getCenter();

    //Create custom Pushpin
    var pin = new Microsoft.Maps.Pushpin(center,
        {
            color: 'silver',
            icon: 'img/pin_green.svg'
        });

    //Add the pushpin to the map
    s_map_.entities.push(pin);

    //Load the directions module.
    Microsoft.Maps.loadModule('Microsoft.Maps.Directions', function ()
    {



        //Create an instance of the directions manager.
        directionsManager = new Microsoft.Maps.Directions.DirectionsManager(s_map_);

        //Create waypoints to route between.
        directionsManager.addWaypoint(new Microsoft.Maps.Directions.Waypoint({ address: 'London, UK' }));
        directionsManager.addWaypoint(new Microsoft.Maps.Directions.Waypoint({ address: 'Madrid, ES' }));

        //Set the request options that avoid highways and uses kilometers.
        directionsManager.setRequestOptions(
            {
                distanceUnit: Microsoft.Maps.Directions.DistanceUnit.km,
                routeAvoidance: [Microsoft.Maps.Directions.RouteAvoidance.avoidLimitedAccessHighway]
            });

        //Make the route line thick and green. Replace the title of waypoints with an empty string to hide the default text that appears.
        directionsManager.setRenderOptions(
            {
                drivingPolylineOptions:
                {
                    strokeColor: 'darkred',
                    strokeThickness: 6
                },

                waypointPushpinOptions:
                {
                    title: ''
                }
            });

        //Calculate directions.
        directionsManager.calculateDirections();



    })
}

function get_center_()
{
    var l_loc_ = s_map_.getCenter();

    alert(l_loc_.latitude);
    alert(l_loc_.longitude);
}