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
        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter>> invalidityResetterProviderMock = new();

        var sut = new ArgumentAssociationsInvalidityResetter(invalidityResetterProviderMock.Object);

        return new Fixture(sut, invalidityResetterProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<IResetArgumentAssociationsInvalidityCommand> Sut;

        private readonly Mock<IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter>> InvalidityResetterProviderMock;

        public Fixture(
            ICommandHandler<IResetArgumentAssociationsInvalidityCommand> sut,
            Mock<IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter>> invalidityResetterProviderMock)
        {
            Sut = sut;

            InvalidityResetterProviderMock = invalidityResetterProviderMock;
        }

        ICommandHandler<IResetArgumentAssociationsInvalidityCommand> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter>> IFixture.InvalidityResetterProviderMock => InvalidityResetterProviderMock;
    }
}
