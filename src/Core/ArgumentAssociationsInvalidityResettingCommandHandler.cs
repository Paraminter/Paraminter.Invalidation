namespace Paraminter.Invalidation;

using Paraminter.Cqs;
using Paraminter.Invalidation.Commands;

/// <summary>Handles commands by resetting the invalidity of the made associations between arguments and parameters.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public sealed class ArgumentAssociationsInvalidityResettingCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<IResetArgumentAssociationsInvalidityCommand> InvalidityResetter;

    /// <summary>Instantiates a command-handler which resets the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="invalidityResetter">Resets the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityResettingCommandHandler(
        ICommandHandler<IResetArgumentAssociationsInvalidityCommand> invalidityResetter)
    {
        InvalidityResetter = invalidityResetter ?? throw new System.ArgumentNullException(nameof(invalidityResetter));
    }

    void ICommandHandler<TCommand>.Handle(
        TCommand command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        InvalidityResetter.Handle(ResetArgumentAssociationsInvalidityCommand.Instance);
    }
}
