namespace Paraminter.Recorders;

using System;

/// <inheritdoc cref="IRecordArgumentDataCommandCoordinator{TParameter, TArgumentData}"/>
public sealed class RecordArgumentDataCommandCoordinator<TParameter, TArgumentData>
    : IRecordArgumentDataCommandCoordinator<TParameter, TArgumentData>
{
    private readonly ICommandCoordinator<IRecordArgumentDataCommand<TParameter, TArgumentData>, IRecordArgumentDataCommandFactory> DelegatingCoordinator;

    /// <summary>Instantiates a <see cref="RecordArgumentDataCommandCoordinator{TParameter, TArgumentData}"/>, coordinating creation of handling of <see cref="IRecordArgumentDataCommand{TParameter, TArgumentData}"/>.</summary>
    /// <param name="delegatingCoordinator">Coordinates creation and handling of commands.</param>
    public RecordArgumentDataCommandCoordinator(
        ICommandCoordinator<IRecordArgumentDataCommand<TParameter, TArgumentData>, IRecordArgumentDataCommandFactory> delegatingCoordinator)
    {
        DelegatingCoordinator = delegatingCoordinator ?? throw new ArgumentNullException(nameof(delegatingCoordinator));
    }

    void IRecordArgumentDataCommandCoordinator<TParameter, TArgumentData>.Handle(
        TParameter parameter,
        TArgumentData argumentData)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException(nameof(parameter));
        }

        if (argumentData is null)
        {
            throw new ArgumentNullException(nameof(argumentData));
        }

        DelegatingCoordinator.Handle(createCommand);

        IRecordArgumentDataCommand<TParameter, TArgumentData> createCommand(
            IRecordArgumentDataCommandFactory factory)
        {
            return factory.Create(parameter, argumentData);
        }
    }
}
