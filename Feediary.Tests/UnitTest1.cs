namespace Feediary.Tests;

public class UnitTest1
{
    [Fact]
    public void BasicTest_ShouldPass()
    {
        // Basic test to ensure the test infrastructure is working
        Assert.True(true);
    }

    [Fact]
    public void Math_ShouldWork()
    {
        // Simple math test to verify xUnit is working correctly
        var result = 2 + 2;
        Assert.Equal(4, result);
    }

    [Fact]
    public void String_ShouldConcatenate()
    {
        // String test to verify basic operations
        var result = "Hello" + " " + "World";
        Assert.Equal("Hello World", result);
    }
}