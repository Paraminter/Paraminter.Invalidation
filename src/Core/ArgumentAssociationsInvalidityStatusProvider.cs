namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Provides a representation of the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidityStatusProvider
    : IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus>
{
    private readonly IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> InvalidityProvider;

    /// <summary>Instantiates a provider of a representation of the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="invalidityProvider">Provides the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityStatusProvider(
        IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity> invalidityProvider)
    {
        InvalidityProvider = invalidityProvider ?? throw new ArgumentNullException(nameof(invalidityProvider));
    }

    IArgumentAssociationsInvalidityStatus IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus>.Handle(
        IGetArgumentAssociationsInvalidityStatusQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return InvalidityProvider.Handle(GetArgumentAssociationsInvalidityQuery.Instance).Status;
    }
}
