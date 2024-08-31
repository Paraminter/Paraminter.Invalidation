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
    public void NullInvalidityResetterProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsInvalidator()
    {
        var result = Target(Mock.Of<IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter>>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidityResetter Target(
        IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter> invalidityResetterProvider)
    {
        return new ArgumentAssociationsInvalidityResetter(invalidityResetterProvider);
    }
}
