namespace Paraminter.Invalidation.Queries;

internal sealed class GetArgumentAssociationsInvalidityResetterQuery
    : IGetArgumentAssociationsInvalidityResetterQuery
{
    public static IGetArgumentAssociationsInvalidityResetterQuery Instance { get; } = new GetArgumentAssociationsInvalidityResetterQuery();

    private GetArgumentAssociationsInvalidityResetterQuery() { }
}
