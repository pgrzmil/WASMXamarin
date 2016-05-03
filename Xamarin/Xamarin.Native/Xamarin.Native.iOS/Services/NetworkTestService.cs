using CoreFoundation;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Xamarin.Services
{
    public delegate void ImageDownloadEventHandler(NSData data);

    internal class NetworkDownloadService
    {
        public event ImageDownloadEventHandler ImageDownloadCompleted;

        private static readonly NetworkDownloadService instance = new NetworkDownloadService();

        private NetworkDownloadService()
        { }

        public static NetworkDownloadService Instance { get { return instance; } }

        public void DownloadImage(string urlString)
        {
            DispatchQueue.DefaultGlobalQueue.DispatchAsync(() =>
            {
                var url = NSUrl.FromString(urlString);
                var response = NSData.FromUrl(url);
                ImageDownloadCompleted?.Invoke(response);
            });
        }
    }
}