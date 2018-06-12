/*
Author: Jacob Chandler
File: LinkedListTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the LinkedList Data Structure class.
Date of Comment: 06:03:2018
 */

using System;
using NUnit.Framework;
using DataStructures.Lists;

namespace Tests.ListTests
{
    public class LinkedListTests
    {

        LinkedList<string> LList = new LinkedList<string>();

        [SetUp]
        public void Setup()
        {
            LList.Add("Bill");
            LList.Add("Phil");
            LList.Add("Frank");
            LList.Add("Bobby");
        }

        [Test]
        public void GetFrontTest() {
            Assert.AreEqual("Bill", LList.IndexOf(1));
        }

        [Test]
        public void ContainsTest() {
            Assert.True(LList.Contains("Frank"));
        }

        [Test]
        public void ContainsTest2() {
            Assert.False(LList.Contains("Lil"));
        }

        [Test]
        public void EmptyTest() {
            LList.Empty();
            Assert.True(LList.IsEmpty());
        }

        [Test]
        public void RemoveTest() {
            Assert.AreEqual("Frank", LList.Remove(3));
        }

        [Test]
        public void RemoveTest2() {
            LList.Remove(1);
            Assert.AreEqual(3, LList.Count);
        }

        [Test]
        public void ReplaceTest() {
            LList.Replace(4, "Willie");
            Assert.AreEqual("Willie", LList.IndexOf(4));
        }

        [Test]
        public void ToArrayTest() {
            LList.Add(3, "Phillip");
            string[] Array = new String[] { "Bill", "Phil", "Phillip", "Frank", "Bobby" };

            Assert.AreEqual(Array, LList.ToArray());
        }

        [Test]
        public void EmptyListRemoveTestExc() {
            Assert.Throws<IndexOutOfRangeException>(new TestDelegate(EmptyListRemoveTestDel));
        }

        [Test]
        public void EmptyListEmptyTestExc() {
            Assert.Throws<InvalidOperationException>(new TestDelegate(EmptyListEmptyDel));
        }

        private void EmptyListRemoveTestDel()
        {
            LList.Empty();
            LList.Remove(2);
        }

        private void EmptyListEmptyDel() {
            LList.Empty();
            LList.Empty();
        }
    }
}