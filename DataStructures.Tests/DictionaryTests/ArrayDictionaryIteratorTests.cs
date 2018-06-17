/*
Author: Jacob Chandler
File: ArrayDictionaryIteratorTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the ArrayDictionaryIterator Data Structure class.
Date of Comment: 06:16:2018
 */

using System;
using DataStructures.Dictionaries;
using DataStructures.Iterator;
using NUnit.Framework;

namespace Tests.DictionaryIteratorTests {
    public class ArrayDictionaryIteratorTests {

        ArrayDictionary<int, string> ADictionary = new ArrayDictionary<int, string>();
        IIteratorInterface<string> Iterator;

        [SetUp]
        public void Setup() {
            ADictionary.Add(6, "Bill");
            ADictionary.Add(7, "Phil");
            ADictionary.Add(12, "Frank");
            ADictionary.Add(76, "Bobby");
            Iterator = ADictionary.ValueIterator;
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