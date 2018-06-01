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
            Queue.Enqueue("Joey");
            Console.WriteLine("Should equal Joey: {0}", Queue.GetFront());
            Queue.Clear();
            Console.WriteLine(Queue.NumOfElements);
        }
    }
}
