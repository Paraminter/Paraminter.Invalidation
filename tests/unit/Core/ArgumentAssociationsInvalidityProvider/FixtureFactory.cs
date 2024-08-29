namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IArgumentAssociationsInvalidity> invalidityMock = new();

        var sut = new ArgumentAssociationsInvalidityProvider(invalidityMock.Object);

        return new Fixture(sut, invalidityMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> Sut;

        private readonly Mock<IArgumentAssociationsInvalidity> InvalidityMock;

        public Fixture(
            IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> sut,
            Mock<IArgumentAssociationsInvalidity> invalidityMock)
        {
            Sut = sut;

            InvalidityMock = invalidityMock;
        }

        IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> IFixture.Sut => Sut;

        Mock<IArgumentAssociationsInvalidity> IFixture.InvalidityMock => InvalidityMock;
    }
}
