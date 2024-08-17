namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IReadOnlyArgumentAssociationsInvalidity>> invalidityProviderMock = new();

        var sut = new ArgumentAssociationsInvalidityTracker(invalidityProviderMock.Object);

        return new Fixture(sut, invalidityProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> Sut;

        private readonly Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IReadOnlyArgumentAssociationsInvalidity>> InvalidityProviderMock;

        public Fixture(
            IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> sut,
            Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IReadOnlyArgumentAssociationsInvalidity>> invalidityProviderMock)
        {
            Sut = sut;

            InvalidityProviderMock = invalidityProviderMock;
        }

        IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IReadOnlyArgumentAssociationsInvalidity>> IFixture.InvalidityProviderMock => InvalidityProviderMock;
    }
}
