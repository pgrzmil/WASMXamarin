using Android.Graphics;
using Android.Util;
using Java.Net;
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
        private static readonly NetworkDownloadService instance = new NetworkDownloadService();

        public event ImageDownloadEventHandler ImageDownloadCompleted;

        public static NetworkDownloadService Instance { get { return instance; } }

        private NetworkDownloadService()
        { }

        public void DownloadImage(string urlString)
        {
            try
            {
                URL url = new URL(urlString);
                Stream stream = url.OpenConnection().InputStream;
                Bitmap image = BitmapFactory.DecodeStream(stream);
                ImageDownloadCompleted?.Invoke(image);
            }
            catch (Exception e)
            {
                Log.Debug("Exception", "Image failed to download: " + e.ToString());
            }
        }
    }
}