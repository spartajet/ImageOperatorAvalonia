using Xunit.Abstractions;

namespace ImageOperator.Test;

public abstract class BaseTest(ITestOutputHelper outputHelper)
{
    protected ITestOutputHelper OutputHelper = outputHelper;
}