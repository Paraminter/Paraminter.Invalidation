namespace Paraminter.Invalidation.Queries;

internal sealed class GetArgumentAssociationsInvalidatorQuery
    : IGetArgumentAssociationsInvalidatorQuery
{
    public static IGetArgumentAssociationsInvalidatorQuery Instance { get; } = new GetArgumentAssociationsInvalidatorQuery();

    private GetArgumentAssociationsInvalidatorQuery() { }
}
