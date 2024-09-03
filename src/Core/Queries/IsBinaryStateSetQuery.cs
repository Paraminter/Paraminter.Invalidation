namespace Paraminter.Invalidation.Queries;

using Paraminter.BinaryState.Queries;

internal sealed class IsBinaryStateSetQuery
    : IIsBinaryStateSetQuery
{
    public static IIsBinaryStateSetQuery Instance { get; } = new IsBinaryStateSetQuery();

    private IsBinaryStateSetQuery() { }
}
