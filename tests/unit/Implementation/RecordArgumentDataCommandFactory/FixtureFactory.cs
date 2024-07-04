namespace Paraminter.Recorders;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        RecordArgumentDataCommandFactory sut = new();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IRecordArgumentDataCommandFactory Sut;

        public Fixture(
            IRecordArgumentDataCommandFactory sut)
        {
            Sut = sut;
        }

        IRecordArgumentDataCommandFactory IFixture.Sut => Sut;
    }
}
