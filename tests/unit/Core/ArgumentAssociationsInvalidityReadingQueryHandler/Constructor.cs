namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Queries;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInvalidityReader_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IQuery>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target<IQuery>(Mock.Of<IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidityReadingQueryHandler<TQuery> Target<TQuery>(
        IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> invalidityReader)
        where TQuery : IQuery
    {
        return new ArgumentAssociationsInvalidityReadingQueryHandler<TQuery>(invalidityReader);
    }
}
