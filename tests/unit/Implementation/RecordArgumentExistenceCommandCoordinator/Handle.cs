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
        var fixture = FixtureFactory.Create<object>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_HandlesCommand()
    {
        var fixture = FixtureFactory.Create<object>();

        var parameter = Mock.Of<object>();

        Target(fixture, parameter);

        fixture.DelegatingCoordinatorMock.Verify((coordinator) => coordinator.Handle(It.Is(MatchCommandCreationDelegate(parameter))), Times.Once);
    }

    private static Expression<Func<DCreateCommand<IRecordArgumentExistenceCommand<object>, IRecordArgumentExistenceCommandFactory>, bool>> MatchCommandCreationDelegate<TParameter>(
        TParameter parameter)
    {
        return (commandCreationDelegate) => VerifyCommandCreationDelegate(commandCreationDelegate, parameter!);
    }

    private static bool VerifyCommandCreationDelegate<TParameter>(
        DCreateCommand<IRecordArgumentExistenceCommand<TParameter>, IRecordArgumentExistenceCommandFactory> commandCreationDelegate,
        TParameter parameter)
    {
        var command = Mock.Of<IRecordArgumentExistenceCommand<TParameter>>();

        Mock<IRecordArgumentExistenceCommandFactory> commandFactoryMock = new();

        commandFactoryMock.Setup((factory) => factory.Create(parameter)).Returns(command);

        var result = commandCreationDelegate(commandFactoryMock.Object);

        return ReferenceEquals(result, command);
    }

    private static void Target<TParameter>(
        IFixture<TParameter> fixture,
        TParameter parameter)
    {
        fixture.Sut.Handle(parameter);
    }
}
