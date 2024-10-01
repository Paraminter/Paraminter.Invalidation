namespace Paraminter.Processing.Invalidation;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Commands;

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

    void ICommandHandler<TQuery>.Handle(
        TQuery command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        InvaliditySetter.Handle(SetProcessInvalidityCommand.Instance);
    }
}
