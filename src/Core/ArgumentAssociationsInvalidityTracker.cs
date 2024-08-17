namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Tracks the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidityTracker
    : IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>
{
    private readonly IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IReadOnlyArgumentAssociationsInvalidity> InvalidityProvider;

    /// <summary>Instantiates a tracker of the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="invalidityProvider">Provides the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityTracker(
        IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IReadOnlyArgumentAssociationsInvalidity> invalidityProvider)
    {
        InvalidityProvider = invalidityProvider ?? throw new ArgumentNullException(nameof(invalidityProvider));
    }

    bool IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>.Handle(
        IAreArgumentAssociationsInvalidatedQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var invalidity = InvalidityProvider.Handle(GetArgumentAssociationsInvalidityQuery.Instance);

        return invalidity.HaveBeenInvalidated;
    }
}
