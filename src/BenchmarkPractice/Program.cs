using BenchmarkDotNet.Running;
using System;

namespace BenchmarkPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TestContext>();
            Console.ReadLine();
        }
    }
}
