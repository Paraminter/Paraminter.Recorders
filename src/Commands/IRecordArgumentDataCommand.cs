namespace Paraminter.Recorders.Commands;

using Paraminter.Commands;

/// <summary>Represents a command to record data about the argument of a parameter.</summary>
/// <typeparam name="TRecord">The type representing the record to which data about the argument is recorded.</typeparam>
/// <typeparam name="TParameter">The type representing the parameter.</typeparam>
/// <typeparam name="TArgumentData">The type representing data about the argument.</typeparam>
public interface IRecordArgumentDataCommand<out TRecord, out TParameter, out TArgumentData>
    : ICommand
{
    /// <summary>The record to which data about the argument is recorded.</summary>
    public abstract TRecord DataRecord { get; }

    /// <summary>The parameter associated with the argument.</summary>
    public abstract TParameter Parameter { get; }

    /// <summary>The data about the argument.</summary>
    public abstract TArgumentData ArgumentData { get; }
}
