namespace Paraminter.Recorders;

/// <summary>Represents a command to record data about the argument of a parameter.</summary>
/// <typeparam name="TParameter">The type representing the parameter.</typeparam>
/// <typeparam name="TArgumentData">The type representing data about the argument.</typeparam>
public interface IRecordArgumentDataCommand<out TParameter, out TArgumentData>
    : ICommand
{
    /// <summary>The parameter associated with the argument.</summary>
    public abstract TParameter Parameter { get; }

    /// <summary>The data about the argument.</summary>
    public abstract TArgumentData ArgumentData { get; }
}
