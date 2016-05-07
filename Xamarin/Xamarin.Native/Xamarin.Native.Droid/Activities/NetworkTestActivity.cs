using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Services;

namespace Xamarin.Native.Droid.Activities
{
    [Activity(Label = "NetworkTestActivity")]
    public class NetworkTestActivity : Activity
    {
        Stopwatch stopwatch;
        NetworkDownloadService networkService;
        Button startButton;
        EditText addressField;
        TextView timeLabel;
        ImageView downloadedImage;
        ProgressDialog progressDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NetworkTest);
            Title = GetString(Resource.String.menuNetwork);

            addressField = FindViewById<EditText>(Resource.Id.addressField);
            downloadedImage = FindViewById<ImageView>(Resource.Id.downloadedImage);
            timeLabel = FindViewById<TextView>(Resource.Id.timeLabel);
            startButton = FindViewById<Button>(Resource.Id.startButton);

            addressField.Text = "http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg";

            startButton.Click += StartDownloading;
            networkService = new NetworkDownloadService();
            networkService.ImageDownloadCompleted += ImageDownloadCompleted;
        }

        private void StartDownloading(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            progressDialog = ProgressDialog.Show(this, "Pobieranie...", "");

            new Thread(new Runnable(() =>
            {
                networkService.DownloadImage(addressField.Text);
            })).Start();
        }

        private void ImageDownloadCompleted(Bitmap image)
        {
            stopwatch.Stop();
            RunOnUiThread(new Runnable(() =>
            {
                downloadedImage.SetImageBitmap(image);
                timeLabel.Text = stopwatch.GetDurationInSeconds();
                progressDialog.Dismiss();
            }));
        }
    }
}