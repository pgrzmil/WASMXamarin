using PCLStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Services
{
    public class FileAccessTestService
    {
        private readonly IFolder _rootFolder = FileSystem.Current.LocalStorage;

        public void WriteToFile(string filename, string text)
        {
            if (_rootFolder.CheckExistsAsync(filename).Result == ExistenceCheckResult.FileExists)
            {
                var fileToRemove = _rootFolder.GetFileAsync(filename).Result;
                fileToRemove.DeleteAsync().Wait();
            }
            var file = _rootFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting).Result;
            file.WriteAllTextAsync(text).Wait();
        }

        public string ReadFromFile(string filename)
        {
            var file = _rootFolder.GetFileAsync(filename).Result;
            return file.ReadAllTextAsync().Result;
        }
    }
}