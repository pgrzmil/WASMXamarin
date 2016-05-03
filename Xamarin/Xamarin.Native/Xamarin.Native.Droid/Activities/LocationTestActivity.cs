using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamarin.Native.Droid.Activities
{
    [Activity(Label = "LocationActivity")]
    public class LocationTestActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LocationTest);
            Title = GetString(Resource.String.menuLocation);
            Button startButton = FindViewById<Button>(Resource.Id.StartButton);
            startButton.Click += StartPositioning;
        }

        private void StartPositioning(object sender, EventArgs e)
        {
        }
    }
}