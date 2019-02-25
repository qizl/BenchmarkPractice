using BenchmarkDotNet.Running;
using System;

namespace BenchmarkPractice.Nfx
{
    class Program
    {
        static void Main(string[] args)
        {
            QrCodes.Init();

            var summary = BenchmarkRunner.Run<QrCodes>();
            Console.ReadLine();
        }
    }
}
