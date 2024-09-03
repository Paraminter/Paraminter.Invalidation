namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<ICommandHandler<ISetBinaryStateCommand>> stateSetterMock = new();

        var sut = new ArgumentAssociationsInvalidator(stateSetterMock.Object);

        return new Fixture(sut, stateSetterMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<IInvalidateArgumentAssociationsCommand> Sut;

        private readonly Mock<ICommandHandler<ISetBinaryStateCommand>> StateSetterMock;

        public Fixture(
            ICommandHandler<IInvalidateArgumentAssociationsCommand> sut,
            Mock<ICommandHandler<ISetBinaryStateCommand>> stateSetterMock)
        {
            Sut = sut;

            StateSetterMock = stateSetterMock;
        }

        ICommandHandler<IInvalidateArgumentAssociationsCommand> IFixture.Sut => Sut;

        Mock<ICommandHandler<ISetBinaryStateCommand>> IFixture.StateSetterMock => StateSetterMock;
    }
}
