namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IWriteOnlyArgumentAssociationsInvalidity>> invalidityProviderMock = new();

        var sut = new ArgumentAssociationsInvalidator(invalidityProviderMock.Object);

        return new Fixture(sut, invalidityProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<IInvalidateArgumentAssociationsCommand> Sut;

        private readonly Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IWriteOnlyArgumentAssociationsInvalidity>> InvalidityProviderMock;

        public Fixture(
            ICommandHandler<IInvalidateArgumentAssociationsCommand> sut,
            Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IWriteOnlyArgumentAssociationsInvalidity>> invalidityProviderMock)
        {
            Sut = sut;

            InvalidityProviderMock = invalidityProviderMock;
        }

        ICommandHandler<IInvalidateArgumentAssociationsCommand> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IWriteOnlyArgumentAssociationsInvalidity>> IFixture.InvalidityProviderMock => InvalidityProviderMock;
    }
}
