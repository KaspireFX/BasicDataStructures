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

namespace TestConsole
{
    class Program
    {
        private static Stopwatch sw = new Stopwatch();
        public static void Main(string[] args)
        {
            SortedArrayList<int> List = new SortedArrayList<int>();

            List.Add(6);
            List.Add(2);
            List.Add(5);
            List.Add(1);
            int[] Array = List.ToArray();
            foreach(int i in Array) {
                Console.WriteLine(i);
            }
        }
    }
}
