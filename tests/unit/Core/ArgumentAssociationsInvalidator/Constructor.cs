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
    public void ValidArguments_ReturnsInvalidator()
    {
        var result = Target(Mock.Of<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IWriteOnlyArgumentAssociationsInvalidity>>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidator Target(
        IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IWriteOnlyArgumentAssociationsInvalidity> invalidityProvider)
    {
        return new ArgumentAssociationsInvalidator(invalidityProvider);
    }
}
