/*
Author: Jacob Chandler
File: ArrayList.cs
Version 1.0.1
Description: This file is the ArrayList class file which implements IListInterface.
Date of Comment: 06:02:2018
 */

using System;

namespace DataStructures.Lists {

    public class ArrayList<E> : IListInterface<E>
    {
        private E[] List;
        private const int DEFAULT_CAPACITY = 10;
        private bool Initialized = false;
        public int NumOfElements { get; private set; }

        public ArrayList() : this(DEFAULT_CAPACITY) {
        }

        public ArrayList(int Capacity) {
            List = new E[Capacity];
            NumOfElements = 0;
            Initialized = true;
        }

        private void CheckInitialization() {
            if(!Initialized) {
                throw new InvalidOperationException("ArrayList was not Initialized correctly.");
            }
        }

        private void ReSize() {
            E[] Temp = new E[List.Length * 2];
            for(int i = 0; i < List.Length; i++) {
                Temp[i] = List[i];
            }

            List = Temp;
        }

        private bool CheckAvailability() {
            if((NumOfElements + 1) >= List.Length) {
                return false;
            }
            return true;
        }

        private void MakeRoom(int NewPosition)
        {
            for(int i = NumOfElements; i >= NewPosition; i--) {
                List[i + 1] = List[i];
            }
        }

        private void FillIn(int NewPosition)
        {
            int Index = NewPosition;
            while(Index < (List.Length - 1)) {
                List[Index] = List[Index + 1];
                Index++;
            }
        }

        public void Add(E Entry)
        {
            Add(NumOfElements + 1, Entry);
        }

        public void Add(int Position, E Entry)
        {
            CheckInitialization();

            if(CheckAvailability()) {
                if((Position >= 1) && (Position <= List.Length)) {
                    if(Position <= NumOfElements) {
                        MakeRoom(Position);
                    }
                    List[Position] = Entry;
                    NumOfElements++;
                } else {
                    throw new ArgumentOutOfRangeException("Position is outside of List bounds.");
                }
            } else {
                ReSize();
                Add(Position, Entry);
            }
        }


        public void Clear()
        {
            CheckInitialization();

            int Index = NumOfElements;
            while(Index >= 1) {
                List[Index] = default(E);
                Index--;
            }
            NumOfElements = Index;
        }

        public bool Contains(E AnEntry)
        {
            CheckInitialization();

            if(IsEmpty()) {
                throw new InvalidOperationException("ArrayList is Empty.");
            }

            for(int i = 1; i < List.Length; i++) {
                if(List[i].Equals(AnEntry)) {
                    return true;
                }
            }
            return false;
        }

        public E GetEntryAt(int Position)
        {
            CheckInitialization();

            if(IsEmpty()) {
                throw new InvalidOperationException("ArrayList is Empty.");
            }

            if((Position >= 1) && (Position <= List.Length)) {
                return List[Position];
            } else {
                throw new ArgumentOutOfRangeException("Position is outside of List bounds.");
            }
        }

        public bool IsEmpty()
        {
            CheckInitialization();

            return NumOfElements == 0;
        }

        public E Remove(int Position)
        {
            CheckInitialization();

            if(IsEmpty()) {
                throw new InvalidOperationException("ArrayList is Empty.");
            }

            E TempData = default(E);

            if((Position >= 1) && (Position <= List.Length)) {
                TempData = List[Position];

                if(Position <= NumOfElements) {
                    List[Position] = default(E);
                    FillIn(Position);
                } else {
                    List[Position] = default(E);
                }
            } else {
                throw new ArgumentOutOfRangeException("Position is outside of List bounds.");
            }

            NumOfElements--;
            return TempData;
        }


        public E Replace(int Position, E NewEntry)
        {
            CheckInitialization();

            if(IsEmpty()) {
                throw new InvalidOperationException("ArrayList is Empty.");
            }

            E TempData = default(E);

            if((Position >= 1) && (Position <= List.Length)) {
                TempData = List[Position];
                List[Position] = NewEntry;
            } else {
                throw new ArgumentOutOfRangeException("Position is outside of List bounds.");
            }

            return TempData;
        }

        public E[] ToArray()
        {
            CheckInitialization();

            E[] TempArray = new E[List.Length - 1];

            if(IsEmpty()) {
                return TempArray;
            }

            for(int i = 1; i < List.Length; i++) {
                TempArray[i - 1] = List[i];
            }

            return TempArray;
        }
    }
}