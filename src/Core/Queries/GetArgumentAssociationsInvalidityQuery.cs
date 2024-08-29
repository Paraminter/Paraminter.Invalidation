namespace Paraminter.Invalidation.Queries;

internal sealed class GetArgumentAssociationsInvalidityQuery
    : IGetArgumentAssociationsInvalidityQuery
{
    public static IGetArgumentAssociationsInvalidityQuery Instance { get; } = new GetArgumentAssociationsInvalidityQuery();

    private GetArgumentAssociationsInvalidityQuery() { }
}
