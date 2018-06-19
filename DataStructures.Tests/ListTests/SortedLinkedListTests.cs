/*
Author: Jacob Chandler
File: SortedLinkedListTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the SortedLinkedList Data Structure class.
Date of Comment: 06:19:2018
 */

using System;
using DataStructures.Lists;
using NUnit.Framework;

namespace Tests.ListTests {
    public class SortedLinkedListTests {

        SortedLinkedList<string> LList = new SortedLinkedList<string>();

        [SetUp]
        public void Setup() {
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
            Assert.AreEqual("Phil", LList.Remove(4));
        }

        [Test]
        public void RemoveTest2() {
            LList.Remove(1);
            Assert.AreEqual(3, LList.Count);
        }

        [Test]
        public void ToArrayTest() {
            LList.Add("Phillip");
            string[] Array = new String[] { "Bill", "Bobby", "Frank", "Phil", "Phillip" };

            Assert.AreEqual(Array, LList.ToArray());
        }

        [Test]
        public void EmptyListRemoveTestExc() {
            Assert.Throws<InvalidOperationException>(new TestDelegate(EmptyListRemoveTestDel));
        }

        [Test]
        public void EmptyListEmptyTestExc() {
            Assert.Throws<InvalidOperationException>(new TestDelegate(EmptyListEmptyDel));
        }

        private void EmptyListRemoveTestDel() {
            LList.Empty();
            LList.Remove(2);
        }

        private void EmptyListEmptyDel() {
            LList.Empty();
            LList.Empty();
        }
    }
}