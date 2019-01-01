using DbLocalizationProvider.Internal;
using JetBrains.dotMemoryUnit;
using Xunit;
using Xunit.Abstractions;

namespace DbLocalizationProvider.Tests.AllocationTests
{
    [DotMemoryUnit(CollectAllocations = true, SavingStrategy = SavingStrategy.OnAnyFail)]
    public class ExpressionHelperTests
    {
        public ExpressionHelperTests(ITestOutputHelper outputHelper)
        {
            DotMemoryUnitTestOutput.SetOutputMethod(outputHelper.WriteLine);
        }

        [Fact]
        public void GetTranslation()
        {
            // warm-up
            ExpressionHelper.GetFullMemberName(() => SomeResource.Property1);

            var cp1 = dotMemory.Check();
            ExpressionHelper.GetFullMemberName(() => SomeResource.Property1);
            var cp2 = dotMemory.Check(mem => Assert.False(true));
        }
    }

    public class SomeResource
    {
        public static string Property1 { get; set; }
    }
}
