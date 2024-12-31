namespace Paraminter.Processing.Invalidation;

using Paraminter.Processing.Invalidation.Commands;

using System.Threading;
using System.Threading.Tasks;

/// <summary>Handles commands by setting the invalidity status.</summary>
/// <typeparam name="TQuery">The type of the handled commands.</typeparam>
public sealed class ProcessInvaliditySettingCommandHandler<TQuery>
    : ICommandHandler<TQuery>
    where TQuery : ICommand
{
    private readonly ICommandHandler<ISetProcessInvalidityCommand> InvaliditySetter;

    /// <summary>Instantiates a command-handler which sets the invalidity status.</summary>
    /// <param name="invaliditySetter">Sets the invalidity status.</param>
    public ProcessInvaliditySettingCommandHandler(
        ICommandHandler<ISetProcessInvalidityCommand> invaliditySetter)
    {
        InvaliditySetter = invaliditySetter ?? throw new System.ArgumentNullException(nameof(invaliditySetter));
    }

    async Task ICommandHandler<TQuery>.Handle(
        TQuery command,
        CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        await InvaliditySetter.Handle(SetProcessInvalidityCommand.Instance, cancellationToken).ConfigureAwait(false);
    }
}
