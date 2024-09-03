namespace Paraminter.Invalidation;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;

using System;

/// <summary>Invalidates the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidator
    : ICommandHandler<IInvalidateArgumentAssociationsCommand>
{
    private readonly ICommandHandler<ISetBinaryStateCommand> StateSetter;

    /// <summary>Instantiates an invalidator of the made asssociations between arguments and parameters.</summary>
    /// <param name="stateSetter">Sets the state representing the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidator(
        ICommandHandler<ISetBinaryStateCommand> stateSetter)
    {
        StateSetter = stateSetter ?? throw new ArgumentNullException(nameof(stateSetter));
    }

    void ICommandHandler<IInvalidateArgumentAssociationsCommand>.Handle(
        IInvalidateArgumentAssociationsCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        StateSetter.Handle(SetBinaryStateCommand.Instance);
    }
}
