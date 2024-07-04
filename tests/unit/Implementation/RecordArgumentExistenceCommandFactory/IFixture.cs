namespace Paraminter.Recorders;

internal interface IFixture
{
    public abstract IRecordArgumentExistenceCommandFactory Sut { get; }
}
