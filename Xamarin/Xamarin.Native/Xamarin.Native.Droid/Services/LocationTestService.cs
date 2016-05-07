using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
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

    public class LocationTestService : Java.Lang.Object, ILocationListener
    {
        public event LocationChangedEventHandler LocationChanged;

        LocationManager locationManager;
        string locationProvider;
        Context context;

        public LocationTestService(Context context)
        {
            this.context = context;
            locationManager = (LocationManager)context.GetSystemService(Context.LocationService);
            Criteria criteriaForLocationService = new Criteria { Accuracy = Accuracy.Fine };
            IList<string> acceptableLocationProviders = locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                locationProvider = acceptableLocationProviders.First();
            }
        }

        public void GetLocation()
        {
            locationManager.RequestLocationUpdates(locationProvider, 5, 10, this);
        }

        public void OnLocationChanged(Location location)
        {
            if (location != null)
            {
                LocationChanged?.Invoke(location.Latitude, location.Longitude);
            }
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
        }
    }
}