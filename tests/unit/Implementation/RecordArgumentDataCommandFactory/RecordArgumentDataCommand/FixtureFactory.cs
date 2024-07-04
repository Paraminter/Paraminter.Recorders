namespace Paraminter.Recorders.RecordArgumentExistenceCommand;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TParameter, TArgumentData> Create<TParameter, TArgumentData>()
        where TParameter : class
        where TArgumentData : class
    {
        Mock<TParameter> parameterMock = new();
        Mock<TArgumentData> argumentDataMock = new();

        IRecordArgumentDataCommandFactory factory = new RecordArgumentDataCommandFactory();

        var sut = factory.Create(parameterMock.Object, argumentDataMock.Object);

        return new Fixture<TParameter, TArgumentData>(sut, parameterMock, argumentDataMock);
    }

    private sealed class Fixture<TParameter, TArgumentData>
        : IFixture<TParameter, TArgumentData>
        where TParameter : class
        where TArgumentData : class
    {
        private readonly IRecordArgumentDataCommand<TParameter, TArgumentData> Sut;

        private readonly Mock<TParameter> ParameterMock;
        private readonly Mock<TArgumentData> ArgumentDataMock;

        public Fixture(
            IRecordArgumentDataCommand<TParameter, TArgumentData> sut,
            Mock<TParameter> parameterMock,
            Mock<TArgumentData> argumentDataMock)
        {
            Sut = sut;

            ParameterMock = parameterMock;
            ArgumentDataMock = argumentDataMock;
        }

        IRecordArgumentDataCommand<TParameter, TArgumentData> IFixture<TParameter, TArgumentData>.Sut => Sut;

        Mock<TParameter> IFixture<TParameter, TArgumentData>.ParameterMock => ParameterMock;
        Mock<TArgumentData> IFixture<TParameter, TArgumentData>.ArgumentDataMock => ArgumentDataMock;
    }
}
