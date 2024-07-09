namespace Paraminter.Recorders;

using Moq;

using System;
using System.Linq.Expressions;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullParameter_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<object, object>();

        var result = Record.Exception(() => Target(fixture, null!, Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullArgumentData_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<object, object>();

        var result = Record.Exception(() => Target(fixture, Mock.Of<object>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_HandlesCommand()
    {
        var fixture = FixtureFactory.Create<object, object>();

        var parameter = Mock.Of<object>();
        var argumentData = Mock.Of<object>();

        Target(fixture, parameter, argumentData);

        fixture.DelegatingCoordinatorMock.Verify((coordinator) => coordinator.Handle(It.Is(MatchCommandCreationDelegate(parameter, argumentData))), Times.Once);
    }

    private static Expression<Func<DCreateCommand<IRecordArgumentDataCommand<object, object>, IRecordArgumentDataCommandFactory>, bool>> MatchCommandCreationDelegate<TParameter, TArgumentData>(
        TParameter parameter,
        TArgumentData argumentData)
    {
        return (commandCreationDelegate) => VerifyCommandCreationDelegate(commandCreationDelegate, parameter!, argumentData!);
    }

    private static bool VerifyCommandCreationDelegate<TParameter, TArgumentData>(
        DCreateCommand<IRecordArgumentDataCommand<TParameter, TArgumentData>, IRecordArgumentDataCommandFactory> commandCreationDelegate,
        TParameter parameter,
        TArgumentData argumentData)
    {
        var command = Mock.Of<IRecordArgumentDataCommand<TParameter, TArgumentData>>();

        Mock<IRecordArgumentDataCommandFactory> commandFactoryMock = new();

        commandFactoryMock.Setup((factory) => factory.Create(parameter, argumentData)).Returns(command);

        var result = commandCreationDelegate(commandFactoryMock.Object);

        return ReferenceEquals(result, command);
    }

    private static void Target<TParameter, TArgumentData>(
        IFixture<TParameter, TArgumentData> fixture,
        TParameter parameter,
        TArgumentData argumentData)
    {
        fixture.Sut.Handle(parameter, argumentData);
    }
}
