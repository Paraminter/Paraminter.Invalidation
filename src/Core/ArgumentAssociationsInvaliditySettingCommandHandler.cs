namespace Paraminter.Invalidation;

using Paraminter.Cqs;
using Paraminter.Invalidation.Commands;

/// <summary>Handles commands by setting the invalidity of the made associations between arguments and parameters.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public sealed class ArgumentAssociationsInvaliditySettingCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<IInvalidateArgumentAssociationsCommand> InvaliditySetter;

    /// <summary>Instantiates a command-handler which sets the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="invaliditySetter">Sets the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvaliditySettingCommandHandler(
        ICommandHandler<IInvalidateArgumentAssociationsCommand> invaliditySetter)
    {
        InvaliditySetter = invaliditySetter ?? throw new System.ArgumentNullException(nameof(invaliditySetter));
    }

    void ICommandHandler<TCommand>.Handle(
        TCommand command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        InvaliditySetter.Handle(InvalidateArgumentAssociationsCommand.Instance);
    }
}
