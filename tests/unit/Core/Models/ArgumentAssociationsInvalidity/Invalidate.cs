namespace Paraminter.Invalidation.Models;

using Xunit;

public sealed class Invalidate
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NotAlreadyInvalidated_Invalidates()
    {
        Target();

        Assert.True(Fixture.Sut.HaveBeenInvalidated);
    }

    [Fact]
    public void AlreadyInvalidated_LeavesInvalidated()
    {
        Fixture.Sut.Invalidate();

        Target();

        Assert.True(Fixture.Sut.HaveBeenInvalidated);
    }

    private void Target() => Fixture.Sut.Invalidate();
}
