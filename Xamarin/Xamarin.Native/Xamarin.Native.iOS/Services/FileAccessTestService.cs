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
            string filePath = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true)[0];
            filePath = string.Format("{0}/{1}", filePath, filename);
            NSError error = new NSError();

            if (NSFileManager.DefaultManager.FileExists(filePath))
            {
                NSFileManager.DefaultManager.Remove(filePath, out error);
            }

            NSFileManager.DefaultManager.CreateFile(filePath, new NSData(), NSFileAttributes.FromDictionary(new NSDictionary()));
            var data = textToWrite.Encode(NSStringEncoding.UTF8);
            data.Save(filePath, false);
        }

        public string ReadFromFile(string filename)
        {
            string filePath = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true)[0];
            filePath = string.Format("{0}/{1}", filePath, filename);

            return new NSString(NSData.FromFile(filePath), NSStringEncoding.UTF8);
        }
    }
}