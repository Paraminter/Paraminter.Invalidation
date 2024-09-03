namespace Paraminter.Invalidation.Commands;

internal sealed class ResetArgumentAssociationsInvalidityCommand
    : IResetArgumentAssociationsInvalidityCommand
{
    public static IResetArgumentAssociationsInvalidityCommand Instance { get; } = new ResetArgumentAssociationsInvalidityCommand();

    private ResetArgumentAssociationsInvalidityCommand() { }
}
