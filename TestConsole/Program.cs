﻿using System;
using DataStructures.Queues;

namespace TestConsole
{
    class Program
    {
        private static LinkedQueue<string> Queue = new LinkedQueue<string>();
        static void Main(string[] args)
        {
            Queue.Enqueue("Bob");
            Queue.Enqueue("Phil");
            Console.WriteLine(Queue.Dequeue());
            Console.WriteLine(Queue.GetFront());
        }
    }
}
