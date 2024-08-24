namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IArgumentAssociationsInvalidityStatus> invalidityStatusMock = new();

        var sut = new ArgumentAssociationsInvalidityStatusProvider(invalidityStatusMock.Object);

        return new Fixture(sut, invalidityStatusMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus> Sut;

        private readonly Mock<IArgumentAssociationsInvalidityStatus> InvalidityStatusMock;

        public Fixture(
            IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus> sut,
            Mock<IArgumentAssociationsInvalidityStatus> invalidityStatusMock)
        {
            Sut = sut;

            InvalidityStatusMock = invalidityStatusMock;
        }

        IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus> IFixture.Sut => Sut;

        Mock<IArgumentAssociationsInvalidityStatus> IFixture.InvalidityStatusMock => InvalidityStatusMock;
    }
}
