/*
Author: Jacob Chandler
File: SortedArrayListIteratorTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the SortedArrayListIterator Data Structure class.
Date of Comment: 06:19:2018
 */

using System;
using DataStructures.Iterator;
using DataStructures.Lists;
using NUnit.Framework;

namespace Tests.ListIteratorTests {
    public class SortedArrayListIteratorTests {

        SortedArrayList<string> SAList = new SortedArrayList<string>();
        IIterator<string> Iterator;

        [SetUp]
        public void Setup() {
            SAList.Add("Bill");
            SAList.Add("Phil");
            SAList.Add("Frank");
            SAList.Add("Bobby");
            Iterator = SAList.Iterator;
        }

        [Test]
        public void TestNext() {
            Assert.AreEqual("Bill", Iterator.Next());
        }

        [Test]
        public void TestHasNext() {
            Assert.True(Iterator.HasNext());
        }

        [Test]
        public void TestReset() {
            Iterator.Next();
            Iterator.Reset();
            Assert.AreEqual("Bill", Iterator.Next());
        }
    }
}