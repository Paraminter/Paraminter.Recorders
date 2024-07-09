namespace Paraminter.Recorders;

/// <summary>Coordinates creation and handling of <see cref="IRecordArgumentDataCommand{TParameter, TArgumentData}"/>.</summary>
/// <typeparam name="TParameter">The type representing the parameter.</typeparam>
/// <typeparam name="TArgumentData">The type representing data about the argument.</typeparam>
public interface IRecordArgumentDataCommandCoordinator<in TParameter, in TArgumentData>
{
    /// <summary>Creates and handles a <see cref="IRecordArgumentDataCommand{TParameter, TArgumentData}"/>.</summary>
    /// <param name="parameter">The parameter associated with the argument.</param>
    /// <param name="argumentData">The data about the argument.</param>
    public abstract void Handle(
        TParameter parameter,
        TArgumentData argumentData);
}
