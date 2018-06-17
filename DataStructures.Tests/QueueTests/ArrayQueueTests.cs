/*
Author: Jacob Chandler
File: ArrayQueueTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the ArrayQueue Data Structure class.
Date of Comment: 06:03:2018
 */

using System;
using DataStructures.Queues;
using NUnit.Framework;

namespace Tests.QueueTests {
    public class ArrayQueueTests {

        ArrayQueue<string> ArrayQueue = new ArrayQueue<string>(5);

        [SetUp]
        public void Setup() {
            ArrayQueue.Enqueue("Phil");
            ArrayQueue.Enqueue("Bob");
            ArrayQueue.Enqueue("Marry");
            ArrayQueue.Enqueue("Bobby");
        }

        [Test]
        public void GetFrontTest() {
            Assert.AreEqual("Phil", ArrayQueue.GetFront());
        }

        [Test]
        public void DequeueTest() {
            Assert.AreEqual("Phil", ArrayQueue.Dequeue());
        }

        [Test]
        public void DequeueTest2() {
            ArrayQueue.Dequeue();
            Assert.AreEqual("Bob", ArrayQueue.Dequeue());
        }

        [Test]
        public void EmptyTest() {
            ArrayQueue.Empty();
            Assert.True(ArrayQueue.IsEmpty());
        }

        [Test]
        public void EmptyQueuePopTestExc() {
            Assert.Throws<InvalidOperationException>(new TestDelegate(EmptyStackPopDel));
        }

        [Test]
        public void EmptyQueueEmptyTestExc() {
            Assert.Throws<InvalidOperationException>(new TestDelegate(EmptyStackEmptyDel));
        }

        private void EmptyStackEmptyDel() {
            ArrayQueue.Empty();
            ArrayQueue.Empty();
        }

        private void EmptyStackPopDel() {
            ArrayQueue.Empty();
            ArrayQueue.Dequeue();
        }
    }
}