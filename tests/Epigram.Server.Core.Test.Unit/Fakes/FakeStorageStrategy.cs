using Epigram.Server.Core.Storage;

namespace Epigram.Server.Core.Test.Unit.Fakes
{
    public class FakeStorageStrategy : IStorageStrategy, ISpaceStorage
    {
        public string LastRequestedId { get; set; }
        public ISpaceStorage Space => this;

        SpaceRef ISpaceStorage.GetOrAdd(string id)
        {
            LastRequestedId = id;
            return new SpaceRef { Id = id };
        }
    }
}