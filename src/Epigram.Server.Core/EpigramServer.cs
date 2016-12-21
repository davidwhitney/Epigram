using System;
using Epigram.Server.Core.Storage;

namespace Epigram.Server.Core
{
    public class EpigramServer
    {
        private readonly EpigramConfiguration _configuration = new EpigramConfiguration();

        public void Configure(Action<EpigramConfiguration> configurationAction)
        {
            configurationAction(_configuration);
        }

        public ISpaceStorage Spaces => _configuration.StorageStrategy.Space;
    }
}