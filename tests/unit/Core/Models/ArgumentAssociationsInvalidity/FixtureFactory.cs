namespace Paraminter.Invalidation.Models;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        var sut = new ArgumentAssociationsInvalidity();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IArgumentAssociationsInvalidity Sut;

        public Fixture(
            IArgumentAssociationsInvalidity sut)
        {
            Sut = sut;
        }

        IArgumentAssociationsInvalidity IFixture.Sut => Sut;
    }
}
