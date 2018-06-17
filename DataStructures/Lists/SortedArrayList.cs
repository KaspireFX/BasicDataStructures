/*
Author: Jacob Chandler
File: SortedArrayList.cs
Version 1.0.1
Description: This file is the SortedArrayList class file which implements ISortedListInterface.
Date of Comment: 06:14:2018
*/

using System;

namespace DataStructures.Lists {

    public class SortedArrayList<E> : ISortedListInterface<E> where E : IComparable {
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

        private void CheckInitialization() {
            if (!Initialized) {
                throw new InvalidOperationException("SortedArrayList not initialized correctly.");
            }
        }

        private void ReSize() {
            E[] Temp = new E[List.Length * 2];
            for (int i = 1; i < Count; i++) {
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
        }

        private void Add(int Position, E Entry) {
            if (IsFull()) {
                ReSize();
            } else if (IsEmpty()) {
                List[Count + 1] = Entry;
            } else if (Entry.CompareTo(List[Position]) <= 0) {
                MakeSpace(Position);
                List[Position] = Entry;
            } else if (Entry.CompareTo(List[Position]) > 0) {
                Add(Position + 1, Entry);
            } else {
                List[Position] = Entry;
            }

            Count++;
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

            for (int i = 1; i < Count; i++) {
                List[i] = default(E);
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

            E[] Temp = new E[Count - 1];
            for (int i = 1; i < Count; i++) {
                Temp[i - 1] = List[i];
            }

            return Temp;
        }
    }
}