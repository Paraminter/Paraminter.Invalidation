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
        var result = Target(Mock.Of<IGetArgumentAssociationsInvalidatorQuery>());

        Assert.Same(Fixture.InvalidatorMock.Object, result);
    }

    private IArgumentAssociationsInvalidator Target(
        IGetArgumentAssociationsInvalidatorQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
