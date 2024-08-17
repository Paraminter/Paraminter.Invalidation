namespace Paraminter.Invalidation.Models;

/// <summary>Represents the invalidity of the made associations between arguments and parameters.</summary>
public interface IReadOnlyArgumentAssociationsInvalidity
{
    /// <summary>Indicates whether the made associations between arguments and parameters have been invalidated.</summary>
    public abstract bool HaveBeenInvalidated { get; }
}
