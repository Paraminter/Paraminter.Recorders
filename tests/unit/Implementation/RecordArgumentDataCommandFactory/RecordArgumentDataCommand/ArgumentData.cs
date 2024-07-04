namespace Paraminter.Recorders.RecordArgumentExistenceCommand;

using Xunit;

public sealed class ArgumentData
{
    [Fact]
    public void ReturnsArgumentData()
    {
        var fixture = FixtureFactory.Create<object, object>();

        var result = Target(fixture);

        Assert.Equal(fixture.ArgumentDataMock.Object, result);
    }

    private static TArgumentData Target<TParameter, TArgumentData>(
        IFixture<TParameter, TArgumentData> fixture)
        where TParameter : class
        where TArgumentData : class
    {
        return fixture.Sut.ArgumentData;
    }
}
