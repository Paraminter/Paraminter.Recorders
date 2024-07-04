namespace Paraminter.Recorders.RecordArgumentExistenceCommand;

using Xunit;

public sealed class Parameter
{
    [Fact]
    public void ReturnsParameter()
    {
        var fixture = FixtureFactory.Create<object, object>();

        var result = Target(fixture);

        Assert.Equal(fixture.ParameterMock.Object, result);
    }

    private static TParameter Target<TParameter, TArgumentData>(
        IFixture<TParameter, TArgumentData> fixture)
        where TParameter : class
        where TArgumentData : class
    {
        return fixture.Sut.Parameter;
    }
}
