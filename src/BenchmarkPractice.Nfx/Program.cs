using BenchmarkDotNet.Running;
using System;

namespace BenchmarkPractice.Nfx
{
    class Program
    {
        static void Main(string[] args)
        {
            runJson();

            Console.ReadLine();
        }

        static void runQrCodes()
        {
            QrCodes.Init();
            BenchmarkRunner.Run<QrCodes>();
        }

        static void runJson()
        {
            BenchmarkRunner.Run<Json>();
        }
    }
}
