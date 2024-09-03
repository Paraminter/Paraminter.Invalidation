namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateReader_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IQueryHandler<IIsBinaryStateSetQuery, bool>>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidityReader Target(
        IQueryHandler<IIsBinaryStateSetQuery, bool> stateReader)
    {
        return new ArgumentAssociationsInvalidityReader(stateReader);
    }
}
