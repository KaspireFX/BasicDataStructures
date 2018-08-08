/*
Author: Jacob Chandler
File: Program.cs
Version: 1.0.1
Description: This file is used to test functionality in a regular c# project.
Date of Comment: 06:01:2018
 */

using System;
using System.Diagnostics;
using DataStructures.Dictionaries;
using DataStructures.Iterator;
using DataStructures.Lists;
using DataStructures.Queues;
using DataStructures.Stacks;
using DataStructures.Trees;

namespace TestConsole {
    class Program {
        private static Stopwatch sw = new Stopwatch();
        private static ArrayList<string> AList;
        private static SortedArrayList<string> SAList;
        private static LinkedList<string> LList;
        private static SortedLinkedList<string> SLList;

        public static void Main(string[] args) {
            BinaryTree<int> Tree = new BinaryTree<int>();
            Tree.Add(10);
            Tree.Add(4);
            Tree.Add(11);
            Tree.Add(2);
            Tree.Add(5);
        }
    }
}