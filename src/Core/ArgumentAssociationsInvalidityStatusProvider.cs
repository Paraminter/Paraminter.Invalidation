namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Provides a representation of the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidityStatusProvider
    : IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus>
{
    private readonly IArgumentAssociationsInvalidityStatus InvalidityStatus;

    /// <summary>Instantiates a provider of a representation of the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="invalidityStatus">The representation of the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityStatusProvider(
        IArgumentAssociationsInvalidityStatus invalidityStatus)
    {
        InvalidityStatus = invalidityStatus ?? throw new ArgumentNullException(nameof(invalidityStatus));
    }

    IArgumentAssociationsInvalidityStatus IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus>.Handle(
        IGetArgumentAssociationsInvalidityStatusQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return InvalidityStatus;
    }
}
