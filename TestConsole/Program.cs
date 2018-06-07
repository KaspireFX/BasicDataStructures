/*
Author: Jacob Chandler
File: Program.cs
Version: 1.0.1
Description: This file is used to test functionality in a regular c# project.
Date of Comment: 06:01:2018
 */
 
using System;
using DataStructures.Stacks;
using DataStructures.Lists;
using DataStructures.Queues;

namespace TestConsole
{
    class Program
    {
        private static LinkedList<string> LList = new LinkedList<string>();
        private static IIteratorInterface<string> Iterator;
        public static void Main(string[] args)
        {
            LList.Add("Bill");
            LList.Add("Phil");
            LList.Add("Frank");
            LList.Add("Bobby");
            LList.Add(3, "Phillip");
            string[] Array = LList.ToArray();

            foreach(string s in Array) {
                Console.WriteLine(s);
            }
        }
    }
}
