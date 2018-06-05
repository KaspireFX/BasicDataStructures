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
        public static void Main(string[] args)
        {
            LList.Add("Bob");
            LList.Add("Phil");
            LList.Add("Banana");
            LList.Add(2, "Willie");
            Console.WriteLine(LList.IndexOf(2));
            Console.WriteLine(LList.Contains("Banana"));
            Console.WriteLine(LList.Count);
            LList.Empty();
            Console.WriteLine(LList.IsEmpty());
            Console.WriteLine(LList.Count);
        }
    }
}
