namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Invalidation.Commands;

using System;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullCommand_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<ICommand>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidCommand_Invalidates()
    {
        var fixture = FixtureFactory.Create<ICommand>();

        Target(fixture, Mock.Of<ICommand>());

        fixture.InvaliditySetterMock.Verify(static (handler) => handler.Handle(It.IsAny<IInvalidateArgumentAssociationsCommand>()), Times.Once());
    }

    private static void Target<TCommand>(
        IFixture<TCommand> fixture,
        TCommand command)
        where TCommand : ICommand
    {
        fixture.Sut.Handle(command);
    }
}
