using CoreFoundation;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UIKit;

namespace Xamarin.Services
{
    public delegate void ImageDownloadEventHandler(UIImage image);

    internal class NetworkTestService
    {
        public event ImageDownloadEventHandler ImageDownloadCompleted;

        public void DownloadImage(string urlString)
        {
            var url = NSUrl.FromString(urlString);
            var data = NSData.FromUrl(url);
            var resultImage = UIImage.LoadFromData(data);
            ImageDownloadCompleted?.Invoke(resultImage);
        }
    }
}