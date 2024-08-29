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

        var sut = new ArgumentAssociationsInvalidatorProvider(invalidityProviderMock.Object);

        return new Fixture(sut, invalidityProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator> Sut;

        private readonly Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>> InvalidityProviderMock;

        public Fixture(
            IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator> sut,
            Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>> invalidityProviderMock)
        {
            Sut = sut;

            InvalidityProviderMock = invalidityProviderMock;
        }

        IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>> IFixture.InvalidityProviderMock => InvalidityProviderMock;
    }
}
