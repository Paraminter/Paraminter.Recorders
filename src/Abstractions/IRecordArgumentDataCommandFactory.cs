namespace Paraminter.Recorders;

/// <summary>Handles creation of <see cref="IRecordArgumentDataCommand{TParameter, TArgumentData}"/>.</summary>
public interface IRecordArgumentDataCommandFactory
{
    /// <summary>Creates a <see cref="IRecordArgumentDataCommand{TParameter, TArgumentData}"/>.</summary>
    /// <typeparam name="TParameter">The type representing the parameter.</typeparam>
    /// <typeparam name="TArgumentData">The type representing data about the argument.</typeparam>
    /// <param name="parameter">The parameter associated with the argument.</param>
    /// <param name="argumentData">The data about the argument.</param>
    /// <returns>The created <see cref="IRecordArgumentDataCommand{TParameter, TArgumentData}"/>.</returns>
    public abstract IRecordArgumentDataCommand<TParameter, TArgumentData> Create<TParameter, TArgumentData>(
        TParameter parameter,
        TArgumentData argumentData);
}
