/*
Author: Jacob Chandler
File: LinkedQueue.cs
Version: 1.0.1
Description: This file is the linkedQueue class file which implements IQueueInterface.
Date of Comment: 06:01:2018
 */

using System;

namespace DataStructures.Queues {

    public class LinkedQueue<E> : IQueueInterface<E>
    {
        private Node FrontNode;
        private Node BackNode;
        private bool Initialized = false;

        public int Count { get; private set; }

        public LinkedQueue() {
            FrontNode = null;
            BackNode = null;
            Count = 0;
            Initialized = true;
        }

        private void CheckInitialized() {
            if(!Initialized) {
                throw new InvalidOperationException("LinkedQueue was not Initialized correctly.");
            }
        }

        public void Empty()
        {
            CheckInitialized();

            if(IsEmpty()) {
                throw new InvalidOperationException("LinkedQueue is Empty.");
            }

            FrontNode = null;
            BackNode = null;
            Count = 0;
        }

        public E Dequeue()
        {
            CheckInitialized();

            if(IsEmpty()) {
                throw new InvalidOperationException("LinkedQueue is Empty.");
            }

            E TempData = GetFront();
            FrontNode.Data = default(E);
            FrontNode = FrontNode.Next;
            Count--;
            return TempData;
        }

        public void Enqueue(E NewEntry)
        {
            CheckInitialized();

            Node NewNode = new Node(NewEntry);

            if(IsEmpty()) {
                FrontNode = NewNode;
                BackNode = FrontNode;
            } else {
                BackNode.Next = NewNode;
                BackNode = NewNode;
            }

            Count++;
        }

        public E GetFront()
        {
            CheckInitialized();

            if(IsEmpty()) {
                throw new InvalidOperationException("LinkedQueue is Empty.");
            }

            return FrontNode.Data;
        }

        public bool IsEmpty()
        {
            CheckInitialized();

            return (Count == 0) && (FrontNode == null && BackNode == null);
        }

        internal class Node {
            internal Node Next { get; set; }
            internal E Data { get; set; }

            internal Node() {
                this.Next = null;
                this.Data = default(E);
            }

            internal Node(E NodeData) {
                this.Next = null;
                this.Data = NodeData;
            }

            internal Node(Node NextNode, E NodeData) {
                this.Next = NextNode;
                this.Data = NodeData;
            }
        }   
    }
}