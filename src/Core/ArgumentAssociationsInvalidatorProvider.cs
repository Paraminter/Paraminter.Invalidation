namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Provides an invalidator of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidatorProvider
    : IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator>
{
    private readonly IArgumentAssociationsInvalidator Invalidator;

    /// <summary>Instantiates a provider of an invalidator of the made associations between arguments and parameters.</summary>
    /// <param name="invalidator">The invalidator of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidatorProvider(
        IArgumentAssociationsInvalidator invalidator)
    {
        Invalidator = invalidator ?? throw new ArgumentNullException(nameof(invalidator));
    }

    IArgumentAssociationsInvalidator IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator>.Handle(
        IGetArgumentAssociationsInvalidatorQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return Invalidator;
    }
}
