namespace Paraminter.Invalidation.Models;

/// <summary>Handles the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidity
    : IArgumentAssociationsInvalidity
{
    private readonly IArgumentAssociationsInvalidityStatus Status;
    private readonly IArgumentAssociationsInvalidator Invalidator;

    /// <summary>Instantiates a handler of the invalidity of the made associations between arguments and parameters.</summary>
    public ArgumentAssociationsInvalidity()
    {
        var status = new ArgumentAssociationsInvalidityStatus();

        Status = status;
        Invalidator = new ArgumentAssociationsInvalidator(status);
    }

    IArgumentAssociationsInvalidityStatus IArgumentAssociationsInvalidity.Status => Status;
    IArgumentAssociationsInvalidator IArgumentAssociationsInvalidity.Invalidator => Invalidator;

    private sealed class ArgumentAssociationsInvalidityStatus
        : IArgumentAssociationsInvalidityStatus
    {
        private bool HaveBeenInvalidated = false;

        public ArgumentAssociationsInvalidityStatus() { }

        public void Invalidate()
        {
            HaveBeenInvalidated = true;
        }

        bool IArgumentAssociationsInvalidityStatus.HaveBeenInvalidated => HaveBeenInvalidated;
    }

    private sealed class ArgumentAssociationsInvalidator
        : IArgumentAssociationsInvalidator
    {
        private readonly ArgumentAssociationsInvalidityStatus Status;

        public ArgumentAssociationsInvalidator(
            ArgumentAssociationsInvalidityStatus status)
        {
            Status = status;
        }

        void IArgumentAssociationsInvalidator.Invalidate() => Status.Invalidate();
    }
}
