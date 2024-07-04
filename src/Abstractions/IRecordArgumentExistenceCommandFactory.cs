namespace Paraminter.Recorders;

/// <summary>Handles creation of <see cref="IRecordArgumentExistenceCommand{TParameter}"/>.</summary>
public interface IRecordArgumentExistenceCommandFactory
{
    /// <summary>Creates a <see cref="IRecordArgumentExistenceCommand{TParameter}"/>.</summary>
    /// <typeparam name="TParameter">The type representing the parameter.</typeparam>
    /// <param name="parameter">The parameter associated with the argument.</param>
    /// <returns>The created <see cref="IRecordArgumentExistenceCommand{TParameter}"/>.</returns>
    public abstract IRecordArgumentExistenceCommand<TParameter> Create<TParameter>(
        TParameter parameter);
}
