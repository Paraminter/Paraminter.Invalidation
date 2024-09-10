namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Invalidation.Commands;

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
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<IResetArgumentAssociationsInvalidityCommand>>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidityResettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<IResetArgumentAssociationsInvalidityCommand> invalidityResetter)
        where TCommand : ICommand
    {
        return new ArgumentAssociationsInvalidityResettingCommandHandler<TCommand>(invalidityResetter);
    }
}
