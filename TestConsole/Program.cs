/*
Author: Jacob Chandler
File: Program.cs
Version: 1.0.1
Description: This file is used to test functionality in a regular c# project.
Date of Comment: 06:01:2018
 */

using System;
using System.Diagnostics;
using DataStructures.Dictionaries;
using DataStructures.Iterator;
using DataStructures.Lists;
using DataStructures.Queues;
using DataStructures.Stacks;

namespace TestConsole {
    class Program {
        private static Stopwatch sw = new Stopwatch();
        private static ArrayList<string> AList;
        private static SortedArrayList<string> SAList;
        private static LinkedList<string> LList;
        private static SortedLinkedList<string> SLList;

        public static void Main(string[] args) {
            string[] Array = new string[] { "bob", "Phil", "Frank", "Phillip", "Willie" };
            AList = new ArrayList<string>(Array);
            SAList = new SortedArrayList<string>(Array);
            LList = new LinkedList<string>(Array);
            SLList = new SortedLinkedList<string>(Array);

            for (int i = 1; i <= SLList.Count; i++) {
                Console.WriteLine(SLList.IndexOf(i));
            }
        }
    }
}