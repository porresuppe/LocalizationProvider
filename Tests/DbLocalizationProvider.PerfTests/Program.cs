using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using DbLocalizationProvider.Internal;

namespace DbLocalizationProvider.PerfTests
{
    [MemoryDiagnoser]
    public class ExpressionHelperTests
    {
        [Benchmark]
        public string BuildResourceKey() => ExpressionHelper.GetFullMemberName(() => SomeResource.Property1);
    }

    public class SomeResource
    {
        public static string Property1 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<ExpressionHelperTests>();

            var sut = new ExpressionHelperTests();
            var result = sut.BuildResourceKey();

            //Console.ReadLine();
        }
    }
}
