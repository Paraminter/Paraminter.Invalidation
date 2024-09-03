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
    public void ValidArguments_SetsBinaryState()
    {
        Target(Mock.Of<IInvalidateArgumentAssociationsCommand>());

        Fixture.StateSetterMock.Verify(static (handler) => handler.Handle(It.IsAny<ISetBinaryStateCommand>()), Times.Once());
    }

    private void Target(
        IInvalidateArgumentAssociationsCommand command)
    {
        Fixture.Sut.Handle(command);
    }
}
