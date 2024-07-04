namespace Paraminter.Recorders.RecordArgumentExistenceCommand;

using Moq;

internal interface IFixture<TParameter, TArgumentData>
    where TParameter : class
    where TArgumentData : class
{
    public abstract IRecordArgumentDataCommand<TParameter, TArgumentData> Sut { get; }

    public abstract Mock<TParameter> ParameterMock { get; }
    public abstract Mock<TArgumentData> ArgumentDataMock { get; }
}
