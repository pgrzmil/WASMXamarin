using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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
        Button startButton;
        EditText AddressField;
        TextView TimeLabel;
        ImageView DownloadedImage;
        ProgressDialog progressDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NetworkTest);
            Title = GetString(Resource.String.menuNetwork);
            NetworkDownloadService.Instance.ImageDownloadCompleted += Instance_DownloadCompleted;

            AddressField = FindViewById<EditText>(Resource.Id.AddressField);
            DownloadedImage = FindViewById<ImageView>(Resource.Id.DownloadedImage);
            TimeLabel = FindViewById<TextView>(Resource.Id.TimeLabel);
            startButton = FindViewById<Button>(Resource.Id.StartButton);
            startButton.Click += StartDownloading;

            AddressField.Text = "http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg";
        }

        private void StartDownloading(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            RefreshUI(true);

            stopwatch.Start();
            Task.Run(() => NetworkDownloadService.Instance.DownloadImage(AddressField.Text));
        }

        private void Instance_DownloadCompleted(Bitmap image)
        {
            stopwatch.Stop();
            RunOnUiThread(() =>
            {
                DownloadedImage.SetImageBitmap(image);
                RefreshUI(false);
                TimeLabel.Text = String.Format("Czas wykonania: {0} s", Math.Round(stopwatch.Elapsed.TotalSeconds, 4));
            });
        }

        private void RefreshUI(bool isDownloading)
        {
            AddressField.Enabled = !isDownloading;

            if (isDownloading)
            {
                startButton.Visibility = ViewStates.Invisible;
                progressDialog = ProgressDialog.Show(this, "Pobieranie...", "");
            }
            else
            {
                startButton.Visibility = ViewStates.Visible;
                progressDialog.Dismiss();
            }
        }
    }
}