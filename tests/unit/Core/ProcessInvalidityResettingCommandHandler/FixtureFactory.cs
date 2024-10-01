namespace Paraminter.Processing.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<IResetProcessInvalidityCommand>> invalidityResetterMock = new();

        var sut = new ProcessInvalidityResettingCommandHandler<TCommand>(invalidityResetterMock.Object);

        return new Fixture<TCommand>(sut, invalidityResetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<IResetProcessInvalidityCommand>> InvalidityResetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<IResetProcessInvalidityCommand>> invalidityResetterMock)
        {
            Sut = sut;

            InvalidityResetterMock = invalidityResetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<IResetProcessInvalidityCommand>> IFixture<TCommand>.InvalidityResetterMock => InvalidityResetterMock;
    }
}
