using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace Xamarin
{
    internal class NetworkDownloadService
    {
        public delegate void ImageDownloadEventHandler(byte[] bytes);

        private static readonly NetworkDownloadService instance = new NetworkDownloadService();

        private NetworkDownloadService()
        {
        }

        public static NetworkDownloadService Instance { get { return instance; } }

        public event ImageDownloadEventHandler DownloadCompleted;

        public async void DownloadImage(string url)
        {
            var request = WebRequest.Create(url);
            var response = await request.GetResponseAsync();
            byte[] bytes = new byte[response.ContentLength];
            await response.GetResponseStream().ReadAsync(bytes, 0, Convert.ToInt32(response.ContentLength));
            //ImageSource.FromStream(() => new MemoryStream(bytes));
            if (DownloadCompleted != null)
            {
                DownloadCompleted(bytes);
            }
        }
    }
}