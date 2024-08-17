namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Invalidates the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidator
    : ICommandHandler<IInvalidateArgumentAssociationsCommand>
{
    private readonly IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IWriteOnlyArgumentAssociationsInvalidity> InvalidityProvider;

    /// <summary>Instantiates an invalidator of the made asssociations between arguments and parameters.</summary>
    /// <param name="invalidityProvider">Provides the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidator(
        IQueryHandler<IGetArgumentAssociationsInvalidityQuery, IWriteOnlyArgumentAssociationsInvalidity> invalidityProvider)
    {
        InvalidityProvider = invalidityProvider ?? throw new ArgumentNullException(nameof(invalidityProvider));
    }

    void ICommandHandler<IInvalidateArgumentAssociationsCommand>.Handle(
        IInvalidateArgumentAssociationsCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var invalidity = InvalidityProvider.Handle(GetArgumentAssociationsInvalidityQuery.Instance);

        invalidity.Invalidate();
    }
}
