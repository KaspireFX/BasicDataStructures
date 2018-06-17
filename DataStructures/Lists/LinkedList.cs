/*
Author: Jacob Chandler
File: LinkedList.cs
Version 1.0.1
Description: This file is the LinkedList class file which implements IListInterface.
Date of Comment: 06:05:2018
 */

using System;
using DataStructures.Iterator;

namespace DataStructures.Lists {

    public class LinkedList<E> : IListInterface<E> {
        private Node FrontNode;
        public int Count { get; private set; }
        private bool Initialized = false;

        public LinkedList() {
            FrontNode = null;
            Count = 0;
            Initialized = true;
        }

        private void CheckInitialization() {
            if (!Initialized) {
                throw new InvalidOperationException("LinkedList was not Initialized correctly.");
            }
        }

        public void Add(E Entry) {
            CheckInitialization();

            Node NewNode = new Node(Entry);

            if (IsEmpty()) {
                FrontNode = NewNode;
            } else {
                Node LastNode = GetNodeAt(Count);
                LastNode.Next = NewNode;
            }

            Count++;
        }

        public void Add(int Position, E Entry) {
            CheckInitialization();

            Node NewNode = new Node(Entry);

            if ((Position >= 1) && (Position <= Count)) {
                if (Position == 1) {
                    FrontNode = NewNode;
                } else {
                    Node Before = GetNodeAt(Position - 1);
                    Node After = GetNodeAt(Position);
                    NewNode.Next = After;
                    Before.Next = NewNode;
                }

                Count++;

            } else {
                throw new IndexOutOfRangeException("Illegal position for Add.");
            }
        }

        public void Empty() {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("List is already Empty.");
            }

            FrontNode = null;
            Count = 0;
        }

        public bool Contains(E AnEntry) {
            CheckInitialization();

            Node TraversalNode = FrontNode;

            for (int i = 1; i < Count; i++) {
                if (TraversalNode.Data.Equals(AnEntry)) {
                    return true;
                }

                TraversalNode = TraversalNode.Next;
            }

            return false;
        }

        public E IndexOf(int Position) {
            CheckInitialization();

            if ((Position >= 1) && (Position <= Count)) {
                return GetNodeAt(Position).Data;
            } else {
                throw new IndexOutOfRangeException("Illegal position for IndexOf.");
            }
        }

        public bool IsEmpty() {
            CheckInitialization();

            return FrontNode == null;
        }

        public E Remove(int Position) {
            CheckInitialization();

            E Data = default(E);

            if ((Position >= 1) && (Position <= Count)) {
                if (Position == 1) {
                    Data = FrontNode.Data;
                    FrontNode = FrontNode.Next;
                } else {
                    Node Before = GetNodeAt(Position - 1);
                    Node NodeToRemove = Before.Next;
                    Node After = NodeToRemove.Next;

                    Data = NodeToRemove.Data;
                    Before.Next = After;
                }
                Count--;
                return Data;
            } else {
                throw new IndexOutOfRangeException("Illegal position for Remove.");
            }
        }

        public E Replace(int Position, E NewEntry) {
            CheckInitialization();

            E Data = default(E);
            Node NewNode = new Node(NewEntry);

            if ((Position >= 1) && (Position <= Count)) {
                if (Position == 1) {
                    Data = FrontNode.Data;
                    FrontNode = NewNode;
                } else {
                    Node Before = GetNodeAt(Position - 1);
                    Node NodeToReplace = Before.Next;

                    Data = NodeToReplace.Data;

                    Before.Next = NewNode;
                    if (NodeToReplace.Next != null) {
                        Node After = NodeToReplace.Next;
                        NewNode.Next = After;
                    }
                }

                return Data;
            } else {
                throw new IndexOutOfRangeException("Illegal position for Replace.");
            }
        }

        public E[] ToArray() {
            CheckInitialization();

            E[] Array = new E[Count];
            Node TraversalNode = FrontNode;

            for (int i = 0; i < Count; i++) {
                Array[i] = TraversalNode.Data;
                TraversalNode = TraversalNode.Next;
            }

            return Array;
        }

        public IIteratorInterface<E> Iterator => new LinkedListIterator(this);

        private Node GetNodeAt(int Index) {
            Node CurrentNode = FrontNode;

            for (int i = 1; i < Index; i++) {
                CurrentNode = CurrentNode.Next;
            }

            return CurrentNode;
        }

        internal class Node {
            internal Node Next { get; set; }
            internal E Data;

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

        internal class LinkedListIterator : IIteratorInterface<E> {
            internal LinkedList<E> MyList;
            internal bool WasNextCalled = false;
            internal Node CurrentNode;

            internal LinkedListIterator(LinkedList<E> ParentList) {
                this.MyList = ParentList;
                CurrentNode = MyList.FrontNode;
            }

            public bool HasNext() {
                return CurrentNode != null;
            }

            public bool IsEqualTo(E Entry) {
                return CurrentNode.Data.Equals(Entry);
            }

            public E Next() {
                if (HasNext()) {
                    E Data = CurrentNode.Data;
                    CurrentNode = CurrentNode.Next;
                    return Data;
                } else {
                    throw new InvalidOperationException("Iterator is at end of list, cannot iterate further.");
                }
            }

            public void Reset() {
                CurrentNode = MyList.FrontNode;
            }
        }
    }
}