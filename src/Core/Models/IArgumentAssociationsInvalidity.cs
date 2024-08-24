﻿namespace Paraminter.Invalidation.Models;

/// <summary>Handles the invalidity of the made associations between arguments and parameters.</summary>
public interface IArgumentAssociationsInvalidity
{
    /// <summary>Represents the invalidity of the made associations between arguments and parameters.</summary>
    public abstract IArgumentAssociationsInvalidityStatus Status { get; }

    /// <summary>Invalidates the made associations between arguments and parameters.</summary>
    public abstract IArgumentAssociationsInvalidator Invalidator { get; }
}
