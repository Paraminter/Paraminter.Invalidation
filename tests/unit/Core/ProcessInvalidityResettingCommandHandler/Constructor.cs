namespace Paraminter.Processing.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Commands;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInvalidityResetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<IResetProcessInvalidityCommand>>());

        Assert.NotNull(result);
    }

    private static ProcessInvalidityResettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<IResetProcessInvalidityCommand> invalidityResetter)
        where TCommand : ICommand
    {
        return new ProcessInvalidityResettingCommandHandler<TCommand>(invalidityResetter);
    }
}
