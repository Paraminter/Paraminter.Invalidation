namespace Paraminter.Invalidation;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Reads the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidityReader
    : IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>
{
    private readonly IQueryHandler<IIsBinaryStateSetQuery, bool> StateReader;

    /// <summary>Instantiates a reader of the invalidity of the made associations between arguments and parameters.</summary>
    /// <param name="stateReader">Reads the state representing the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityReader(
        IQueryHandler<IIsBinaryStateSetQuery, bool> stateReader)
    {
        StateReader = stateReader ?? throw new ArgumentNullException(nameof(stateReader));
    }

    bool IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>.Handle(
        IAreArgumentAssociationsInvalidatedQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return StateReader.Handle(IsBinaryStateSetQuery.Instance);
    }
}
