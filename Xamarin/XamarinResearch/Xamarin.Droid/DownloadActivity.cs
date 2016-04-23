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
using System.Net;
using System.Text;

namespace Xamarin.Droid
{
    [Activity(Label = "DownloadActivity")]
    public class DownloadActivity : Activity
    {
        Button startBtn;
        EditText urlText;
        TextView timeText;
        ImageView resultView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_download);

            urlText = FindViewById<EditText>(Resource.Id.urlText);
            timeText = FindViewById<TextView>(Resource.Id.timeText);
            resultView = FindViewById<ImageView>(Resource.Id.imageView);
            startBtn = FindViewById<Button>(Resource.Id.startBtn);

            startBtn.Click += (sender, e) =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string url = urlText.Text;
                Bitmap result = GetImageBitmapFromUrl(url);
                stopwatch.Stop();

                long stopTime = stopwatch.ElapsedMilliseconds;
                resultView.SetImageBitmap(result);
                timeText.Text = String.Format("{0}:{1}:{2}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
            };
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}