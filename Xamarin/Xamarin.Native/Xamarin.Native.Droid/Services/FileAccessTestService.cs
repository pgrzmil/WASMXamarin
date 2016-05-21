using Android.Content;
using Android.Util;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Services
{
    public class FileAccessTestService : Java.Lang.Object
    {
        Context context;

        public FileAccessTestService(Context context)
        {
            this.context = context;
        }

        public void WriteToFile(string fileName, string text)
        {
            try
            {
                File file = new File(context.FilesDir.AbsolutePath, fileName);
                if (file.Exists())
                {
                    file.Delete();
                }

                var outputStreamWriter = new OutputStreamWriter(context.OpenFileOutput(fileName, FileCreationMode.Private));
                outputStreamWriter.Write(text);
                outputStreamWriter.Close();
            }
            catch (IOException e)
            {
                Log.Debug("Exception", "File write failed: " + e.ToString());
            }
        }

        public string ReadFromFile(string fileName)
        {
            var ret = "";

            try
            {
                var inputStream = context.OpenFileInput(fileName);

                if (inputStream != null)
                {
                    var inputStreamReader = new InputStreamReader(inputStream);
                    var bufferedReader = new BufferedReader(inputStreamReader);
                    var receiveString = "";
                    var stringBuilder = new StringBuilder();

                    while ((receiveString = bufferedReader.ReadLine()) != null)
                    {
                        stringBuilder.Append(receiveString);
                    }

                    inputStream.Close();
                    ret = stringBuilder.ToString();
                }
            }
            catch (FileNotFoundException e)
            {
                Log.Debug("Exception", "File not found: " + e.ToString());
            }
            catch (IOException e)
            {
                Log.Debug("Exception", "Can not read file: " + e.ToString());
            }

            return ret;
        }
    }
}