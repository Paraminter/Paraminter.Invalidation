namespace Paraminter.Processing.Invalidation;

using Paraminter.Processing.Invalidation.Commands;

using System.Threading;
using System.Threading.Tasks;

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

    async Task ICommandHandler<TQuery>.Handle(
        TQuery command,
        CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        await InvalidityResetter.Handle(ResetProcessInvalidityCommand.Instance, cancellationToken).ConfigureAwait(false);
    }
}
