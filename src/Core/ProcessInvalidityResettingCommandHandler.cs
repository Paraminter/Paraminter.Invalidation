namespace Paraminter.Processing.Invalidation;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Commands;

/// <summary>Handles commands by resetting the invalidity status.</summary>
/// <typeparam name="TQuery">The type of the handled commands.</typeparam>
public sealed class ProcessInvalidityResettingCommandHandler<TQuery>
    : ICommandHandler<TQuery>
    where TQuery : ICommand
{
    private readonly ICommandHandler<IResetProcessInvalidityCommand> InvalidityResetter;

    /// <summary>Instantiates a command-handler which resets the invalidity status.</summary>
    /// <param name="invalidityResetter">Resets the invalidity status.</param>
    public ProcessInvalidityResettingCommandHandler(
        ICommandHandler<IResetProcessInvalidityCommand> invalidityResetter)
    {
        InvalidityResetter = invalidityResetter ?? throw new System.ArgumentNullException(nameof(invalidityResetter));
    }

    void ICommandHandler<TQuery>.Handle(
        TQuery command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        InvalidityResetter.Handle(ResetProcessInvalidityCommand.Instance);
    }
}
