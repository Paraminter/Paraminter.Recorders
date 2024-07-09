namespace Paraminter.Recorders;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TParameter, TArgumentData> Create<TParameter, TArgumentData>()
    {
        Mock<ICommandCoordinator<IRecordArgumentDataCommand<TParameter, TArgumentData>, IRecordArgumentDataCommandFactory>> delegatingCoordinatorMock = new();

        RecordArgumentDataCommandCoordinator<TParameter, TArgumentData> sut = new(delegatingCoordinatorMock.Object);

        return new Fixture<TParameter, TArgumentData>(sut, delegatingCoordinatorMock);
    }

    private sealed class Fixture<TParameter, TArgumentData>
        : IFixture<TParameter, TArgumentData>
    {
        private readonly IRecordArgumentDataCommandCoordinator<TParameter, TArgumentData> Sut;

        private readonly Mock<ICommandCoordinator<IRecordArgumentDataCommand<TParameter, TArgumentData>, IRecordArgumentDataCommandFactory>> DelegatingCoordinatorMock;

        public Fixture(
            IRecordArgumentDataCommandCoordinator<TParameter, TArgumentData> sut,
            Mock<ICommandCoordinator<IRecordArgumentDataCommand<TParameter, TArgumentData>, IRecordArgumentDataCommandFactory>> delegatingCoordinatorMock)
        {
            Sut = sut;

            DelegatingCoordinatorMock = delegatingCoordinatorMock;
        }

        IRecordArgumentDataCommandCoordinator<TParameter, TArgumentData> IFixture<TParameter, TArgumentData>.Sut => Sut;

        Mock<ICommandCoordinator<IRecordArgumentDataCommand<TParameter, TArgumentData>, IRecordArgumentDataCommandFactory>> IFixture<TParameter, TArgumentData>.DelegatingCoordinatorMock => DelegatingCoordinatorMock;
    }
}
