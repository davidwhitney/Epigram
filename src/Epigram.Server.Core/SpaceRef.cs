using System;

namespace Epigram.Server.Core
{
    public class SpaceRef : ICloneable
    {
        public string Id { get; set; }

        public Status Status { get; set; }

        public object Clone()
        {
            return new SpaceRef {Id = Id, Status = Status};
        }
    }
}