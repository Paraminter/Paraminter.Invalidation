namespace Paraminter.Invalidation.Commands;

using Paraminter.BinaryState.Commands;

internal sealed class SetBinaryStateCommand
    : ISetBinaryStateCommand
{
    public static ISetBinaryStateCommand Instance { get; } = new SetBinaryStateCommand();

    private SetBinaryStateCommand() { }
}
