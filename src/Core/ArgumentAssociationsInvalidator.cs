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
    private readonly IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidator> InvalidatorProvider;

    /// <summary>Instantiates an invalidator of the made asssociations between arguments and parameters.</summary>
    /// <param name="invalidatorProvider">Provides an invalidator of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidator(
        IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidator> invalidatorProvider)
    {
        InvalidatorProvider = invalidatorProvider ?? throw new ArgumentNullException(nameof(invalidatorProvider));
    }

    void ICommandHandler<IInvalidateArgumentAssociationsCommand>.Handle(
        IInvalidateArgumentAssociationsCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var invalidator = InvalidatorProvider.Handle(GetArgumentAssociationsInvalidityStatusQuery.Instance);

        invalidator.Invalidate();
    }
}
