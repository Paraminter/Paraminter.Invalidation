namespace Paraminter.Invalidation.Models;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsInvalidity()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidity Target() => new();
}
