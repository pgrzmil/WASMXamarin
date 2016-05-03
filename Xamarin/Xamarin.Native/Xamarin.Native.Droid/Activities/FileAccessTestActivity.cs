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
    [Activity(Label = "FileAccessTestActivity")]
    public class FileAccessTestActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FileAccessTest);
            Title = GetString(Resource.String.menuFileAccess);

            Button readButton = FindViewById<Button>(Resource.Id.StartButton);
            Button writeButton = FindViewById<Button>(Resource.Id.StartButton);
            readButton.Click += StartReading; ;
            writeButton.Click += StartWriting; ;
        }

        private void StartWriting(object sender, EventArgs e)
        {
        }

        private void StartReading(object sender, EventArgs e)
        {
        }
    }
}