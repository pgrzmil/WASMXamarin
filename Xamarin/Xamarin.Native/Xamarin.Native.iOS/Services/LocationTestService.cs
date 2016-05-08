using CoreLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.iOS;
using Xamarin.Services;

namespace Xamarin.iOS
{
    public delegate void LocationChangedEventHandler(double latitude, double longitude);

    public class LocationTestService
    {
        public event LocationChangedEventHandler LocationChanged;

        CLLocationManager locationManager;

        public LocationTestService()
        {
            locationManager = new CLLocationManager();
            locationManager.LocationsUpdated += LocationsUpdated;
            locationManager.DistanceFilter = 10;
            locationManager.DesiredAccuracy = CLLocation.AccuracyBest;
        }

        public void GetLocation()
        {
            locationManager.RequestWhenInUseAuthorization();
            locationManager.StartUpdatingLocation();
        }

        public void Stop()
        {
            locationManager.StopUpdatingLocation();
        }

        private void LocationsUpdated(object sender, CLLocationsUpdatedEventArgs e)
        {
            var position = e.Locations.First().Coordinate;
            LocationChanged?.Invoke(position.Latitude, position.Longitude);
        }
    }
}