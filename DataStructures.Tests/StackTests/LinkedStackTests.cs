/*
Author: Jacob Chandler
File: LinkedStackTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the LinkedStack Data Structure class.
Date of Comment: 06:03:2018
 */

using System;
using DataStructures.Stacks;
using NUnit.Framework;

namespace Tests.StackTests {
    public class ListStackTests {

        LinkedStack<string> LinkedStack = new LinkedStack<string>();

        [SetUp]
        public void Setup() {
            LinkedStack.Push("Phil");
            LinkedStack.Push("Bob");
            LinkedStack.Push("Marry");
            LinkedStack.Push("Bobby");
        }

        [Test]
        public void NumOfElementsShouldBe4() {
            Assert.AreEqual(4, LinkedStack.Count);
        }

        [Test]
        public void PeekTest() {
            Assert.AreEqual("Bobby", LinkedStack.Peek());
        }

        [Test]
        public void PopTest() {
            Assert.AreEqual("Bobby", LinkedStack.Pop());
        }

        [Test]
        public void PopTest2() {
            LinkedStack.Pop();
            Assert.AreEqual("Marry", LinkedStack.Peek());
        }

        [Test]
        public void EmptyTest() {
            LinkedStack.Empty();
            Assert.True(LinkedStack.IsEmpty());
        }

        [Test]
        public void EmptyStackPopTestExc() {
            Assert.Throws<InvalidOperationException>(new TestDelegate(EmptyStackPopDel));
        }

        [Test]
        public void EmptyStackEmptyTestExc() {
            Assert.Throws<InvalidOperationException>(new TestDelegate(EmptyStackEmptyDel));
        }

        private void EmptyStackEmptyDel() {
            LinkedStack.Empty();
            LinkedStack.Empty();
        }

        private void EmptyStackPopDel() {
            LinkedStack.Empty();
            LinkedStack.Pop();
        }
    }
}