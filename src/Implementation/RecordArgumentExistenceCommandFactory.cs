namespace Paraminter.Recorders;

using System;

/// <inheritdoc cref="IRecordArgumentExistenceCommandFactory"/>
public sealed class RecordArgumentExistenceCommandFactory
    : IRecordArgumentExistenceCommandFactory
{
    /// <summary>Instantiates a <see cref="RecordArgumentExistenceCommandFactory"/>, handling creation of <see cref="IRecordArgumentExistenceCommand{TParameter}"/>.</summary>
    public RecordArgumentExistenceCommandFactory() { }

    IRecordArgumentExistenceCommand<TParameter> IRecordArgumentExistenceCommandFactory.Create<TParameter>(
        TParameter parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException(nameof(parameter));
        }

        return new RecordArgumentExistenceCommand<TParameter>(parameter);
    }

    private sealed class RecordArgumentExistenceCommand<TParameter>
        : IRecordArgumentExistenceCommand<TParameter>
    {
        private readonly TParameter Parameter;

        public RecordArgumentExistenceCommand(
            TParameter parameter)
        {
            Parameter = parameter;
        }

        TParameter IRecordArgumentExistenceCommand<TParameter>.Parameter => Parameter;
    }
}
