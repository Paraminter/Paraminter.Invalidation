namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Provides an invalidator of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidatorProvider
    : IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator>
{
    private readonly IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> InvalidityProvider;

    /// <summary>Instantiates a provider of an invalidator of the made associations between arguments and parameters.</summary>
    /// <param name="invalidityProvider">Provides the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidatorProvider(
        IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> invalidityProvider)
    {
        InvalidityProvider = invalidityProvider ?? throw new ArgumentNullException(nameof(invalidityProvider));
    }

    IArgumentAssociationsInvalidator IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator>.Handle(
        IGetArgumentAssociationsInvalidatorQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return InvalidityProvider.Handle(GetArgumentAssociationsInvalidityQuery.Instance).Invalidator;
    }
}
