namespace Paraminter.Processing.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Queries;

internal interface IFixture<in TQuery, TResponse>
    where TQuery : IQuery
{
    public abstract IQueryHandler<TQuery, TResponse> Sut { get; }

    public abstract Mock<IQueryHandler<IIsProcessInvalidatedQuery, TResponse>> InvalidityReaderMock { get; }
}
