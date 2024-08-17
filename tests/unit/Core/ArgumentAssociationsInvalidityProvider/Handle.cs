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
    public void ValidQuery_ReturnsInvalidity()
    {
        var result = Target(Mock.Of<IGetArgumentAssociationsInvalidityQuery>());

        Assert.Same(Fixture.InvalidityMock.Object, result);
    }

    private IArgumentAssociationsInvalidity Target(
        IGetArgumentAssociationsInvalidityQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
