using BenchmarkDotNet.Attributes;
using BenchmarkPractice.Models;

namespace BenchmarkPractice
{
    public class TestContext
    {
        [Benchmark]
        public void TestMD5()
        {
            HashHelper.GetMD5("https://www.baidu.com/img/bd_logo1.png");
        }

        [Benchmark]
        public void TestSHA1()
        {
            HashHelper.GetSHA1("https://www.baidu.com/img/bd_logo1.png");
        }
    }
}
