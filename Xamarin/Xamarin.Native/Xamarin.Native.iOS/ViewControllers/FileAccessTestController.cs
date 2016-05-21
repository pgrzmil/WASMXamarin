using CoreFoundation;
using Foundation;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Services;

namespace Xamarin.Native.iOS.ViewControllers
{
    public partial class FileAccessTestController : UIViewController
    {
        Stopwatch stopwatch;
        FileAccessTestService fileAccessService;
        string fileName = "testFile.txt";
        int digits = 10000;
        static string contentToWrite;

        public FileAccessTestController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            fileAccessService = new FileAccessTestService();

            RefreshUI(true);

            if (contentToWrite == null)
            {
                DispatchQueue.DefaultGlobalQueue.DispatchAsync(() =>
                    {
                        contentToWrite = PerformanceTestService.Instance.CalculatePi(digits);
                        DispatchQueue.MainQueue.DispatchAsync(() => RefreshUI(false));
                    });
            }
        }

        partial void StartReading(UIButton sender)
        {
            resultView.Text = "";
            stopwatch = new Stopwatch();
            stopwatch.Start();

            var fileContents = fileAccessService.ReadFromFile(fileName);

            stopwatch.Stop();

            resultView.Text = fileContents;
            timeLabel.Text = stopwatch.GetDurationInMilliseconds();
        }

        partial void StartWriting(UIButton sender)
        {
            resultView.Text = "";
            stopwatch = new Stopwatch();
            stopwatch.Start();

            fileAccessService.WriteToFile(fileName, contentToWrite);

            stopwatch.Stop();

            timeLabel.Text = stopwatch.GetDurationInMilliseconds();
        }

        private void RefreshUI(bool isCalculating)
        {
            readButton.Hidden = isCalculating;
            writeButton.Hidden = isCalculating;
            activityIndicator.Hidden = !isCalculating;
        }
    }
}