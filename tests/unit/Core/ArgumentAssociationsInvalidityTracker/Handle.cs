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
        Mock<IArgumentAssociationsInvalidityStatus> invalidityStatusMock = new();

        invalidityStatusMock.Setup(static (invalidityStatus) => invalidityStatus.HaveBeenInvalidated).Returns(expected);

        Fixture.InvalidityStatusProviderMock.Setup(static (provider) => provider.Handle(It.IsAny<IGetArgumentAssociationsInvalidityStatusQuery>())).Returns(invalidityStatusMock.Object);

        var result = Target(Mock.Of<IAreArgumentAssociationsInvalidatedQuery>());

        Assert.Equal(expected, result);
    }
}
