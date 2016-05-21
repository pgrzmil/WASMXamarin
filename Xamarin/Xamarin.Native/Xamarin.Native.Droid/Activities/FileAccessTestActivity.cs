using Android.App;
using Android.Content;
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
    [Activity(Label = "FileAccessTestActivity")]
    public class FileAccessTestActivity : Activity
    {
        string fileName = "testFile.txt";
        int digits = 10000;
        static string contentToWrite;
        Stopwatch stopwatch;

        Button writeButton;
        Button readButton;
        TextView timeLabel;
        TextView resultView;
        ProgressDialog progressDialog;
        FileAccessTestService fileAccessService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FileAccessTest);
            Title = GetString(Resource.String.menuFileAccess);

            timeLabel = FindViewById<TextView>(Resource.Id.timeLabel);
            resultView = FindViewById<TextView>(Resource.Id.resultView);
            readButton = FindViewById<Button>(Resource.Id.readButton);
            writeButton = FindViewById<Button>(Resource.Id.writeButton);

            readButton.Click += StartReading;
            writeButton.Click += StartWriting;
            PerformanceTestService.Instance.PiCalculationCompleted += PiCalculationCompleted;

            fileAccessService = new FileAccessTestService(this);

            if (contentToWrite == null)
            {
                progressDialog = ProgressDialog.Show(this, "Przetwarzanie...", "");
                new Thread(new Runnable(() => { PerformanceTestService.Instance.CalculatePi(digits); })).Start();
            }
        }

        private void StartReading(object sender, EventArgs e)
        {
            resultView.Text = "";
            stopwatch = new Stopwatch();
            stopwatch.Start();

            var fileContents = fileAccessService.ReadFromFile(fileName);

            stopwatch.Stop();

            resultView.Text = fileContents;
            timeLabel.Text = stopwatch.GetDurationInMilliseconds();
        }

        private void StartWriting(object sender, EventArgs e)
        {
            resultView.Text = "";
            stopwatch = new Stopwatch();
            stopwatch.Start();

            fileAccessService.WriteToFile(fileName, contentToWrite);

            stopwatch.Stop();
            timeLabel.Text = stopwatch.GetDurationInMilliseconds();
        }

        private void PiCalculationCompleted(string result)
        {
            contentToWrite = result;
            RunOnUiThread(new Runnable(() => { progressDialog.Dismiss(); }));
        }
    }
}