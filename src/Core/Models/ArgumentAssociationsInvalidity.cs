namespace Paraminter.Invalidation.Models;

/// <summary>Handles the invalidity of the made associations between arguments and parameters.</summary>
public sealed class ArgumentAssociationsInvalidity
    : IArgumentAssociationsInvalidity
{
    private readonly IArgumentAssociationsInvalidityStatus Status;
    private readonly IArgumentAssociationsInvalidator Invalidator;
    private readonly IArgumentAssociationsInvalidityResetter Resetter;

    /// <summary>Instantiates a handler of the invalidity of the made associations between arguments and parameters.</summary>
    public ArgumentAssociationsInvalidity()
    {
        var status = new ArgumentAssociationsInvalidityStatus();

        Status = status;
        Invalidator = new ArgumentAssociationsInvalidator(status);
        Resetter = new ArgumentAssociationsInvalidityResetter(status);
    }

    IArgumentAssociationsInvalidityStatus IArgumentAssociationsInvalidity.Status => Status;
    IArgumentAssociationsInvalidator IArgumentAssociationsInvalidity.Invalidator => Invalidator;
    IArgumentAssociationsInvalidityResetter IArgumentAssociationsInvalidity.Resetter => Resetter;

    private sealed class ArgumentAssociationsInvalidityStatus
        : IArgumentAssociationsInvalidityStatus
    {
        private bool HaveBeenInvalidated = false;

        public ArgumentAssociationsInvalidityStatus() { }

        public void Invalidate()
        {
            HaveBeenInvalidated = true;
        }

        public void Reset()
        {
            HaveBeenInvalidated = false;
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

    private sealed class ArgumentAssociationsInvalidityResetter
        : IArgumentAssociationsInvalidityResetter
    {
        private readonly ArgumentAssociationsInvalidityStatus Status;

        public ArgumentAssociationsInvalidityResetter(
            ArgumentAssociationsInvalidityStatus status)
        {
            Status = status;
        }

        void IArgumentAssociationsInvalidityResetter.Reset() => Status.Reset();
    }
}
