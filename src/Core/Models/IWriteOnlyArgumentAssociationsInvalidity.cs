namespace Paraminter.Invalidation.Models;

/// <summary>Represents the invalidity of the made associations between arguments and parameters.</summary>
public interface IWriteOnlyArgumentAssociationsInvalidity
{
    /// <summary>Invalidates the made associations between arguments and parameters.</summary>
    public abstract void Invalidate();
}
