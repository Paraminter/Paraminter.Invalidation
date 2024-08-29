namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Commands;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal interface IFixture
{
    public abstract ICommandHandler<IInvalidateArgumentAssociationsCommand> Sut { get; }

    public abstract Mock<IQueryHandler<IGetArgumentAssociationsInvalidatorQuery, IArgumentAssociationsInvalidator>> InvalidatorProviderMock { get; }
}
