namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<ICommandHandler<IResetBinaryStateCommand>> stateResetterMock = new();

        var sut = new ArgumentAssociationsInvalidityResetter(stateResetterMock.Object);

        return new Fixture(sut, stateResetterMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<IResetArgumentAssociationsInvalidityCommand> Sut;

        private readonly Mock<ICommandHandler<IResetBinaryStateCommand>> StateResetterMock;

        public Fixture(
            ICommandHandler<IResetArgumentAssociationsInvalidityCommand> sut,
            Mock<ICommandHandler<IResetBinaryStateCommand>> stateResetterMock)
        {
            Sut = sut;

            StateResetterMock = stateResetterMock;
        }

        ICommandHandler<IResetArgumentAssociationsInvalidityCommand> IFixture.Sut => Sut;

        Mock<ICommandHandler<IResetBinaryStateCommand>> IFixture.StateResetterMock => StateResetterMock;
    }
}
