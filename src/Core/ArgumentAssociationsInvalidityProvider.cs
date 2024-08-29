namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Provides the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidityProvider
    : IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>
{
    private readonly IArgumentAssociationsInvalidity Invalidity;

    /// <summary>Instantiates a provider of the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="invalidity">The invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityProvider(
        IArgumentAssociationsInvalidity invalidity)
    {
        Invalidity = invalidity ?? throw new ArgumentNullException(nameof(invalidity));
    }

    IArgumentAssociationsInvalidity IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IArgumentAssociationsInvalidity>.Handle(
        IGetArgumentAssociationsInvalidityQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return Invalidity;
    }
}
