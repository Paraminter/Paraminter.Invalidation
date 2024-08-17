namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Invalidation.Models;
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
    public void Invalidated_ReturnsTrue() => ReturnsValue(true);

    [Fact]
    public void NotInvalidated_ReturnsFalse() => ReturnsValue(false);

    private bool Target(
        IAreArgumentAssociationsInvalidatedQuery query)
    {
        return Fixture.Sut.Handle(query);
    }

    private void ReturnsValue(bool expected)
    {
        Mock<IReadOnlyArgumentAssociationsInvalidity> invalidityMock = new();

        invalidityMock.Setup(static (invalidity) => invalidity.HaveBeenInvalidated).Returns(expected);

        Fixture.InvalidityProviderMock.Setup(static (provider) => provider.Handle(It.IsAny<IGetArgumentAssociationsInvalidityQuery>())).Returns(invalidityMock.Object);

        var result = Target(Mock.Of<IAreArgumentAssociationsInvalidatedQuery>());

        Assert.Equal(expected, result);
    }
}
