namespace Paraminter.Processing.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Commands;

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
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<ISetProcessInvalidityCommand>>());

        Assert.NotNull(result);
    }

    private static ProcessInvaliditySettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<ISetProcessInvalidityCommand> invaliditySetter)
        where TCommand : ICommand
    {
        return new ProcessInvaliditySettingCommandHandler<TCommand>(invaliditySetter);
    }
}
