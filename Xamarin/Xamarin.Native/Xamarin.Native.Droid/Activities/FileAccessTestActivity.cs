using Android.App;
using Android.Content;
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
    [Activity(Label = "FileAccessTestActivity")]
    public class FileAccessTestActivity : Activity
    {
        Stopwatch stopwatch;
        FileAccessTestService fileAccessService;
        string fileName = "testFile.txt";
        int digits = 10000;
        string contentToWrite;

        Button writeButton;
        Button readButton;
        TextView TimeLabel;
        TextView ResultView;
        ProgressDialog progressDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FileAccessTest);
            Title = GetString(Resource.String.menuFileAccess);

            fileAccessService = new FileAccessTestService();

            TimeLabel = FindViewById<TextView>(Resource.Id.TimeLabel);
            ResultView = FindViewById<TextView>(Resource.Id.ResultView);
            readButton = FindViewById<Button>(Resource.Id.ReadButton);
            writeButton = FindViewById<Button>(Resource.Id.WriteButton);
            readButton.Click += StartReading;
            writeButton.Click += StartWriting;
        }

        private async void StartWriting(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            progressDialog = ProgressDialog.Show(this, "Przetwarzanie...", "");

            ResultView.Text = String.Empty;

            if (contentToWrite == null)
            {
                contentToWrite = await Task.Run(() => PerformanceTestService.Instance.CalculatePi(digits));
            }

            stopwatch.Start();

            await Task.Run(() => fileAccessService.WriteToFile(fileName, contentToWrite));

            stopwatch.Stop();

            progressDialog.Dismiss();
            TimeLabel.Text = string.Format("Czas wykonania: {0} ms", Math.Round(stopwatch.Elapsed.TotalMilliseconds, 4));
        }

        private async void StartReading(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            progressDialog = ProgressDialog.Show(this, "Przetwarzanie...", "");

            stopwatch.Start();

            var fileContents = await Task.Run(() => fileAccessService.ReadFromFile(fileName));
            ResultView.Text = fileContents;

            stopwatch.Stop();

            progressDialog.Dismiss();
            TimeLabel.Text = string.Format("Czas wykonania: {0} ms", Math.Round(stopwatch.Elapsed.TotalMilliseconds, 4));
        }

        private void RefreshUI(bool isProcessing)
        {
            if (isProcessing)
            {
                readButton.Visibility = ViewStates.Invisible;
                writeButton.Visibility = ViewStates.Invisible;
                progressDialog = ProgressDialog.Show(this, "Przetwarzanie...", "");
            }
            else
            {
                readButton.Visibility = ViewStates.Visible;
                writeButton.Visibility = ViewStates.Visible;
                progressDialog.Dismiss();
            }
        }
    }
}