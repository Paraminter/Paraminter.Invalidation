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
    public void ValidQuery_ReturnsInvalidator()
    {
        var invalidityResetter = Mock.Of<IArgumentAssociationsInvalidityResetter>();

        Mock<IArgumentAssociationsInvalidity> invalidityMock = new();

        invalidityMock.Setup(static (invalidity) => invalidity.Resetter).Returns(invalidityResetter);

        Fixture.InvalidityProviderMock.Setup(static (provider) => provider.Handle(It.IsAny<IGetArgumentAssociationsInvalidityQuery>())).Returns(invalidityMock.Object);

        var result = Target(Mock.Of<IGetArgumentAssociationsInvalidityResetterQuery>());

        Assert.Same(invalidityResetter, result);
    }

    private IArgumentAssociationsInvalidityResetter Target(
        IGetArgumentAssociationsInvalidityResetterQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
