using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;

namespace Xamarin.Droid
{
    [Activity(Label = "Xamarin", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main_layout);

            var performanceBtn = FindViewById<Button>(Resource.Id.performanceBtn);
            performanceBtn.Click += (sender, e) =>
            {
                var i = new Intent(this, typeof(PerformanceActivity));
                StartActivity(i);
            };

            var downloadBtn = FindViewById<Button>(Resource.Id.downloadBtn);
            downloadBtn.Click += (sender, e) =>
            {
                var i = new Intent(this, typeof(DownloadActivity));
                StartActivity(i);
            };

            var layoutBtn = FindViewById<Button>(Resource.Id.layoutBtn);
            layoutBtn.Click += (sender, e) =>
            {
                var i = new Intent(this, typeof(LayoutActivity));
                StartActivity(i);
            };
        }
    }
}