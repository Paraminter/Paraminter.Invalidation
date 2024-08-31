namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Provides a resetter of the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidityResetterProvider
    : IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter>
{
    private readonly IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> InvalidityProvider;

    /// <summary>Instantiates a provider of a resetter of the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="invalidityProvider">Provides the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityResetterProvider(
        IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> invalidityProvider)
    {
        InvalidityProvider = invalidityProvider ?? throw new ArgumentNullException(nameof(invalidityProvider));
    }

    IArgumentAssociationsInvalidityResetter IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter>.Handle(
        IGetArgumentAssociationsInvalidityResetterQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return InvalidityProvider.Handle(GetArgumentAssociationsInvalidityQuery.Instance).Resetter;
    }
}
