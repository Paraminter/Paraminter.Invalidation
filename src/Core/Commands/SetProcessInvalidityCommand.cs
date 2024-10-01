namespace Paraminter.Processing.Invalidation.Commands;

internal sealed class SetProcessInvalidityCommand
    : ISetProcessInvalidityCommand
{
    public static ISetProcessInvalidityCommand Instance { get; } = new SetProcessInvalidityCommand();

    private SetProcessInvalidityCommand() { }
}
