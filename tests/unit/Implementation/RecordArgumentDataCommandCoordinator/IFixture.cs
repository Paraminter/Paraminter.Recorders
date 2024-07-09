namespace Paraminter.Recorders;

using Moq;

internal interface IFixture<TParameter, TArgumentData>
{
    public abstract IRecordArgumentDataCommandCoordinator<TParameter, TArgumentData> Sut { get; }

    public abstract Mock<ICommandCoordinator<IRecordArgumentDataCommand<TParameter, TArgumentData>, IRecordArgumentDataCommandFactory>> DelegatingCoordinatorMock { get; }
}
