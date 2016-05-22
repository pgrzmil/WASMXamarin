using AVFoundation;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Services
{
    public class FileAccessTestService
    {
        public void WriteToFile(string filename, string text)
        {
            var textToWrite = new NSString(text);
            string path = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true)[0];
            path = string.Format("{0}/{1}", path, filename);
            NSError error = new NSError();

            if (NSFileManager.DefaultManager.FileExists(path))
            {
                NSFileManager.DefaultManager.Remove(path, out error);
            }

            NSFileManager.DefaultManager.CreateFile(path, new NSData(), NSFileAttributes.FromDictionary(new NSDictionary()));
            var data = textToWrite.Encode(NSStringEncoding.UTF8);
            data.Save(path, false);
        }

        public string ReadFromFile(string filename)
        {
            string path = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true)[0];
            path = string.Format("{0}/{1}", path, filename);

            return new NSString(NSData.FromFile(path), NSStringEncoding.UTF8);
        }
    }
}