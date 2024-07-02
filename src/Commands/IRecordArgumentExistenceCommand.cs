namespace Paraminter.Recorders;

/// <summary>Represents a command to record the existence of an argument of a parameter.</summary>
/// <typeparam name="TParameter">The type representing the parameter.</typeparam>
public interface IRecordArgumentExistenceCommand<out TParameter>
    : ICommand
{
    /// <summary>The parameter associated with the argument.</summary>
    public abstract TParameter Parameter { get; }
}
