using BenchmarkDotNet.Running;
using System;

namespace BenchmarkPractice.Nfx
{
    class Program
    {
        static void Main(string[] args)
        {
            runTryCatch();

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

        static void runTryCatch()
        {
            BenchmarkRunner.Run<TryCatch>();
        }
    }
}
