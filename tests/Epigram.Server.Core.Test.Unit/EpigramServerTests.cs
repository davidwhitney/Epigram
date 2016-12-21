using System.Net;
using Epigram.Server.Core.Test.Unit.Fakes;
using NUnit.Framework;

namespace Epigram.Server.Core.Test.Unit
{
    [TestFixture]
    public class EpigramServerTests
    {
        private EpigramServer _server;

        [SetUp]
        public void SetUp()
        {
            _server = new EpigramServer();
        }

        [Test]
        public void Configure_HandsClientActiveConfigurationToManipulate()
        {
            var server = new EpigramServer();

            EpigramConfiguration activeConfiguration = null;
            server.Configure(x => activeConfiguration = x);

            Assert.That(activeConfiguration, Is.Not.Null);
        }

        [Test]
        public void Spaces_IdExists_ReturnsSpaceRef()
        {
            var space = _server.Spaces("1234");

            Assert.That(space, Is.Not.Null);
            Assert.That(space.Id, Is.EqualTo("1234"));
        }

        [Test]
        public void Spaces_SameReturnedTwice_IsNotTheSameChunkOfMemory()
        {
            var space = _server.Spaces("1234");
            var space2 = _server.Spaces("1234");

            Assert.That(space, Is.Not.EqualTo(space2));
        }

        [Test]
        public void Spaces_SameReturnedTwice_ChangesDontMagicallyCascade()
        {
            var space = _server.Spaces("1234");
            var space2 = _server.Spaces("1234");

            space2.Id = "12541622";

            Assert.That(space.Id, Is.Not.EqualTo(space2.Id));
        }

        [Test]
        public void Spaces_DelegatesToStorageStrategy()
        {
            var fakeStorageStrategy = new FakeStorageStrategy();
            _server.Configure(x=> { x.StorageStrategy = fakeStorageStrategy; });

            _server.Spaces("1");

            Assert.That(fakeStorageStrategy.LastRequestedId, Is.EqualTo("1"));
        }
    }
}
