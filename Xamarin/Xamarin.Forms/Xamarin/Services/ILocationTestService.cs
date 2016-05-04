using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Services
{
    public delegate void LocationChangedEventHandler(double latitude, double longitude);

    public interface ILocationTestService
    {
        event LocationChangedEventHandler LocationChanged;

        void GetLocation();
    }
}