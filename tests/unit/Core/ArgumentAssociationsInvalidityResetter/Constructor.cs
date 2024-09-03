namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs.Handlers;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateResetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsInvalidator()
    {
        var result = Target(Mock.Of<ICommandHandler<IResetBinaryStateCommand>>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidityResetter Target(
        ICommandHandler<IResetBinaryStateCommand> stateResetter)
    {
        return new ArgumentAssociationsInvalidityResetter(stateResetter);
    }
}
