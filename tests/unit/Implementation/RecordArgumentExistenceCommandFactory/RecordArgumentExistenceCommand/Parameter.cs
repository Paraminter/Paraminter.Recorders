namespace Paraminter.Recorders.RecordArgumentExistenceCommand;

using Xunit;

public sealed class Parameter
{
    [Fact]
    public void ReturnsParameter()
    {
        var fixture = FixtureFactory.Create<object>();

        var result = Target(fixture);

        Assert.Equal(fixture.ParameterMock.Object, result);
    }

    private static TParameter Target<TParameter>(
        IFixture<TParameter> fixture)
        where TParameter : class
    {
        return fixture.Sut.Parameter;
    }
}
