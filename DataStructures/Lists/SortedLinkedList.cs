/*
Author: Jacob Chandler
File: SortedLinkedList.cs
Version 1.0.1
Description: This file is the SortedLinkedList class file which implements IList.
Date of Comment: 06:10:2018
 */

using System;
using DataStructures.Iterator;

namespace DataStructures.Lists {

    public class SortedLinkedList<E> : ISortedList<E> where E : IComparable {
        public int Count { get; private set; }
        private Node FrontNode;
        private bool Initialized = false;

        public SortedLinkedList() {
            FrontNode = null;
            Count = 0;
            Initialized = true;
        }

        public SortedLinkedList(E[] Array) {
            FrontNode = null;
            Count = 0;
            Initialized = true;

            foreach (E element in Array) {
                Add(element);
            }
        }

        private void CheckInitialization() {
            if (!Initialized) {
                throw new InvalidOperationException("SortedLinkedList was not Initialized correctly.");
            }
        }

        public void Add(E Entry) {
            CheckInitialization();

            FrontNode = Add(Entry, FrontNode);
            Count++;
        }

        private Node Add(E Entry, Node CurrentNode) {
            if ((CurrentNode == null) || (Entry.CompareTo(CurrentNode.Data) <= 0)) {
                CurrentNode = new Node(CurrentNode, Entry);
            } else {
                Node After = Add(Entry, CurrentNode.Next);
                CurrentNode.Next = After;
            }
            return CurrentNode;
        }

        public bool Contains(E AnEntry) {
            CheckInitialization();

            for (int i = 1; i < Count; i++) {
                if (GetNodeAt(i).Data.Equals(AnEntry)) {
                    return true;
                }
            }

            return false;
        }

        public void Empty() {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Cannot empty an already empty list.");
            }

            FrontNode = null;
        }

        public E IndexOf(int Position) {
            CheckInitialization();

            return GetNodeAt(Position).Data;
        }

        public bool IsEmpty() {
            CheckInitialization();

            return FrontNode == null;
        }

        public E Remove(int Position) {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Cannot remove from empty list.");
            }

            if ((Position >= 1) && (Position <= Count)) {
                Node Before = GetNodeAt(Position - 1);
                Node NodeToRemove = Before.Next;
                Node After = NodeToRemove.Next;

                E Data = NodeToRemove.Data;

                Before.Next = After;
                Count--;
                return Data;
            } else {
                throw new ArgumentOutOfRangeException("Invalid Position");
            }
        }

        public E[] ToArray() {
            CheckInitialization();

            E[] Array = new E[Count];
            for (int i = 1; i <= Count; i++) {
                Array[i - 1] = GetNodeAt(i).Data;
            }

            return Array;
        }

        private Node GetNodeAt(int Index) {
            Node CurrentNode = FrontNode;

            for (int i = 1; i < Index; i++) {
                CurrentNode = CurrentNode.Next;
            }

            return CurrentNode;
        }

        public static bool Search(E[] Array, int Beginning, int End, E Entry) {
            int Mid = Beginning + (End - Beginning) / 2;
            bool Found;

            if (Beginning > End) {
                Found = false;
            } else if (Entry.Equals(Array[Mid])) {
                Found = true;
            } else if (Entry.CompareTo(Array[Mid]) < 0) {
                Found = Search(Array, Beginning, Mid - 1, Entry);
            } else {
                Found = Search(Array, Mid + 1, End, Entry);
            }

            return Found;
        }

        public IIterator<E> Iterator => new SortedLinkedListIterator(this);

        internal class Node {
            internal Node Next { get; set; }
            internal E Data { get; set; }

            internal Node() {
                this.Next = null;
                this.Data = default(E);
            }

            internal Node(Node NextNode, E NodeData) {
                this.Next = NextNode;
                this.Data = NodeData;
            }
        }

        internal class SortedLinkedListIterator : IIterator<E> {
            internal SortedLinkedList<E> MyList;
            internal bool WasNextCalled = false;
            internal Node CurrentNode;

            internal SortedLinkedListIterator(SortedLinkedList<E> ParentList) {
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