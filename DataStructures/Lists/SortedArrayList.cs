/*
Author: Jacob Chandler
File: SortedArrayList.cs
Version 1.0.1
Description: This file is the SortedArrayList class file which implements ISortedList.
Date of Comment: 06:14:2018
*/

using System;
using DataStructures.Iterator;

namespace DataStructures.Lists {

    public class SortedArrayList<E> : ISortedList<E> where E : IComparable {
        private E[] List;
        private bool Initialized = false;
        private const int DEFAULT_CAPACITY = 10;
        public int Count { get; private set; }

        public SortedArrayList() : this(DEFAULT_CAPACITY) { }

        public SortedArrayList(int Capacity) {
            List = new E[Capacity];
            Count = 0;
            Initialized = true;
        }

        public SortedArrayList(E[] Array) {
            List = new E[Array.Length];
            Count = 0;
            Initialized = true;

            foreach (E element in Array) {
                Add(element);
            }
        }

        private void CheckInitialization() {
            if (!Initialized) {
                throw new InvalidOperationException("SortedArrayList not initialized correctly.");
            }
        }

        private void ReSize() {
            E[] Temp = new E[List.Length * 2];
            for (int i = 0; i <= Count; i++) {
                Temp[i] = List[i];
            }

            List = Temp;
        }

        private void MakeSpace(int Position) {
            for (int i = Count; i >= Position; i--) {
                List[i + 1] = List[i];
            }
        }

        private bool IsFull() {
            return Count + 1 == List.Length;
        }

        public void Add(E Entry) {
            CheckInitialization();

            Add(1, Entry);
            Count++;
        }

        private void Add(int Position, E Entry) {
            if (IsFull()) {
                ReSize();
                Add(Position, Entry);
            } else if (IsEmpty()) {
                List[Count + 1] = Entry;
            } else if (Entry.CompareTo(List[Position]) <= 0) {
                MakeSpace(Position);
                List[Position] = Entry;
            } else {
                if (List[Position] == null) {
                    List[Position] = Entry;
                } else {
                    Add(Position + 1, Entry);
                }
            }
        }

        public bool Contains(E AnEntry) {
            CheckInitialization();

            int Index = 1;
            while (Index <= Count) {
                if (List[Index].Equals(AnEntry)) {
                    return true;
                }
                Index++;
            }

            return false;
        }

        public void Empty() {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Cannot empty already empty List.");
            }

            int Index = Count;
            for (int i = 1; i <= Index; i++) {
                List[i] = default(E);
                Count--;
            }
        }

        public E IndexOf(int Position) {
            CheckInitialization();

            if ((Position >= 1) && (Position <= Count)) {
                return List[Position];
            } else {
                throw new ArgumentOutOfRangeException("Invalid position for IndexOf.");
            }
        }

        public bool IsEmpty() {
            CheckInitialization();

            return Count == 0;
        }

        public E Remove(int Position) {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Unable to remove from empty list.");
            }

            if ((Position >= 1) && (Position <= Count)) {
                E Data = List[Position];

                for (int i = Position; i < Count; i++) {
                    List[i] = List[i + 1];
                }

                Count--;
                return Data;
            } else {
                throw new ArgumentOutOfRangeException("Invalid position for Remove.");
            }
        }

        public E[] ToArray() {
            CheckInitialization();

            E[] Temp = new E[Count];
            for (int i = 1; i <= Count; i++) {
                Temp[i - 1] = List[i];
            }

            return Temp;
        }

        public IIterator<E> Iterator => new SortedArrayListIterator(this);

        internal class SortedArrayListIterator : IIterator<E> {
            internal int Index;
            internal SortedArrayList<E> AList;

            internal SortedArrayListIterator(SortedArrayList<E> ParentList) {
                this.AList = ParentList;
                Index = 1;
            }

            public bool HasNext() {
                return AList.IndexOf(Index) != null;
            }

            public bool IsEqualTo(E Entry) {
                return AList.IndexOf(Index).Equals(Entry);
            }

            public E Next() {
                if (HasNext()) {
                    E Data = AList.IndexOf(Index);
                    Index++;
                    return Data;
                } else {
                    throw new InvalidOperationException("Iterator is at end of List, cannot iterator further.");
                }
            }

            public void Reset() {
                Index = 1;
            }
        }
    }
}