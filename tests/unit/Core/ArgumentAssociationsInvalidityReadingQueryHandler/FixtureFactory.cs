namespace Paraminter.Invalidation;

using Moq;

using Paraminter.Cqs;
using Paraminter.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture<TQuery> Create<TQuery>()
        where TQuery : IQuery
    {
        Mock<IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>> invalidityReaderMock = new();

        var sut = new ArgumentAssociationsInvalidityReadingQueryHandler<TQuery>(invalidityReaderMock.Object);

        return new Fixture<TQuery>(sut, invalidityReaderMock);
    }

    private sealed class Fixture<TQuery>
        : IFixture<TQuery>
        where TQuery : IQuery
    {
        private readonly IQueryHandler<TQuery, bool> Sut;

        private readonly Mock<IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>> InvalidityReaderMock;

        public Fixture(
            IQueryHandler<TQuery, bool> sut,
            Mock<IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>> invalidityReaderMock)
        {
            Sut = sut;

            InvalidityReaderMock = invalidityReaderMock;
        }

        IQueryHandler<TQuery, bool> IFixture<TQuery>.Sut => Sut;

        Mock<IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool>> IFixture<TQuery>.InvalidityReaderMock => InvalidityReaderMock;
    }
}
