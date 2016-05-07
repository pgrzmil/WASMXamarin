using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Forms.Services
{
    public delegate void ImageDownloadEventHandler(ImageSource image);

    internal class NetworkDownloadService
    {
        public event ImageDownloadEventHandler ImageDownloadCompleted;

        public async void DownloadImage(string url)
        {
            var client = new HttpClient();
            var bytes = await client.GetByteArrayAsync(url);
            var image = ImageSource.FromStream(() => new MemoryStream(bytes));

            ImageDownloadCompleted?.Invoke(image);
        }
    }
}