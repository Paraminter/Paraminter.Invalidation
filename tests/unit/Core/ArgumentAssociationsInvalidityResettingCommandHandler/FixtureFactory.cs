namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<IResetArgumentAssociationsInvalidityCommand>> invalidityResetterMock = new();

        var sut = new ArgumentAssociationsInvalidityResettingCommandHandler<TCommand>(invalidityResetterMock.Object);

        return new Fixture<TCommand>(sut, invalidityResetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<IResetArgumentAssociationsInvalidityCommand>> InvalidityResetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<IResetArgumentAssociationsInvalidityCommand>> invalidityResetterMock)
        {
            Sut = sut;

            InvalidityResetterMock = invalidityResetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<IResetArgumentAssociationsInvalidityCommand>> IFixture<TCommand>.InvalidityResetterMock => InvalidityResetterMock;
    }
}
