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

        public async void WriteToFile(string filename, string text)
        {
            if (await _rootFolder.CheckExistsAsync(filename) == ExistenceCheckResult.FileExists)
            {
                var fileToRemove = await _rootFolder.GetFileAsync(filename);
                await fileToRemove.DeleteAsync();
            }
            var file = await _rootFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(text);
        }

        public string ReadFromFile(string filename)
        {
            var file = _rootFolder.GetFileAsync(filename).Result;
            return file.ReadAllTextAsync().Result;
        }
    }
}