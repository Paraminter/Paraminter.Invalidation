namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Queries;

internal interface IFixture<in TQuery>
    where TQuery : IQuery
{
    public abstract IQueryHandler<TQuery, bool> Sut { get; }

    public abstract Mock<IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>> InvalidityReaderMock { get; }
}
