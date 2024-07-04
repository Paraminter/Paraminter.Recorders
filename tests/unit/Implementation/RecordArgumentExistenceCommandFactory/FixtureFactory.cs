namespace Paraminter.Recorders;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        RecordArgumentExistenceCommandFactory sut = new();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IRecordArgumentExistenceCommandFactory Sut;

        public Fixture(
            IRecordArgumentExistenceCommandFactory sut)
        {
            Sut = sut;
        }

        IRecordArgumentExistenceCommandFactory IFixture.Sut => Sut;
    }
}
