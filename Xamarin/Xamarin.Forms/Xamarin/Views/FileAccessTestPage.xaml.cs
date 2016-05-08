using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Helpers;
using Xamarin.Forms.Services;

namespace Xamarin.Views
{
    public partial class FileAccessPage : ContentPage
    {
        string fileName = "testFile.txt";
        int digits = 10000;
        Stopwatch stopwatch;
        FileAccessTestService fileAccessService;
        string contentToWrite;

        public FileAccessPage()
        {
            InitializeComponent();
            Title = "Test dostępu do pliku";
            fileAccessService = new FileAccessTestService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            RefreshUI(true);
            contentToWrite = await Task.Run(() => PerformanceTestService.Instance.CalculatePi(digits));
            RefreshUI(false);
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

        private void RefreshUI(bool isCalculating)
        {
            readButton.IsVisible = !isCalculating;
            writeButton.IsVisible = !isCalculating;
            activityIndicator.IsVisible = isCalculating;
            activityIndicator.IsRunning = isCalculating;
        }
    }
}