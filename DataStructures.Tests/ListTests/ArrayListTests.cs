/*
Author: Jacob Chandler
File: ArrayListTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the ArrayList Data Structure class.
Date of Comment: 06:03:2018
 */

using System;
using NUnit.Framework;
using DataStructures.Lists;

namespace Tests.ListTests
{
    public class ArrayListTests
    {

        ArrayList<string> AList = new ArrayList<string>(5);

        [SetUp]
        public void Setup()
        {
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
            Assert.AreEqual("Frank", AList.Remove(3));
        }

        [Test]
        public void RemoveTest2() {
            AList.Remove(1);
            Assert.AreEqual(3, AList.Count);
        }

        [Test]
        public void ReplaceTest() {
            AList.Replace(4, "Willie");
            Assert.AreEqual("Willie", AList.IndexOf(4));
        }

        [Test]
        public void ToArrayTest() {
            AList.Add(3, "Phillip");
            string[] Array = new String[] { "Bill", "Phil", "Phillip", "Frank", "Bobby" };

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

        private void EmptyListRemoveTestDel()
        {
            AList.Empty();
            AList.Remove(2);
        }

        private void EmptyListEmptyDel() {
            AList.Empty();
            AList.Empty();
        }
    }
}