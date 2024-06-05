namespace Paraminter;

/// <summary>Records the existence of arguments of parameters.</summary>
/// <typeparam name="TParameter">The type representing the parameters.</typeparam>
public interface IArgumentExistenceRecorder<in TParameter>
{
    /// <summary>Attempts to record the existence of an argument of a parameter.</summary>
    /// <param name="parameter">The parameter associated with the argument.</param>
    /// <returns>A <see cref="bool"/> indicating whether the attempt was successful.</returns>
    public abstract bool TryRecordExistence(
        TParameter parameter);
}
