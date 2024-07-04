namespace Paraminter.Recorders;

using System;

/// <inheritdoc cref="IRecordArgumentDataCommandFactory"/>
public sealed class RecordArgumentDataCommandFactory
    : IRecordArgumentDataCommandFactory
{
    /// <summary>Instantiates a <see cref="RecordArgumentDataCommandFactory"/>, handling creation of <see cref="IRecordArgumentDataCommand{TParameter, TArgumentData}"/>.</summary>
    public RecordArgumentDataCommandFactory() { }

    IRecordArgumentDataCommand<TParameter, TArgumentData> IRecordArgumentDataCommandFactory.Create<TParameter, TArgumentData>(
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

        return new RecordArgumentDataCommand<TParameter, TArgumentData>(parameter, argumentData);
    }

    private sealed class RecordArgumentDataCommand<TParameter, TArgumentData>
        : IRecordArgumentDataCommand<TParameter, TArgumentData>
    {
        private readonly TParameter Parameter;
        private readonly TArgumentData ArgumentData;

        public RecordArgumentDataCommand(
            TParameter parameter,
            TArgumentData argumentData)
        {
            Parameter = parameter;
            ArgumentData = argumentData;
        }

        TParameter IRecordArgumentDataCommand<TParameter, TArgumentData>.Parameter => Parameter;
        TArgumentData IRecordArgumentDataCommand<TParameter, TArgumentData>.ArgumentData => ArgumentData;
    }
}
