namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;

internal interface IFixture
{
    public abstract ICommandHandler<IInvalidateArgumentAssociationsCommand> Sut { get; }

    public abstract Mock<ICommandHandler<ISetBinaryStateCommand>> StateSetterMock { get; }
}
