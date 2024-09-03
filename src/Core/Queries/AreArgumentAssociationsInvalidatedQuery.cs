namespace Paraminter.Invalidation.Queries;

internal sealed class AreArgumentAssociationsInvalidatedQuery
    : IAreArgumentAssociationsInvalidatedQuery
{
    public static IAreArgumentAssociationsInvalidatedQuery Instance { get; } = new AreArgumentAssociationsInvalidatedQuery();

    private AreArgumentAssociationsInvalidatedQuery() { }
}
