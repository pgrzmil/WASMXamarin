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
        int digits = 1000;
        string contentToWrite;

        public FileAccessTestController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            fileAccessService = new FileAccessTestService();
            contentToWrite = Task.Run(() => PerformanceTestService.Instance.CalculatePi(digits)).Result;
        }

        partial void StartReadingFile(UIButton sender)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            RefreshUI(true);

            var fileContents = fileAccessService.ReadFromFile(fileName);
            ResultView.Text = fileContents;

            RefreshUI(false);
            stopwatch.Stop();
            TimeLabel.Text = stopwatch.GetDurationInMilliseconds();
        }

        partial void StartWritingFile(UIButton sender)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            RefreshUI(true);
            ResultView.Text = "";

            fileAccessService.WriteToFile(fileName, contentToWrite);

            stopwatch.Stop();

            RefreshUI(false);
            TimeLabel.Text = stopwatch.GetDurationInMilliseconds();
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