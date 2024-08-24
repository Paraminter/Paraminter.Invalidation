namespace Paraminter.Invalidation.Models;

using Xunit;

public sealed class Status_HaveBeenInvalidated
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NotInvalidated_ReturnsFalse()
    {
        var result = Target();

        Assert.False(result);
    }

    [Fact]
    public void Invalidated_ReturnsTrue()
    {
        Fixture.Sut.Invalidator.Invalidate();

        var result = Target();

        Assert.True(result);
    }

    private bool Target() => Fixture.Sut.Status.HaveBeenInvalidated;
}
