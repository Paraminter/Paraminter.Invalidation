namespace Paraminter.Invalidation.Models;

using Xunit;

public sealed class Resetter
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void ReturnsResetter()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IArgumentAssociationsInvalidityResetter Target() => Fixture.Sut.Resetter;
}
