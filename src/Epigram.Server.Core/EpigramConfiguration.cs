using Epigram.Server.Core.Storage;

namespace Epigram.Server.Core
{
    public class EpigramConfiguration
    {
        public IStorageStrategy StorageStrategy { get; set; } = new InMemoryStorage();
    }
}