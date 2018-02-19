using System;
using System.IO;

namespace LeftShift_CCI
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Alex\Documents\Visual Studio 2017\DailyProgrammingTestFiles\leftshifttest.txt";
            //read through the file and parse the data
            // This text is added only once to the file.
            string[] tokens_n = File.ReadAllLines(path);
            string[] nk = tokens_n[0].Split(' ');
            int n = Convert.ToInt32(nk[0]);
            int k = Convert.ToInt32(nk[1]);
            string[] a_temp = tokens_n[1].Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int[] output = new int[n];
            //Array.Copy(a, k, a, 0, a.Length - 1);
 
            for(int i = 0; i<n;  i++)
            {
                newLocation = (i + (n - k)) % n;
                output[newLocation] = a[i];
            }
            Console.Read();
        }
    }
}
