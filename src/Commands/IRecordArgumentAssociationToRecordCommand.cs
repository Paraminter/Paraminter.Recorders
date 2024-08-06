namespace Paraminter.Recorders.Commands;

using Paraminter.Arguments.Models;
using Paraminter.Commands;
using Paraminter.Parameters.Models;
using Paraminter.Recorders.Models;

/// <summary>Represents a command to record an association between an argument and a parameter to a record.</summary>
/// <typeparam name="TRecord">The type representing the record to which associations between arguments and parameters are recorded.</typeparam>
/// <typeparam name="TParameter">The type representing the parameters.</typeparam>
/// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
public interface IRecordArgumentAssociationToRecordCommand<out TRecord, out TParameter, out TArgumentData>
    : ICommand
    where TRecord : IArgumentAssociationsRecord
    where TParameter : IParameter
    where TArgumentData : IArgumentData
{
    /// <summary>The record to which the association between an argument and a parameter is recorded.</summary>
    public abstract TRecord Record { get; }

    /// <summary>The parameter.</summary>
    public abstract TParameter Parameter { get; }

    /// <summary>Data about the argument.</summary>
    public abstract TArgumentData ArgumentData { get; }
}
