/*
Author: Jacob Chandler
File: Program.cs
Version: 1.0.1
Description: This file is used to test functionality in a regular c# project.
Date of Comment: 06:01:2018
 */
 
using System;
using System.Diagnostics;
using DataStructures.Stacks;
using DataStructures.Lists;
using DataStructures.Queues;
using DataStructures.Dictionaries;
using DataStructures.Iterator;

namespace TestConsole
{
    class Program
    {
        private static Stopwatch sw = new Stopwatch();
        public static void Main(string[] args)
        {
            SortedArrayDictionary<int, string> SDictionary = new SortedArrayDictionary<int, string>();

            SDictionary.Add(5, "bob");
            SDictionary.Add(3, "Phil");
            SDictionary.Add(4, "Frank");
            SDictionary.Add(7, "Pop");
            SDictionary.Remove(4);
            SDictionary.Remove(7);
            SDictionary.Remove(3);
        }
    }
}
