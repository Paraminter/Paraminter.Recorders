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
        var result = Record.Exception(() => Target<object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsRepresentation()
    {
        var result = Target(Mock.Of<object>());

        Assert.NotNull(result);
    }

    private IRecordArgumentExistenceCommand<TParameter> Target<TParameter>(
        TParameter parameter)
    {
        return Fixture.Sut.Create(parameter);
    }
}
