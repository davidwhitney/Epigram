using Epigram.Server.Core.Storage;
using NUnit.Framework;

namespace Epigram.Server.Core.Test.Unit.Storage
{
    [TestFixture]
    public class InMemoryStorageTests
    {
        private InMemoryStorage _inMem;

        [SetUp]
        public void SetUp()
        {
            _inMem = new InMemoryStorage();
        }

        [Test]
        public void Space_NoSpaceExists_ReturnsNewSpace()
        {
            var space = _inMem.Space.GetOrAdd("id");

            Assert.That(space.Id, Is.EqualTo("id"));
            Assert.That(space.Status, Is.EqualTo(Status.Created));
        }

        [Test]
        public void Space_SpaceExists_ReturnsSpace()
        {
            _inMem.Space.GetOrAdd("id");
            var result = _inMem.Space.GetOrAdd("id");

            Assert.That(result.Status, Is.EqualTo(Status.Available));
        }
    }
}