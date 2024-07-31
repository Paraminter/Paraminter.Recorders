namespace Paraminter.Recorders.Commands;

using Paraminter.Commands;

/// <summary>Represents a command to record the existence of an argument of a parameter.</summary>
/// <typeparam name="TRecord">The type representing the record to which data about the argument is recorded.</typeparam>
/// <typeparam name="TParameter">The type representing the parameter.</typeparam>
public interface IRecordArgumentExistenceCommand<out TRecord, out TParameter>
    : ICommand
{
    /// <summary>The record to which data about the argument is recorded.</summary>
    public abstract TRecord DataRecord { get; }

    /// <summary>The parameter associated with the argument.</summary>
    public abstract TParameter Parameter { get; }
}
