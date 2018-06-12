/*
Author: Jacob Chandler
File: ArrayListIteratorTests.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the ArrayListIterator Data Structure class.
Date of Comment: 06:11:2018
 */

using System;
using NUnit.Framework;
using DataStructures.Lists;

namespace Tests.ListIteratorTests
{
    public class ArrayListIteratorTests
    {

        ArrayList<string> AList = new ArrayList<string>();
        IIteratorInterface<string> Iterator;

        [SetUp]
        public void Setup()
        {
            AList.Add("Bill");
            AList.Add("Phil");
            AList.Add("Frank");
            AList.Add("Bobby");
            Iterator = AList.Iterator;
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