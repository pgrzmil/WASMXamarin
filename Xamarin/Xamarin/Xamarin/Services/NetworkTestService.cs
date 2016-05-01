using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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

        // public event ImageDownloadEventHandler DownloadCompleted;

        public void DownloadImage(string url)
        {
            //TODO:
            //var webClient = new WebClient();
            //webClient.DownloadDataCompleted += (s, e) =>
            //{
            //    if (DownloadCompleted != null)
            //    {
            //        DownloadCompleted(e.Result);
            //    }
            //};
            //webClient.DownloadDataAsync(new Uri(url));
        }
    }
}