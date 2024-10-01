namespace Paraminter.Processing.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture<TQuery, TResponse> Create<TQuery, TResponse>()
        where TQuery : IQuery
    {
        Mock<IQueryHandler<IIsProcessInvalidatedQuery, TResponse>> invalidityReaderMock = new();

        var sut = new ProcessInvalidityReadingQueryHandler<TQuery, TResponse>(invalidityReaderMock.Object);

        return new Fixture<TQuery, TResponse>(sut, invalidityReaderMock);
    }

    private sealed class Fixture<TQuery, TResponse>
        : IFixture<TQuery, TResponse>
        where TQuery : IQuery
    {
        private readonly IQueryHandler<TQuery, TResponse> Sut;

        private readonly Mock<IQueryHandler<IIsProcessInvalidatedQuery, TResponse>> InvalidityReaderMock;

        public Fixture(
            IQueryHandler<TQuery, TResponse> sut,
            Mock<IQueryHandler<IIsProcessInvalidatedQuery, TResponse>> invalidityReaderMock)
        {
            Sut = sut;

            InvalidityReaderMock = invalidityReaderMock;
        }

        IQueryHandler<TQuery, TResponse> IFixture<TQuery, TResponse>.Sut => Sut;

        Mock<IQueryHandler<IIsProcessInvalidatedQuery, TResponse>> IFixture<TQuery, TResponse>.InvalidityReaderMock => InvalidityReaderMock;
    }
}
