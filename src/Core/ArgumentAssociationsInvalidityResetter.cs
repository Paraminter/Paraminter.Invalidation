namespace Paraminter.Invalidation;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;

using System;

/// <summary>Resets the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidityResetter
    : ICommandHandler<IResetArgumentAssociationsInvalidityCommand>
{
    private readonly ICommandHandler<IResetBinaryStateCommand> StateResetter;

    /// <summary>Instantiates a resetter of the invalidity of the made asssociations between arguments and parameters.</summary>
    /// <param name="stateResetter">Resets the state representing the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityResetter(
        ICommandHandler<IResetBinaryStateCommand> stateResetter)
    {
        StateResetter = stateResetter ?? throw new ArgumentNullException(nameof(stateResetter));
    }

    void ICommandHandler<IResetArgumentAssociationsInvalidityCommand>.Handle(
        IResetArgumentAssociationsInvalidityCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        StateResetter.Handle(ResetBinaryStateCommand.Instance);
    }
}
