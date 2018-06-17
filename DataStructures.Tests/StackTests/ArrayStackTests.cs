/*
Author: Jacob Chandler
File: ArrayStackTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the ArrayStack Data Structure class.
Date of Comment: 06:03:2018
 */

using System;
using DataStructures.Stacks;
using NUnit.Framework;

namespace Tests.StackTests {
    public class ArrayStackTests {

        ArrayStack<string> ArrayStack = new ArrayStack<string>(5);

        [SetUp]
        public void Setup() {
            ArrayStack.Push("Phil");
            ArrayStack.Push("Bob");
            ArrayStack.Push("Marry");
            ArrayStack.Push("Bobby");
        }

        [Test]
        public void NumOfElementsShouldBe4() {
            Assert.AreEqual(4, ArrayStack.Count);
        }

        [Test]
        public void LengthShouldBe10() {
            ArrayStack.Push("Jack");
            ArrayStack.Push("Phillis");
            Assert.AreEqual(10, ArrayStack.Length);
        }

        [Test]
        public void PeekTest() {
            Assert.AreEqual("Bobby", ArrayStack.Peek());
        }

        [Test]
        public void PopTest() {
            Assert.AreEqual("Bobby", ArrayStack.Pop());
        }

        [Test]
        public void PopTest2() {
            ArrayStack.Pop();
            Assert.AreEqual("Marry", ArrayStack.Peek());
        }

        [Test]
        public void EmptyTest() {
            ArrayStack.Empty();
            Assert.True(ArrayStack.IsEmpty());
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
            ArrayStack.Empty();
            ArrayStack.Empty();
        }

        private void EmptyStackPopDel() {
            ArrayStack.Empty();
            ArrayStack.Pop();
        }
    }
}