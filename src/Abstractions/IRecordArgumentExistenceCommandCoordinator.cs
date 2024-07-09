namespace Paraminter.Recorders;

/// <summary>Coordinates creation and handling of <see cref="IRecordArgumentExistenceCommand{TParameter}"/>.</summary>
/// <typeparam name="TParameter">The type representing the parameter.</typeparam>
public interface IRecordArgumentExistenceCommandCoordinator<in TParameter>
{
    /// <summary>Creates and handles a <see cref="IRecordArgumentExistenceCommand{TParameter}"/>.</summary>
    /// <param name="parameter">The parameter associated with the argument.</param>
    public abstract void Handle(
        TParameter parameter);
}
