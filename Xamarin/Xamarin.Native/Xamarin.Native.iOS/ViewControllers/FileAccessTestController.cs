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
        string contentToWrite;

        public FileAccessTestController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            fileAccessService = new FileAccessTestService();
        }

        partial void StartReadingFile(UIButton sender)
        {
            stopwatch = new Stopwatch();
            RefreshUI(true);

            stopwatch.Start();

            var fileContents = fileAccessService.ReadFromFile(fileName);
            ResultView.Text = fileContents;

            stopwatch.Stop();
            RefreshUI(false);
            TimeLabel.Text = string.Format("Czas wykonania: {0} ms", Math.Round(stopwatch.Elapsed.TotalMilliseconds, 4));
        }

        partial void StartWritingFile(UIButton sender)
        {
            stopwatch = new Stopwatch();
            RefreshUI(true);
            ResultView.Text = String.Empty;

            if (contentToWrite == null)
            {
                contentToWrite = Task.Run(() => PerformanceTestService.Instance.CalculatePi(digits)).Result;
            }

            stopwatch.Start();

            fileAccessService.WriteToFile(fileName, contentToWrite);

            stopwatch.Stop();

            RefreshUI(false);
            TimeLabel.Text = string.Format("Czas wykonania: {0} ms", Math.Round(stopwatch.Elapsed.TotalMilliseconds, 4));
        }

        private void RefreshUI(bool isDownloading)
        {
            ReadButton.Hidden = isDownloading;
            WriteButton.Hidden = isDownloading;
            ActivityIndicator.Hidden = !isDownloading;
            ActivityIndicator.StartAnimating();
        }
    }
}