namespace Paraminter.Recorders;

/// <summary>Records data about the arguments of parameters.</summary>
/// <typeparam name="TParameter">The type representing the parameters.</typeparam>
/// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
public interface IArgumentDataRecorder<in TParameter, in TArgumentData>
{
    /// <summary>Attempts to record data about the argument of a parameter.</summary>
    /// <param name="parameter">The parameter associated with the argument.</param>
    /// <param name="argumentData">The data about the argument.</param>
    /// <returns>A <see cref="bool"/> indicating whether the attempt was successful.</returns>
    public abstract bool TryRecordData(
        TParameter parameter,
        TArgumentData argumentData);
}
