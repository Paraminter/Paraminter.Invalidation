namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Invalidation.Queries;

using System;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullQuery_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void StateSet_ReturnsTrue() => ReturnsValue(true);

    [Fact]
    public void StateNotSet_ReturnsFalse() => ReturnsValue(false);

    private bool Target(
        IAreArgumentAssociationsInvalidatedQuery query)
    {
        return Fixture.Sut.Handle(query);
    }

    private void ReturnsValue(bool expected)
    {
        Fixture.StateReaderMock.Setup(static (handler) => handler.Handle(It.IsAny<IIsBinaryStateSetQuery>())).Returns(expected);

        var result = Target(Mock.Of<IAreArgumentAssociationsInvalidatedQuery>());

        Assert.Equal(expected, result);
    }
}
