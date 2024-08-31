namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Invalidation.Commands;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

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
    public void ValidArguments_InvalidatesModel()
    {
        Mock<IArgumentAssociationsInvalidityResetter> invalidityResetterMock = new();

        Fixture.InvalidityResetterProviderMock.Setup(static (handler) => handler.Handle(It.IsAny<IGetArgumentAssociationsInvalidityResetterQuery>())).Returns(invalidityResetterMock.Object);

        Target(Mock.Of<IResetArgumentAssociationsInvalidityCommand>());

        invalidityResetterMock.Verify(static (resetter) => resetter.Reset(), Times.Once);
    }

    private void Target(
        IResetArgumentAssociationsInvalidityCommand command)
    {
        Fixture.Sut.Handle(command);
    }
}
