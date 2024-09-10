namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Invalidation.Commands;

internal interface IFixture<in TCommand>
    where TCommand : ICommand
{
    public abstract ICommandHandler<TCommand> Sut { get; }

    public abstract Mock<ICommandHandler<IInvalidateArgumentAssociationsCommand>> InvaliditySetterMock { get; }
}
