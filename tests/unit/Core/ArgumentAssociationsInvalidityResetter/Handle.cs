namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Invalidation.Commands;

using System;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullCommand_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ResetsBinaryState()
    {
        Target(Mock.Of<IResetArgumentAssociationsInvalidityCommand>());

        Fixture.StateResetterMock.Verify(static (handler) => handler.Handle(It.IsAny<IResetBinaryStateCommand>()), Times.Once());
    }

    private void Target(
        IResetArgumentAssociationsInvalidityCommand command)
    {
        Fixture.Sut.Handle(command);
    }
}
