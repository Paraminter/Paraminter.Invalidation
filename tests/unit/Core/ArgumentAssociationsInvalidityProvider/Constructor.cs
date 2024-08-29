namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Invalidation.Models;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInvalidity_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IArgumentAssociationsInvalidity>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidityProvider Target(
        IArgumentAssociationsInvalidity invalidity)
    {
        return new ArgumentAssociationsInvalidityProvider(invalidity);
    }
}
