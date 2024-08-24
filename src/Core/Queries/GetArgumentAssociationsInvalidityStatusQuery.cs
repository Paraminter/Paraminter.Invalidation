namespace Paraminter.Invalidation.Queries;

internal sealed class GetArgumentAssociationsInvalidityStatusQuery
    : IGetArgumentAssociationsInvalidityStatusQuery
{
    public static IGetArgumentAssociationsInvalidityStatusQuery Instance { get; } = new GetArgumentAssociationsInvalidityStatusQuery();

    private GetArgumentAssociationsInvalidityStatusQuery() { }
}
