namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal interface IFixture
{
    public abstract IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> Sut { get; }

    public abstract Mock<IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus>> InvalidityStatusProviderMock { get; }
}
