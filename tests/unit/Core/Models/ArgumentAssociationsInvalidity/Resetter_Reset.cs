namespace Paraminter.Invalidation.Models;

using Xunit;

public sealed class Resetter_Reset
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NotAlreadyInvalidated_LeavesUninvalidated()
    {
        Target();

        Assert.False(Fixture.Sut.Status.HaveBeenInvalidated);
    }

    [Fact]
    public void Invalidated_Uninvalidates()
    {
        Fixture.Sut.Invalidator.Invalidate();

        Target();

        Assert.False(Fixture.Sut.Status.HaveBeenInvalidated);
    }

    private void Target() => Fixture.Sut.Resetter.Reset();
}
