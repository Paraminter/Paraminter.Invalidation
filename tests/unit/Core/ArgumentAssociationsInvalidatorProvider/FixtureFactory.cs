namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IArgumentAssociationsInvalidator> invalidatorMock = new();

        var sut = new ArgumentAssociationsInvalidatorProvider(invalidatorMock.Object);

        return new Fixture(sut, invalidatorMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator> Sut;

        private readonly Mock<IArgumentAssociationsInvalidator> InvalidatorMock;

        public Fixture(
            IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator> sut,
            Mock<IArgumentAssociationsInvalidator> invalidatorMock)
        {
            Sut = sut;

            InvalidatorMock = invalidatorMock;
        }

        IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator> IFixture.Sut => Sut;

        Mock<IArgumentAssociationsInvalidator> IFixture.InvalidatorMock => InvalidatorMock;
    }
}
