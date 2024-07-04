namespace Paraminter.Recorders.RecordArgumentExistenceCommand;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TParameter> Create<TParameter>()
        where TParameter : class
    {
        Mock<TParameter> parameterMock = new();

        IRecordArgumentExistenceCommandFactory factory = new RecordArgumentExistenceCommandFactory();

        var sut = factory.Create(parameterMock.Object);

        return new Fixture<TParameter>(sut, parameterMock);
    }

    private sealed class Fixture<TParameter>
        : IFixture<TParameter>
        where TParameter : class
    {
        private readonly IRecordArgumentExistenceCommand<TParameter> Sut;

        private readonly Mock<TParameter> ParameterMock;

        public Fixture(
            IRecordArgumentExistenceCommand<TParameter> sut,
            Mock<TParameter> parameterMock)
        {
            Sut = sut;

            ParameterMock = parameterMock;
        }

        IRecordArgumentExistenceCommand<TParameter> IFixture<TParameter>.Sut => Sut;

        Mock<TParameter> IFixture<TParameter>.ParameterMock => ParameterMock;
    }
}
