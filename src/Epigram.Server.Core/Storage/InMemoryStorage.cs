using System.Collections.Concurrent;

namespace Epigram.Server.Core.Storage
{
    public class InMemoryStorage : IStorageStrategy
    {
        public ISpaceStorage Space { get; set; } = new SpaceMemoryStorage();

        public class SpaceMemoryStorage : ConcurrentDictionary<string, SpaceRef>, ISpaceStorage
        {
            public SpaceRef GetOrAdd(string id)
            {
                var justCreated = false;
                var value = GetOrAdd(id, eyed =>
                {
                    justCreated = true;
                    return new SpaceRef { Id = eyed, Status = Status.Created };
                });

                this[id].Status = justCreated ? Status.Created : Status.Available;
                return (SpaceRef)value.Clone();
            }
        }
    }
}