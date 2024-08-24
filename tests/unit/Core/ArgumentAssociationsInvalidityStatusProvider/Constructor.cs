namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Invalidation.Models;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInvalidityStatus_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IArgumentAssociationsInvalidityStatus>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidityStatusProvider Target(
        IArgumentAssociationsInvalidityStatus invalidityStatus)
    {
        return new ArgumentAssociationsInvalidityStatusProvider(invalidityStatus);
    }
}
