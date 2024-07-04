namespace Paraminter.Recorders.RecordArgumentExistenceCommand;

using Moq;

internal interface IFixture<TParameter>
    where TParameter : class
{
    public abstract IRecordArgumentExistenceCommand<TParameter> Sut { get; }

    public abstract Mock<TParameter> ParameterMock { get; }
}
