namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>> invalidityProviderMock = new();

        var sut = new ArgumentAssociationsInvalidityStatusProvider(invalidityProviderMock.Object);

        return new Fixture(sut, invalidityProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus> Sut;

        private readonly Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>> InvalidityProviderMock;

        public Fixture(
            IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus> sut,
            Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>> invalidityProviderMock)
        {
            Sut = sut;

            InvalidityProviderMock = invalidityProviderMock;
        }

        IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>> IFixture.InvalidityProviderMock => InvalidityProviderMock;
    }
}
