using System;

namespace Epigram.Server.Core
{
    public class EpigramServer
    {
        private readonly EpigramConfiguration _configuration = new EpigramConfiguration();

        public void Configure(Action<EpigramConfiguration> configurationAction)
        {
            configurationAction(_configuration);
        }
    }
}
