/*
Author: Jacob Chandler
File: Program.cs
Version: 1.0.1
Description: This file is used to test functionality in a regular c# project.
Date of Comment: 06:01:2018
 */
 
using System;
using DataStructures.Queues;

namespace TestConsole
{
    class Program
    {
        private static LinkedQueue<string> Queue = new LinkedQueue<string>();
        static void Main(string[] args)
        {
            Queue.Enqueue("Bob");
            Queue.Dequeue();
            try {
                Queue.Dequeue();
            } catch (InvalidOperationException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
