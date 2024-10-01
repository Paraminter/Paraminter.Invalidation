namespace Paraminter.Processing.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Queries;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInvalidityReader_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IQuery, object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<IQuery, object>(Mock.Of<IQueryHandler<IIsProcessInvalidatedQuery, object>>());

        Assert.NotNull(result);
    }

    private static ProcessInvalidityReadingQueryHandler<TQuery, TResponse> Target<TQuery, TResponse>(
        IQueryHandler<IIsProcessInvalidatedQuery, TResponse> invalidationReader)
        where TQuery : IQuery
    {
        return new ProcessInvalidityReadingQueryHandler<TQuery, TResponse>(invalidationReader);
    }
}
