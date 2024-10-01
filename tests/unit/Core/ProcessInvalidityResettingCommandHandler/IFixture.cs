namespace Paraminter.Processing.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Commands;

internal interface IFixture<in TCommand>
    where TCommand : ICommand
{
    public abstract ICommandHandler<TCommand> Sut { get; }

    public abstract Mock<ICommandHandler<IResetProcessInvalidityCommand>> InvalidityResetterMock { get; }
}
