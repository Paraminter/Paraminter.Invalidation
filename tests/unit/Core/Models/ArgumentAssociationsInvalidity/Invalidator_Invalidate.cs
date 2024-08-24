namespace Paraminter.Invalidation.Models;

using Xunit;

public sealed class Invalidator_Invalidate
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NotAlreadyInvalidated_Invalidates()
    {
        Target();

        Assert.True(Fixture.Sut.Status.HaveBeenInvalidated);
    }

    [Fact]
    public void AlreadyInvalidated_LeavesInvalidated()
    {
        Fixture.Sut.Invalidator.Invalidate();

        Target();

        Assert.True(Fixture.Sut.Status.HaveBeenInvalidated);
    }

    private void Target() => Fixture.Sut.Invalidator.Invalidate();
}
