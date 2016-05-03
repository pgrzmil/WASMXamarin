using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;

namespace Xamarin.Native.Droid.Activities
{
    [Activity(Label = "Xamarin.Native.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MenuActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Menu);
            Title = GetString(Resource.String.menu);

            Button performanceButton = FindViewById<Button>(Resource.Id.performanceButton);
            Button networkButton = FindViewById<Button>(Resource.Id.networkButton);
            Button locationButton = FindViewById<Button>(Resource.Id.locationButton);
            Button fileAccessButton = FindViewById<Button>(Resource.Id.fileAccessButton);

            performanceButton.Click += PerformanceButton_Click;
            networkButton.Click += NetworkButton_Click;
            locationButton.Click += LocationButton_Click;
            fileAccessButton.Click += FileAccessButton_Click;
        }

        private void FileAccessButton_Click(object sender, EventArgs e)
        {
            var i = new Intent(this, typeof(FileAccessTestActivity));
            StartActivity(i);
        }

        private void LocationButton_Click(object sender, EventArgs e)
        {
            var i = new Intent(this, typeof(LocationTestActivity));
            StartActivity(i);
        }

        private void NetworkButton_Click(object sender, EventArgs e)
        {
            var i = new Intent(this, typeof(NetworkTestActivity));
            StartActivity(i);
        }

        private void PerformanceButton_Click(object sender, EventArgs e)
        {
            var i = new Intent(this, typeof(PerformanceTestActivity));
            StartActivity(i);
        }
    }
}