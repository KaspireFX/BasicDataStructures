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
        public static void Main(string[] args)
        {
            ArrayDictionary<int, string> Dictionary = new ArrayDictionary<int, string>();

            Dictionary.Add(1, "Phil");
            Dictionary.Add(50, "Bob");
            Dictionary.Add(9, "Frank");
            Dictionary.Add(4, "Bobby");
            Console.WriteLine("Contians {0}: {1}", 4, Dictionary.Contains(4));
            Console.WriteLine("Removed: {0}", Dictionary.Remove(50));
            Dictionary.Empty();
            Console.WriteLine("Empty: {0}", Dictionary.IsEmpty());
        }
    }
}
