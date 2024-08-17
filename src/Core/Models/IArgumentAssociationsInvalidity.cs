namespace Paraminter.Invalidation.Models;

/// <summary>Represents the invalidity of the made associations between arguments and parameters.</summary>
public interface IArgumentAssociationsInvalidity
    : IWriteOnlyArgumentAssociationsInvalidity,
    IReadOnlyArgumentAssociationsInvalidity
{ }
