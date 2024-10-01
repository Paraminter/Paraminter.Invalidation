namespace Paraminter.Processing.Invalidation.Commands;

internal sealed class ResetProcessInvalidityCommand
    : IResetProcessInvalidityCommand
{
    public static IResetProcessInvalidityCommand Instance { get; } = new ResetProcessInvalidityCommand();

    private ResetProcessInvalidityCommand() { }
}
