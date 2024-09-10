namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Invalidation.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<IInvalidateArgumentAssociationsCommand>> invaliditySetterMock = new();

        var sut = new ArgumentAssociationsInvaliditySettingCommandHandler<TCommand>(invaliditySetterMock.Object);

        return new Fixture<TCommand>(sut, invaliditySetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<IInvalidateArgumentAssociationsCommand>> InvaliditySetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<IInvalidateArgumentAssociationsCommand>> invaliditySetterMock)
        {
            Sut = sut;

            InvaliditySetterMock = invaliditySetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<IInvalidateArgumentAssociationsCommand>> IFixture<TCommand>.InvaliditySetterMock => InvaliditySetterMock;
    }
}
