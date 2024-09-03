namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Queries;

internal interface IFixture
{
    public abstract IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> Sut { get; }

    public abstract Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> StateReaderMock { get; }
}
