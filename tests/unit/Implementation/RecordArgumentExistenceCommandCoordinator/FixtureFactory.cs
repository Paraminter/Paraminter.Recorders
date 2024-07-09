namespace Paraminter.Recorders;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TParameter> Create<TParameter>()
    {
        Mock<ICommandCoordinator<IRecordArgumentExistenceCommand<TParameter>, IRecordArgumentExistenceCommandFactory>> delegatingCoordinatorMock = new();

        RecordArgumentExistenceCommandCoordinator<TParameter> sut = new(delegatingCoordinatorMock.Object);

        return new Fixture<TParameter>(sut, delegatingCoordinatorMock);
    }

    private sealed class Fixture<TParameter>
        : IFixture<TParameter>
    {
        private readonly IRecordArgumentExistenceCommandCoordinator<TParameter> Sut;

        private readonly Mock<ICommandCoordinator<IRecordArgumentExistenceCommand<TParameter>, IRecordArgumentExistenceCommandFactory>> DelegatingCoordinatorMock;

        public Fixture(
            IRecordArgumentExistenceCommandCoordinator<TParameter> sut,
            Mock<ICommandCoordinator<IRecordArgumentExistenceCommand<TParameter>, IRecordArgumentExistenceCommandFactory>> delegatingCoordinatorMock)
        {
            Sut = sut;

            DelegatingCoordinatorMock = delegatingCoordinatorMock;
        }

        IRecordArgumentExistenceCommandCoordinator<TParameter> IFixture<TParameter>.Sut => Sut;

        Mock<ICommandCoordinator<IRecordArgumentExistenceCommand<TParameter>, IRecordArgumentExistenceCommandFactory>> IFixture<TParameter>.DelegatingCoordinatorMock => DelegatingCoordinatorMock;
    }
}
