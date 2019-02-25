using BenchmarkDotNet.Attributes;
using BenchmarkPractice.Models;

namespace BenchmarkPractice
{
    public class Md5VsSha1
    {
        [Benchmark]
        public void TestMD5()
        {
            HashHelper.GetMD5(nameof(Md5VsSha1));
        }

        [Benchmark]
        public void TestSHA1()
        {
            HashHelper.GetSHA1(nameof(Md5VsSha1));
        }
    }
}
