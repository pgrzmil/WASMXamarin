using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Services
{
    public delegate void ImageDownloadEventHandler(byte[] bytes);

    internal class NetworkDownloadService
    {
        public event ImageDownloadEventHandler ImageDownloadCompleted;

        private static readonly NetworkDownloadService instance = new NetworkDownloadService();

        private NetworkDownloadService()
        { }

        public static NetworkDownloadService Instance { get { return instance; } }

        public async void DownloadImage(string url)
        {
            var client = new HttpClient();
            var response = await client.GetByteArrayAsync(url);

            ImageDownloadCompleted?.Invoke(response);
        }
    }
}