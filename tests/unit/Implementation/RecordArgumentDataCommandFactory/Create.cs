namespace Paraminter.Recorders;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullParameter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object>(null!, Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullArgumentData_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object>(Mock.Of<object>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsCommand()
    {
        var result = Target(Mock.Of<object>(), Mock.Of<object>());

        Assert.NotNull(result);
    }

    private IRecordArgumentDataCommand<TParameter, TArgumentData> Target<TParameter, TArgumentData>(
        TParameter parameter,
        TArgumentData argumentData)
    {
        return Fixture.Sut.Create(parameter, argumentData);
    }
}
