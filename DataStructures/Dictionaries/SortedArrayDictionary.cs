/*
Author: Jacob Chandler
File: SortedArrayDictionary.cs
Version 1.0.1
Description: This file is the SortedArrayDictionary class file which implements IDictionaryInterface.
Date of Comment: 06:15:2018
 */

using System;

namespace DataStructures.Dictionaries {

    public class SortedArrayDictionary<K, E> : IDictionaryInterface<K, E> where K : IComparable
    {
        private Entry<K, E>[] Dictionary;
        private bool Initialized;
        private const int DEFAULT_CAPACITY = 10;
        public int Count { get; private set; }

        public SortedArrayDictionary() : this(DEFAULT_CAPACITY) {
        }

        public SortedArrayDictionary(int Capacity) {
            Dictionary = new Entry<K, E>[Capacity];
            Count = 0;
            Initialized = true;
        }

        private void MakeRoom(int Position) {
            for(int i = Count; i >= Position; i--) {
                Dictionary[i + 1] = Dictionary[i];
            }
        }

        private void ReSize() {
            Entry<K, E>[] Temp = new Entry<K, E>[Dictionary.Length * 2];
            for(int i = 0; i < Count; i++) {
                Temp[i] = Dictionary[i];
            }

            Temp = Dictionary;
        }

        public void Add(K Key, E Entry) {
            Add(0, Key, Entry);
            Count++;
        }

        private void Add(int Position, K Key, E Entry)
        {
            if(Count == Dictionary.Length) {
                ReSize();
            }

            if((Key == null) || (Entry == null)) {
                throw new ArgumentOutOfRangeException("Cannot have null Key or Entry.");
            }

            if(IsEmpty()) {
                Dictionary[Position] = new Entry<K, E>(Key, Entry);
            } else {
                if(Dictionary[Position] == null) {
                    Dictionary[Position] = new Entry<K, E>(Key, Entry);
                } else if(Key.CompareTo(Dictionary[Position].Key) >= 0) {
                    Add(Position + 1, Key, Entry);
                } else {
                    MakeRoom(Position);
                    Dictionary[Position] = new Entry<K, E>(Key, Entry);
                }
            }
        }

        public bool Contains(K Key)
        {
            if(IsEmpty()) {
                throw new InvalidOperationException("Cannot check Contains in empty dictionary.");
            }

            for(int i = 0; i < Count; i++) {
                if(Dictionary[i].Key.Equals(Key)) {
                    return true;
                }
            }

            return false;
        }

        public void Empty()
        {
            if(IsEmpty()) {
                throw new InvalidOperationException("Cannot empty already empty dictionary.");
            }

            for(int i = 0; i <= Count; i++) {
                Dictionary[i] = null;
            }
        }

        public E GetValue(K Key)
        {
            if(IsEmpty()) {
                throw new InvalidOperationException("Cannot GetValue from empty Dictionary.");
            }

            int Index = 0;
            while(!Key.Equals(Dictionary[Index].Key)) {
                Index++;
            }

            return Dictionary[Index].Data;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public E Remove(K Key)
        {
            if(IsEmpty()) {
                throw new InvalidOperationException("Cannot remove from empty dictionary.");
            }

            int Index = 0;
            E Data = default(E);
            bool Found = false;

            while(Index < Count) {
                if(Dictionary[Index].Key.Equals(Key)) {
                    Data = Dictionary[Index].Data;
                    Found = true;
                }

                if(Found) {
                    Dictionary[Index] = Dictionary[Index + 1];
                }
                Index++;
            }

            Dictionary[Count - 1] = null;
            Count--;

            return Data;
        }
    }

    internal class Entry<S, T> {
        internal S Key { get; }
        internal T Data { get; set; }

        internal Entry(S SearchKey, T Data) {
            this.Key = SearchKey;
            this.Data = Data;
        }
    }
}