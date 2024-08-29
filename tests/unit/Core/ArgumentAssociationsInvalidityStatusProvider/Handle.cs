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
    public void ValidQuery_ReturnsInvalidityStatus()
    {
        var invalidityStatus = Mock.Of<IArgumentAssociationsInvalidityStatus>();

        Mock<IArgumentAssociationsInvalidity> invalidityMock = new();

        invalidityMock.Setup(static (invalidity) => invalidity.Status).Returns(invalidityStatus);

        Fixture.InvalidityProviderMock.Setup(static (provider) => provider.Handle(It.IsAny<IGetArgumentAssociationsInvalidityQuery>())).Returns(invalidityMock.Object);

        var result = Target(Mock.Of<IGetArgumentAssociationsInvalidityStatusQuery>());

        Assert.Same(invalidityStatus, result);
    }

    private IArgumentAssociationsInvalidityStatus Target(
        IGetArgumentAssociationsInvalidityStatusQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
