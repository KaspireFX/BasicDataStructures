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
            LinkedDictionary<int, string> LDictionary = new LinkedDictionary<int, string>();
            ArrayDictionary<int, string> ArrayDictionary = new ArrayDictionary<int, string>();

            LDictionary.Add(8, "Phil");
            LDictionary.Add(7, "bob");
            LDictionary.Add(3, "mango");
            LDictionary.Add(5, "bobby");

            ArrayDictionary.Add(8, "bnana");
            ArrayDictionary.Add(7, "f");
            ArrayDictionary.Add(3, "d");
            ArrayDictionary.Add(5, "b");

            IIteratorInterface<string> Iterator1 = LDictionary.ValueIterator;
            IIteratorInterface<string> Iterator2 = ArrayDictionary.ValueIterator;

            while(Iterator1.HasNext()) {
                Console.WriteLine(Iterator1.Next());
            }

            
            while(Iterator2.HasNext()) {
                Console.WriteLine(Iterator2.Next());
            }
        }
    }
}
