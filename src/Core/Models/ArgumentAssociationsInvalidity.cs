namespace Paraminter.Invalidation.Models;

/// <inheritdoc cref="IArgumentAssociationsInvalidity"/>
public sealed class ArgumentAssociationsInvalidity
    : IArgumentAssociationsInvalidity
{
    private bool HaveBeenInvalidated = false;

    /// <summary>Instantiates a representation of the invalidity of the made associations between argumetns and parameters, starting in the <see langword="false"/> state.</summary>
    public ArgumentAssociationsInvalidity() { }

    bool IReadOnlyArgumentAssociationsInvalidity.HaveBeenInvalidated => HaveBeenInvalidated;

    void IWriteOnlyArgumentAssociationsInvalidity.Invalidate()
    {
        HaveBeenInvalidated = true;
    }
}
