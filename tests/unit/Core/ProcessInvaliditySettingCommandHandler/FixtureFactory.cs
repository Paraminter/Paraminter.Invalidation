namespace Paraminter.Processing.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<ISetProcessInvalidityCommand>> invaliditySetterMock = new();

        var sut = new ProcessInvaliditySettingCommandHandler<TCommand>(invaliditySetterMock.Object);

        return new Fixture<TCommand>(sut, invaliditySetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<ISetProcessInvalidityCommand>> InvaliditySetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<ISetProcessInvalidityCommand>> invaliditySetterMock)
        {
            Sut = sut;

            InvaliditySetterMock = invaliditySetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<ISetProcessInvalidityCommand>> IFixture<TCommand>.InvaliditySetterMock => InvaliditySetterMock;
    }
}
