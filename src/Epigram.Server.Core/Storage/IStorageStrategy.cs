namespace Epigram.Server.Core.Storage
{
    public interface IStorageStrategy
    {
        ISpaceStorage Space { get; }
    }
}