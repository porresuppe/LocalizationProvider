using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using DbLocalizationProvider.Internal;

namespace DbLocalizationProvider.PerfTests
{
    [MemoryDiagnoser]
    public class ExpressionHelperTests
    {
        [Benchmark]
        public string GetTranslation() => ExpressionHelper.GetFullMemberName(() => SomeResource.Property1);
    }

    public class SomeResource
    {
        public static string Property1 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ExpressionHelperTests>();
        }
    }
}
