/*
Author: Jacob Chandler
File: LinkedStack.cs
Version: 1.0.1
Description: This file is the class file for the LinkedStack object which implements IStackInterface.
Date of Comment: 06:01:2018
 */

using System;

namespace DataStructures.Stacks {

    public class LinkedStack<E> : IStackInterface<E> {
        private Node TopNode;

        public int Count { get; private set; }

        private bool Initialized = false;

        public LinkedStack() {
            TopNode = null;
            Count = 0;
            Initialized = true;
        }

        public void Empty() {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Stack is Empty.");
            }

            Node tmp;
            while (Count != 0) {
                tmp = TopNode.Previous;
                TopNode = null;
                TopNode = tmp;
                Count--;
            }
        }

        public bool IsEmpty() {
            CheckInitialization();

            return TopNode == null;
        }

        public E Peek() {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Stack is Empty.");
            }

            return TopNode.Data;
        }

        public E Pop() {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Stack is Empty.");
            }

            E tmp = TopNode.Data;
            TopNode = TopNode.Previous;
            Count--;
            return tmp;
        }

        public void Push(E element) {
            CheckInitialization();

            Node NewNode = new Node();
            NewNode.Previous = TopNode;
            TopNode = NewNode;
            TopNode.Data = element;
            Count++;
        }

        private void CheckInitialization() {
            if (!Initialized) {
                throw new InvalidOperationException("Linked Stack not initialized properly.");
            }
        }

        internal class Node {
            internal Node Previous { get; set; }
            internal E Data { get; set; }

            internal Node() {
                Previous = null;
                Data = default(E);
            }

            internal Node(Node PreviousNode, E NodeData) {
                Previous = PreviousNode;
                Data = NodeData;
            }
        }
    }
}