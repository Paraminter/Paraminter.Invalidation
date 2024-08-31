namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInvalidityProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidityResetterProvider Target(
        IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> invalidityProvider)
    {
        return new ArgumentAssociationsInvalidityResetterProvider(invalidityProvider);
    }
}
