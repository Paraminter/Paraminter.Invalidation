namespace Paraminter.Invalidation.Commands;

internal sealed class InvalidateArgumentAssociationsCommand
    : IInvalidateArgumentAssociationsCommand
{
    public static IInvalidateArgumentAssociationsCommand Instance { get; } = new InvalidateArgumentAssociationsCommand();

    private InvalidateArgumentAssociationsCommand() { }
}
