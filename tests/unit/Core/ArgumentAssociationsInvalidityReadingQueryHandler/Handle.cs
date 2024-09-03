namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Invalidation.Queries;

using System;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullQuery_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<IQuery>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidQuery_ReadsInvalidity()
    {
        var expected = true;

        var fixture = FixtureFactory.Create<IQuery>();

        fixture.InvalidityReaderMock.Setup(static (handler) => handler.Handle(It.IsAny<IAreArgumentAssociationsInvalidatedQuery>())).Returns(expected);

        var result = Target(fixture, Mock.Of<IQuery>());

        Assert.Equal(expected, result);
    }

    private static bool Target<TQuery>(
        IFixture<TQuery> fixture,
        TQuery query)
        where TQuery : IQuery
    {
        return fixture.Sut.Handle(query);
    }
}
