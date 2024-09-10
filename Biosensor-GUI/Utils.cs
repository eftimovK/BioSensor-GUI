using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biosensor_GUI
{
    internal static class Utils
    {
        public static void Logspace(int f1, int f2, int N, Int32[] frequencies)
        {
            float log_f1 = (float)Math.Log10(f1);
            float log_f2 = (float)Math.Log10(f2);
            float delta_log = (log_f2 - log_f1) / (N - 1); // N-1 segments

            for (int i = 0; i < N; i++)
            {
                // if starting from high (f1) to low (f2) => delta_log is negative
                frequencies[i] = f2 + f1 - (Int32)Math.Pow(10, log_f1 + i * delta_log); // more densely spaced for high freq.
            }
            Array.Reverse(frequencies);

            // explicitly set the first and last elements to f1 and f2 to be certain
            frequencies[0] = (Int32)f1;
            frequencies[N - 1] = (Int32)f2;
        }
        public static void Linspace(int f1, int f2, int N, Int32[] frequencies)
        {
            float delta_f = (f2 - f1) / (N - 1); // N-1 segments

            for (int i = 0; i < N; i++)
            {
                // if starting from high (f1) to low (f2) => delta_f is negative
                frequencies[i] = (Int32)(f1 + i * delta_f);
            }

            // Ensure the start and end frequencies are exactly f1 and f2
            frequencies[0] = (Int32)f1;
            frequencies[N - 1] = (Int32)f2;
        }

        public static void EmptyRxBuffer(this SerialPort serialPort)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                if (serialPort.BytesToRead > 0)
                {
                    serialPort.DiscardInBuffer();
                }
            }
        }
    }
}
