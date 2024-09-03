namespace Paraminter.Invalidation;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;
using Paraminter.Invalidation.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> stateReaderMock = new();

        var sut = new ArgumentAssociationsInvalidityReader(stateReaderMock.Object);

        return new Fixture(sut, stateReaderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> Sut;

        private readonly Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> StateReaderMock;

        public Fixture(
            IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> sut,
            Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> stateReaderMock)
        {
            Sut = sut;

            StateReaderMock = stateReaderMock;
        }

        IQueryHandler<IAreArgumentAssociationsInvalidatedQuery, bool> IFixture.Sut => Sut;

        Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> IFixture.StateReaderMock => StateReaderMock;
    }
}
