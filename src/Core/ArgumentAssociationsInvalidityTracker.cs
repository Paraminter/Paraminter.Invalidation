namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Tracks the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidityTracker
    : IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>
{
    private readonly IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus> InvalidityStatusProvider;

    /// <summary>Instantiates a tracker of the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="invalidityStatusProvider">Provides a representation of the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityTracker(
        IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus> invalidityStatusProvider)
    {
        InvalidityStatusProvider = invalidityStatusProvider ?? throw new ArgumentNullException(nameof(invalidityStatusProvider));
    }

    bool IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>.Handle(
        IAreArgumentAssociationsInvalidatedQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var invalidityStatus = InvalidityStatusProvider.Handle(GetArgumentAssociationsInvalidityStatusQuery.Instance);

        return invalidityStatus.HaveBeenInvalidated;
    }
}
