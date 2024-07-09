namespace Paraminter.Recorders;

using System;

/// <inheritdoc cref="IRecordArgumentExistenceCommandCoordinator{TParameter}"/>
public sealed class RecordArgumentExistenceCommandCoordinator<TParameter>
    : IRecordArgumentExistenceCommandCoordinator<TParameter>
{
    private readonly ICommandCoordinator<IRecordArgumentExistenceCommand<TParameter>, IRecordArgumentExistenceCommandFactory> DelegatingCoordinator;

    /// <summary>Instantiates a <see cref="RecordArgumentExistenceCommandCoordinator{TParameter}"/>, coordinating creation of handling of <see cref="IRecordArgumentExistenceCommand{TParameter}"/>.</summary>
    /// <param name="delegatingCoordinator">Coordinates creation and handling of commands.</param>
    public RecordArgumentExistenceCommandCoordinator(
        ICommandCoordinator<IRecordArgumentExistenceCommand<TParameter>, IRecordArgumentExistenceCommandFactory> delegatingCoordinator)
    {
        DelegatingCoordinator = delegatingCoordinator ?? throw new ArgumentNullException(nameof(delegatingCoordinator));
    }

    void IRecordArgumentExistenceCommandCoordinator<TParameter>.Handle(
        TParameter parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException(nameof(parameter));
        }

        DelegatingCoordinator.Handle(createCommand);

        IRecordArgumentExistenceCommand<TParameter> createCommand(
            IRecordArgumentExistenceCommandFactory factory)
        {
            return factory.Create(parameter);
        }
    }
}
