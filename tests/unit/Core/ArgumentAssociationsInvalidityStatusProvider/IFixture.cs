namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Models;
using Paraminter.Invalidation.Queries;

internal interface IFixture
{
    public abstract IQueryHandler<IGetArgumentAssociationsInvalidityStatusQuery, IArgumentAssociationsInvalidityStatus> Sut { get; }

    public abstract Mock<IArgumentAssociationsInvalidityStatus> InvalidityStatusMock { get; }
}
