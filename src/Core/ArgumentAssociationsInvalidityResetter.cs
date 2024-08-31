namespace Paraminter.Invalidation;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

using System;

/// <summary>Resets the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidityResetter
    : ICommandHandler<IResetArgumentAssociationsInvalidityCommand>
{
    private readonly IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter> InvalidityResetterProvider;

    /// <summary>Instantiates a resetter of the invalidity of the made asssociations between arguments and parameters.</summary>
    /// <param name="invalidityResetterProvider">Provides a resetter of the invalidity of the made associations between arguments and parameters.</param>
    public ArgumentAssociationsInvalidityResetter(
        IQueryHandler<IGetArgumentAssociationsInvalidityResetterQuery, IArgumentAssociationsInvalidityResetter> invalidityResetterProvider)
    {
        InvalidityResetterProvider = invalidityResetterProvider ?? throw new ArgumentNullException(nameof(invalidityResetterProvider));
    }

    void ICommandHandler<IResetArgumentAssociationsInvalidityCommand>.Handle(
        IResetArgumentAssociationsInvalidityCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var invalidityResetter = InvalidityResetterProvider.Handle(GetArgumentAssociationsInvalidityResetterQuery.Instance);

        invalidityResetter.Reset();
    }
}
