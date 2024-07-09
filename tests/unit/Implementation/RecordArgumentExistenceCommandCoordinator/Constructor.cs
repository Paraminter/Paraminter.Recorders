namespace Paraminter.Recorders;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullDelegatingCoordinator_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsCoordinator()
    {
        var result = Target(Mock.Of<ICommandCoordinator<IRecordArgumentExistenceCommand<object>, IRecordArgumentExistenceCommandFactory>>());

        Assert.NotNull(result);
    }

    private static RecordArgumentExistenceCommandCoordinator<TParameter> Target<TParameter>(
        ICommandCoordinator<IRecordArgumentExistenceCommand<TParameter>, IRecordArgumentExistenceCommandFactory> delegatingCoordinator)
    {
        return new RecordArgumentExistenceCommandCoordinator<TParameter>(delegatingCoordinator);
    }
}
