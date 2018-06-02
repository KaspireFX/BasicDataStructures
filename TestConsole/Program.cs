/*
Author: Jacob Chandler
File: Program.cs
Version: 1.0.1
Description: This file is used to test functionality in a regular c# project.
Date of Comment: 06:01:2018
 */
 
using System;
using DataStructures.Lists;

namespace TestConsole
{
    class Program
    {
        private static ArrayList<string> List = new ArrayList<string>(2);
        public static void Main(string[] args)
        {
            List.Add("Bob");
            List.Add("Phil");
            List.Add("Megan");
            Console.WriteLine("3: {0}", List.GetEntryAt(2));
            List.Replace(3, "Bobby");
            Console.WriteLine("3: {0}", List.GetEntryAt(3));
            List.Remove(1);
            Console.WriteLine("Front: {0}", List.GetEntryAt(1));
        }
    }
}
