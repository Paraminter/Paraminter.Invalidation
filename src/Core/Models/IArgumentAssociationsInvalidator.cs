namespace Paraminter.Invalidation.Models;

/// <summary>Invalidates the made associations between arguments and parameters.</summary>
public interface IArgumentAssociationsInvalidator
{
    /// <summary>Invalidates the made associations between arguments and parameters.</summary>
    public abstract void Invalidate();
}
