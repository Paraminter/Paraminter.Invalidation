namespace Paraminter.Invalidation.Models;

using Xunit;

public sealed class Invalidator
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void ReturnsInvalidator()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IArgumentAssociationsInvalidator Target() => Fixture.Sut.Invalidator;
}
