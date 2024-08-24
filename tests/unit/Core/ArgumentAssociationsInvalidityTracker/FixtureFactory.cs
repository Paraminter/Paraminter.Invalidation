namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus>> invalidityStatusProviderMock = new();

        var sut = new ArgumentAssociationsInvalidityTracker(invalidityStatusProviderMock.Object);

        return new Fixture(sut, invalidityStatusProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> Sut;

        private readonly Mock<IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus>> InvalidityStatusProviderMock;

        public Fixture(
            IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> sut,
            Mock<IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus>> invalidityStatusProviderMock)
        {
            Sut = sut;

            InvalidityStatusProviderMock = invalidityStatusProviderMock;
        }

        IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus>> IFixture.InvalidityStatusProviderMock => InvalidityStatusProviderMock;
    }
}
