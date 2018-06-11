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
        public static void Main(string[] args)
        {
            SortedLinkedList<int> SLList = new SortedLinkedList<int>();
            
            for(int i = 50; i > 0; i--) {
                SLList.Add(i);
            }
            SLList.Remove(20);

            int[] Array = SLList.ToArray();

            foreach(int i in Array) {
                Console.WriteLine(i);
            }
        }
    }
}
