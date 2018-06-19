/*
Author: Jacob Chandler
File: SortedArrayListTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the SortedArrayList Data Structure class.
Date of Comment: 06:19:2018
 */

using System;
using DataStructures.Lists;
using NUnit.Framework;

namespace Tests.ListTests {
    public class SortedArrayListTests {

        SortedArrayList<string> AList = new SortedArrayList<string>(5);

        [SetUp]
        public void Setup() {
            AList.Add("Bill");
            AList.Add("Phil");
            AList.Add("Frank");
            AList.Add("Bobby");
        }

        [Test]
        public void GetFrontTest() {
            Assert.AreEqual("Bill", AList.IndexOf(1));
        }

        [Test]
        public void ContainsTest() {
            Assert.True(AList.Contains("Frank"));
        }

        [Test]
        public void ContainsTest2() {
            Assert.False(AList.Contains("Lil"));
        }

        [Test]
        public void EmptyTest() {
            AList.Empty();
            Assert.True(AList.IsEmpty());
        }

        [Test]
        public void RemoveTest() {
            Assert.AreEqual("Phil", AList.Remove(4));
        }

        [Test]
        public void RemoveTest2() {
            AList.Remove(1);
            Assert.AreEqual(3, AList.Count);
        }

        [Test]
        public void ToArrayTest() {
            AList.Add("Phillip");
            string[] Array = new String[] { "Bill", "Bobby", "Frank", "Phil", "Phillip" };

            Assert.AreEqual(Array, AList.ToArray());
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
            AList.Empty();
            AList.Remove(2);
        }

        private void EmptyListEmptyDel() {
            AList.Empty();
            AList.Empty();
        }
    }
}