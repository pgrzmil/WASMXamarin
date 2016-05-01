using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Xamarin.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            Title = "MENU";
        }

        private void NavigateToPerformanceTest(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PerformanceTestPage());
        }

        private void NavigateToFileAccessTest(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FileAccessPage());
        }

        private void NavigateToGpsTest(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GpsTestPage());
        }

        private void NavigateToNetworkTest(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NetworkTestPage());
        }
    }
}