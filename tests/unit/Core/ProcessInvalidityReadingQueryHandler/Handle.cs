namespace Paraminter.Processing.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Queries;

using System;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullQuery_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<IQuery, object>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidQuery_ReadsInvalidity()
    {
        var expected = Mock.Of<object>();

        var fixture = FixtureFactory.Create<IQuery, object>();

        fixture.InvalidityReaderMock.Setup(static (handler) => handler.Handle(It.IsAny<IIsProcessInvalidatedQuery>())).Returns(expected);

        var result = Target(fixture, Mock.Of<IQuery>());

        Assert.Same(expected, result);
    }

    private static TResponse Target<TQuery, TResponse>(
        IFixture<TQuery, TResponse> fixture,
        TQuery query)
        where TQuery : IQuery
    {
        return fixture.Sut.Handle(query);
    }
}
