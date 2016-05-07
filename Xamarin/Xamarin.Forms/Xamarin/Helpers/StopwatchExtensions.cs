using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Helpers
{
    public static class StopwatchExtensions
    {
        public static string GetDurationInMilliseconds(this Stopwatch stopwatch)
        {
            return string.Format("Czas wykonania: {0} ms", Math.Round(stopwatch.Elapsed.TotalMilliseconds, 3));
        }

        public static string GetDurationInSeconds(this Stopwatch stopwatch)
        {
            return string.Format("Czas wykonania: {0} s", Math.Round(stopwatch.Elapsed.TotalSeconds, 3));
        }
    }
}