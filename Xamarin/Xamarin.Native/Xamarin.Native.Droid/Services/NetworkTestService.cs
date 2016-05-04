using Android.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Xamarin.Services
{
    public delegate void ImageDownloadEventHandler(Bitmap image);

    internal class NetworkDownloadService : Java.Lang.Object
    {
        public event ImageDownloadEventHandler ImageDownloadCompleted;

        private static readonly NetworkDownloadService instance = new NetworkDownloadService();

        private NetworkDownloadService()
        { }

        public static NetworkDownloadService Instance { get { return instance; } }

        public void DownloadImage(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            ImageDownloadCompleted?.Invoke(imageBitmap);
        }
    }
}