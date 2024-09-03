namespace Paraminter.Invalidation;

using Paraminter.Cqs;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Queries;

/// <summary>Handles queries by reading the invalidity of the made associations between arguments and parameters.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
public sealed class ArgumentAssociationsInvalidityReadingQueryHandler<TQuery>
    : IQueryHandler<TQuery, bool>
    where TQuery : IQuery
{
    private readonly IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> InvalidityReader;

    /// <summary>Instantiates a query-handler which reads the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="invalidityReader">Reads the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityReadingQueryHandler(
        IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> invalidityReader)
    {
        InvalidityReader = invalidityReader ?? throw new System.ArgumentNullException(nameof(invalidityReader));
    }

    bool IQueryHandler<TQuery, bool>.Handle(
        TQuery query)
    {
        if (query is null)
        {
            throw new System.ArgumentNullException(nameof(query));
        }

        return InvalidityReader.Handle(AreArgumentAssociationsInvalidatedQuery.Instance);
    }
}
