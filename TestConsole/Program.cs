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

        public static void Main(string[] args) {
            SortedLinkedDictionary<int, string> Dict = new SortedLinkedDictionary<int, string>();

            Dict.Add(5, "bob");
            Dict.Add(1, "Phil");
            Dict.Add(12, "Phillip");
            Dict.Add(34, "Frank");
            Dict.Add(54, "Bobby");
            Dict.Add(40, "Billy");
            Console.WriteLine(Dict.Contains(40));
        }
    }
}