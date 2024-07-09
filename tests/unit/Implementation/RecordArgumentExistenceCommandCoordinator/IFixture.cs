namespace Paraminter.Recorders;

using Moq;

internal interface IFixture<TParameter>
{
    public abstract IRecordArgumentExistenceCommandCoordinator<TParameter> Sut { get; }

    public abstract Mock<ICommandCoordinator<IRecordArgumentExistenceCommand<TParameter>, IRecordArgumentExistenceCommandFactory>> DelegatingCoordinatorMock { get; }
}
