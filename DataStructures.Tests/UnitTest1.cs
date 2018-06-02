/*
Author: Jacob Chandler
File: UnitTest1.cs
Version: 1.0.1
Description: This file contains NUnit test functionality for the Data Structures class Library.
Date of Comment: 06:01:2018
 */

using System;
using NUnit.Framework;
using DataStructures.Lists;

namespace Tests
{
    public class Tests
    {

        ArrayList<string> List = new ArrayList<string>(2);

        [SetUp]
        public void Setup()
        {
            List.Add("Abbi");
            List.Add("Bob");
            List.Add("Frank");
            List.Add("Phillis");
            List.Add("Zorg");
        }

        [Test]
        public void Test1() {
            Assert.AreEqual(5, List.NumOfElements);
        }

        [Test]
        public void Test2() {
            Assert.False(List.IsEmpty());
        }

        [Test]
        public void Test3() {
            List.Replace(3, "Brandy");
            Assert.AreEqual("Brandy", List.GetEntryAt(3));
        }

        [Test]
        public void Test4()
        {
            List.Remove(1);
            Assert.AreEqual("Bob", List.GetEntryAt(1));
        }

        [Test]
        public void Test5() {
            List.Clear();
            Assert.True(List.IsEmpty());
        }

        [Test]
        public void Test6() {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(MyDelegate));
        }

        void MyDelegate() {
            List.GetEntryAt(30);
        }
    }
}