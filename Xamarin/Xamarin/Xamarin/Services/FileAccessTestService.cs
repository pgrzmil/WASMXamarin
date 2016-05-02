using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Services
{
    public interface IFileAccessTestService
    {
        void WriteToFile(string filename, string text);

        string ReadFromFile(string filename);
    }
}