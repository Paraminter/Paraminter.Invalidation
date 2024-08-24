namespace Paraminter.Invalidation.Models;

using Xunit;

public sealed class Status
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void ReturnsStatus()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IArgumentAssociationsInvalidityStatus Target() => Fixture.Sut.Status;
}
