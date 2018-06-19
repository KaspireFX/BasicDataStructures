/*
Author: Jacob Chandler
File: SortedLinkedListIteratorTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the SortedLinkedListIterator Data Structure class.
Date of Comment: 06:19:2018
 */

using System;
using DataStructures.Iterator;
using DataStructures.Lists;
using NUnit.Framework;

namespace Tests.ListIteratorTests {
    public class SortedLinkedListIteratorTests {

        SortedLinkedList<string> LList = new SortedLinkedList<string>();
        IIteratorInterface<string> Iterator;

        [SetUp]
        public void Setup() {
            LList.Add("Bill");
            LList.Add("Phil");
            LList.Add("Frank");
            LList.Add("Bobby");
            Iterator = LList.Iterator;
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