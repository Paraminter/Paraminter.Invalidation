namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Invalidation.Commands;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInvaliditySetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<IInvalidateArgumentAssociationsCommand>>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvaliditySettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<IInvalidateArgumentAssociationsCommand> invaliditySetter)
        where TCommand : ICommand
    {
        return new ArgumentAssociationsInvaliditySettingCommandHandler<TCommand>(invaliditySetter);
    }
}
