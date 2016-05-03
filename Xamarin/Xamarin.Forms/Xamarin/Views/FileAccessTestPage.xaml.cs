using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Services;

namespace Xamarin.Views
{
    public partial class FileAccessPage : ContentPage
    {
        Stopwatch stopwatch;
        IFileAccessTestService fileAccessService;
        string fileName = "testFile.txt";
        int digits = 10000;
        string contentToWrite;

        public FileAccessPage()
        {
            InitializeComponent();
            Title = "Test dostępu do pliku".ToUpper();
            fileAccessService = DependencyService.Get<IFileAccessTestService>();
        }

        private void StartReadingFile(object sender, EventArgs e)
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

        private async void StartWritingFile(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            RefreshUI(true);
            ResultView.Text = String.Empty;

            if (contentToWrite == null)
            {
                contentToWrite = await Task.Run(() => PerformanceTestService.Instance.CalculatePi(digits));
            }

            stopwatch.Start();

            fileAccessService.WriteToFile(fileName, contentToWrite);

            stopwatch.Stop();

            RefreshUI(false);
            TimeLabel.Text = string.Format("Czas wykonania: {0} ms", Math.Round(stopwatch.Elapsed.TotalMilliseconds, 4));
        }

        private void RefreshUI(bool isDownloading)
        {
            ReadButton.IsVisible = !isDownloading;
            WriteButton.IsVisible = !isDownloading;
            ActivityIndicator.IsVisible = isDownloading;
            ActivityIndicator.IsRunning = isDownloading;
        }
    }
}