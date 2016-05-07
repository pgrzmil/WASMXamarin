using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Services
{
    public delegate void LocationChangedEventHandler(double latitude, double longitude);

    public class LocationTestService
    {
        public event LocationChangedEventHandler LocationChanged;

        IGeolocator locator;

        public LocationTestService()
        {
            locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 10;
        }

        public async void GetLocation()
        {
            var position = await locator.GetPositionAsync();
            LocationChanged?.Invoke(position.Latitude, position.Longitude);
        }
    }
}