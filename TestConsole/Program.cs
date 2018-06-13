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
            LinkedDictionary<int, string> Dictionary = new LinkedDictionary<int, string>();

            Dictionary.Add(2, "Phil");
            Dictionary.Add(3, "Bob");
            Dictionary.Add(4, "Bobby");
            Dictionary.Add(2, "Phillis");
            Console.WriteLine("GetValue: {0}", Dictionary.GetValue(2));
            Console.WriteLine("GetValue: {0}", Dictionary.GetValue(60));
        }
    }
}
