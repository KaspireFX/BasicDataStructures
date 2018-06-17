/*
Author: Jacob Chandler
File: LinkedDictionaryIteratorTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the LinkedDictionaryIterator Data Structure class.
Date of Comment: 06:16:2018
 */

using System;
using DataStructures.Dictionaries;
using DataStructures.Iterator;
using NUnit.Framework;

namespace Tests.DictionaryIteratorTests {
    public class LinkedDictionaryTests {

        LinkedDictionary<int, string> LDictionary = new LinkedDictionary<int, string>();
        IIteratorInterface<string> Iterator;

        [SetUp]
        public void Setup() {
            LDictionary.Add(5, "Bill");
            LDictionary.Add(6, "Phil");
            LDictionary.Add(7, "Frank");
            LDictionary.Add(9, "Bobby");
            Iterator = LDictionary.ValueIterator;
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