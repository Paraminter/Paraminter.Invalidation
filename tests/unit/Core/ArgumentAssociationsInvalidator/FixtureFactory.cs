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
        Mock<IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator>> invalidatorProviderMock = new();

        var sut = new ArgumentAssociationsInvalidator(invalidatorProviderMock.Object);

        return new Fixture(sut, invalidatorProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<IInvalidateArgumentAssociationsCommand> Sut;

        private readonly Mock<IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator>> InvalidatorProviderMock;

        public Fixture(
            ICommandHandler<IInvalidateArgumentAssociationsCommand> sut,
            Mock<IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator>> invalidatorProviderMock)
        {
            Sut = sut;

            InvalidatorProviderMock = invalidatorProviderMock;
        }

        ICommandHandler<IInvalidateArgumentAssociationsCommand> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator>> IFixture.InvalidatorProviderMock => InvalidatorProviderMock;
    }
}
