using NUnit.Framework;
using DataStructures.Queues;

namespace Tests
{
    public class Tests
    {
        LinkedQueue<string> Queue = new LinkedQueue<string>();

        [SetUp]
        public void Setup()
        {
            Queue.Enqueue("Bob");
            Queue.Enqueue("Phil");
            Queue.Dequeue();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("Phil", Queue.GetFront());
        }
    }
}