using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Epigram.Server.Core.Test.Unit
{
    [TestFixture]
    public class EpigramServerTests
    {
        [Test]
        public void Configure_HandsClientActiveConfigurationToManipulate()
        {
            var server = new EpigramServer();

            EpigramConfiguration activeConfiguration = null;
            server.Configure(x => activeConfiguration = x);

            Assert.That(activeConfiguration, Is.Not.Null);
        }
    }
}
