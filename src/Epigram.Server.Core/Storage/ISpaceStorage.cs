namespace Epigram.Server.Core.Storage
{
    public interface ISpaceStorage
    {
        SpaceRef GetOrAdd(string id);
    }
}