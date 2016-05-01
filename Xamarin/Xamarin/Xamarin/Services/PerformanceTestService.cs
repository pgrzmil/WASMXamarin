using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Xamarin
{
    public delegate void CalculationFinishedEventHandler(string result);

    internal class PerformanceTestService
    {
        public event CalculationFinishedEventHandler PiCalculationCompleted;

        private static readonly PerformanceTestService instance = new PerformanceTestService();

        private PerformanceTestService()
        { }

        public static PerformanceTestService Instance { get { return instance; } }

        public void CalculatePi(int digits)
        {
            StringBuilder result = new StringBuilder();
            digits++;

            uint[] x = new uint[digits * 3 + 2];
            uint[] r = new uint[digits * 3 + 2];

            for (int j = 0; j < x.Length; j++)
                x[j] = 20;

            for (int i = 0; i < digits; i++)
            {
                uint carry = 0;
                for (int j = 0; j < x.Length; j++)
                {
                    uint num = (uint)(x.Length - j - 1);
                    uint dem = num * 2 + 1;

                    x[j] += carry;

                    uint q = x[j] / dem;
                    r[j] = x[j] % dem;

                    carry = q * num;
                }
                if (i < digits - 1)
                    result.Append((x[x.Length - 1] / 10).ToString());
                r[x.Length - 1] = x[x.Length - 1] % 10; ;
                for (int j = 0; j < x.Length; j++)
                    x[j] = r[j] * 10;
            }

            PiCalculationCompleted?.Invoke(result.Insert(1, ".").ToString());
        }
    }
}