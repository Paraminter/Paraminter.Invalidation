namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Invalidation.Models;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInvalidator_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IArgumentAssociationsInvalidator>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidatorProvider Target(
        IArgumentAssociationsInvalidator invalidator)
    {
        return new ArgumentAssociationsInvalidatorProvider(invalidator);
    }
}
