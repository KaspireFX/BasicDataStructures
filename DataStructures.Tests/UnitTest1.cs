using NUnit.Framework;
using DataStructures.Queues;

namespace Tests
{
    public class Tests
    {
        private static LinkedQueue<string> Queue2;

        [SetUp]
        public void Setup()
        {
            Queue2 = new LinkedQueue<string>();
            Queue2.Enqueue("Bob");
        }

        [Test]
        public void Test1() {
            Assert.AreEqual("Bob", Queue2.Dequeue());
        }

        [Test]
        public void Test2() {
            Queue2.Dequeue();
            Assert.AreEqual(0, Queue2.NumOfElements);
        }

        [Test]
        public void Test3() {
            Queue2.Dequeue();
            Queue2.Enqueue("Joey");
            Assert.AreEqual("Joey", Queue2.GetFront());
        }

        [Test]
        public void Test4()
        {
            Queue2.Clear();
            Assert.True(Queue2.IsEmpty());
        }
    }
}