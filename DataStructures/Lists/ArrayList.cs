/*
Author: Jacob Chandler
File: ArrayList.cs
Version 1.0.1
Description: This file is the ArrayList class file which implements IListInterface.
Date of Comment: 06:02:2018
 */

using System;
using DataStructures.Iterator;

namespace DataStructures.Lists {

    public class ArrayList<E> : IListInterface<E> {
        private E[] List;
        private const int DEFAULT_CAPACITY = 10;
        private bool Initialized = false;

        public int Count { get; private set; }

        public ArrayList(): this(DEFAULT_CAPACITY) {}

        public ArrayList(int Capacity) {
            List = new E[Capacity];
            Count = 0;
            Initialized = true;
        }

        private void CheckInitialization() {
            if (!Initialized) {
                throw new InvalidOperationException("ArrayList was not Initialized correctly.");
            }
        }

        private void ReSize() {
            E[] Temp = new E[List.Length * 2];
            for (int i = 0; i < List.Length; i++) {
                Temp[i] = List[i];
            }

            List = Temp;
        }

        private bool CheckAvailability() {
            if ((Count + 1)>= List.Length) {
                return false;
            }
            return true;
        }

        private void MakeRoom(int NewPosition) {
            for (int i = Count; i >= NewPosition; i--) {
                List[i + 1] = List[i];
            }
        }

        public void Add(E Entry) {
            Add(Count + 1, Entry);
        }

        public void Add(int Position, E Entry) {
            CheckInitialization();

            if (CheckAvailability()) {
                if ((Position >= 1)&& (Position <= List.Length)) {
                    if (Position <= Count) {
                        MakeRoom(Position);
                    }
                    List[Position] = Entry;
                    Count++;
                } else {
                    throw new ArgumentOutOfRangeException("Position is outside of List bounds.");
                }
            } else {
                ReSize();
                Add(Position, Entry);
            }
        }

        public void Empty() {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Cannot empty an already empty list.");
            }

            int Index = Count;
            while (Index >= 1) {
                List[Index] = default(E);
                Index--;
            }
            Count = Index;
        }

        public bool Contains(E AnEntry) {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("ArrayList is Empty.");
            }

            for (int i = 1; i < List.Length; i++) {
                if (List[i].Equals(AnEntry)) {
                    return true;
                }
            }
            return false;
        }

        public E IndexOf(int Position) {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("ArrayList is Empty.");
            }

            if ((Position >= 1)&& (Position <= List.Length)) {
                return List[Position];
            } else {
                throw new ArgumentOutOfRangeException("Position is outside of List bounds.");
            }
        }

        public bool IsEmpty() {
            CheckInitialization();

            return Count == 0;
        }

        public E Remove(int Position) {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Array is Empty.");
            }

            E TempData = default(E);

            if ((Position >= 1)&& (Position <= List.Length)) {
                TempData = List[Position];

                if (Position <= Count) {
                    List[Position] = List[Count - 1];
                    List[Count - 1] = default(E);
                } else {
                    List[Position] = default(E);
                }
            } else {
                throw new ArgumentOutOfRangeException("Position is outside of List bounds.");
            }

            Count--;
            return TempData;
        }

        public E Replace(int Position, E NewEntry) {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("ArrayList is Empty.");
            }

            E TempData = default(E);

            if ((Position >= 1)&& (Position <= List.Length)) {
                TempData = List[Position];
                List[Position] = NewEntry;
            } else {
                throw new ArgumentOutOfRangeException("Position is outside of List bounds.");
            }

            return TempData;
        }

        public E[] ToArray() {
            CheckInitialization();

            E[] TempArray = new E[Count];

            if (IsEmpty()) {
                return TempArray;
            }

            for (int i = 1; i < Count + 1; i++) {
                TempArray[i - 1] = List[i];
            }

            return TempArray;
        }

        public IIteratorInterface<E> Iterator => new ArrayListIterator(this);

        internal class ArrayListIterator : IIteratorInterface<E> {
            internal int Index;
            internal ArrayList<E> AList;

            internal ArrayListIterator(ArrayList<E> ParentList) {
                this.AList = ParentList;
                Index = 1;
            }

            public bool HasNext() {
                return AList.IndexOf(Index)!= null;
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