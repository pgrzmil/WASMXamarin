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
            string filePath = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true)[0];
            string fileAtPath = filePath + filename;
            NSFileManager.DefaultManager.CreateFile(fileAtPath, new NSData(), NSFileAttributes.FromDictionary(new NSDictionary()));
            var a = new NSString(text);

            var data = a.Encode(NSStringEncoding.UTF8);
            data.Save(fileAtPath, false);
        }

        public string ReadFromFile(string filename)
        {
            string filePath = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true)[0];
            string fileAtPath = filePath + filename;

            var data = NSData.FromFile(fileAtPath);
            var a = new NSString(data, NSStringEncoding.UTF8);
            return a;
        }
    }
}