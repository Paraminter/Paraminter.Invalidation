namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs.Handlers;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateSetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsInvalidator()
    {
        var result = Target(Mock.Of<ICommandHandler<ISetBinaryStateCommand>>());

        Assert.NotNull(result);
    }

    private static ArgumentAssociationsInvalidator Target(
        ICommandHandler<ISetBinaryStateCommand> stateSetter)
    {
        return new ArgumentAssociationsInvalidator(stateSetter);
    }
}
