namespace Paraminter.Recorders;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullDelegatingCoordinator_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsCoordinator()
    {
        var result = Target(Mock.Of<ICommandCoordinator<IRecordArgumentDataCommand<object, object>, IRecordArgumentDataCommandFactory>>());

        Assert.NotNull(result);
    }

    private static RecordArgumentDataCommandCoordinator<TParameter, TArgumentData> Target<TParameter, TArgumentData>(
        ICommandCoordinator<IRecordArgumentDataCommand<TParameter, TArgumentData>, IRecordArgumentDataCommandFactory> delegatingCoordinator)
    {
        return new RecordArgumentDataCommandCoordinator<TParameter, TArgumentData>(delegatingCoordinator);
    }
}
