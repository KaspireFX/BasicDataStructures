/*
Author: Jacob Chandler
File: ArrayDictionary.cs
Version 1.0.1
Description: This file is the ArrayDictionary class file which implements IDictionaryInterface.
Date of Comment: 06:11:2018
 */

using System;

namespace DataStructures.Dictionaries {

    public class ArrayDictionary<K, E> : IDictionaryInterface<K, E>
    {
        private Entry<K, E>[] Dictionary;
        private bool Initialized = false;
        private static int DEFAULT_CAPACITY = 10;
        public int Count { get; private set; }

        public ArrayDictionary() : this(DEFAULT_CAPACITY) {
        }

        public ArrayDictionary(int Capacity) {
            Dictionary = new Entry<K, E>[Capacity];
            Initialized = true;
            Count = 0;
        }

        private void CheckInitialization() {
            if(!Initialized) {
                throw new InvalidOperationException("LinkedList was not Initialized correctly.");
            }
        }

        private int LocateIndex(K Key) {
            int Index = 0;
            while((Index < Count) && (!Key.Equals(Dictionary[Index].Key))) {
                Index++;
            }

            return Index;
        }

        private void ReSize() {
            Entry<K, E>[] Temp = new Entry<K, E>[Dictionary.Length * 2];
            for(int i = 0; i < Dictionary.Length; i++) {
                Temp[i] = Dictionary[i];
            }

            Dictionary = Temp;
        }

        public void Add(K Key, E Entry)
        {
            CheckInitialization();

            if(Count == Dictionary.Length) {
                ReSize();
            }

            if((Key == null) || (Entry == null)) {
                throw new ArgumentOutOfRangeException("Cannot have null Key or Entry.");
            } else {
                int KeyIndex = LocateIndex(Key);

                if(KeyIndex < Count) {
                    Dictionary[KeyIndex].Data = Entry;
                } else {
                    Dictionary[Count] = new Entry<K, E>(Key, Entry);
                    Count++;
                }
            }
        }

        public bool Contains(K Key)
        {
            CheckInitialization();

            return LocateIndex(Key) < Count;
        }

        public void Empty()
        {
            CheckInitialization();

            if(IsEmpty()) {
                throw new InvalidOperationException("Dictionary already empty.");
            }

            int Index = Count;
            for(int i = 0; i < Index; i++) {
                Dictionary[i] = null;
                Count--;
            }
        }

        public E GetValue(K Key)
        {
            CheckInitialization();

            return Dictionary[LocateIndex(Key)].Data;
        }

        public bool IsEmpty()
        {
            CheckInitialization();

            return Count == 0;
        }

        public E Remove(K Key)
        {
            CheckInitialization();

            int KeyIndex = LocateIndex(Key);

            if(KeyIndex < Count) {
                E Data = Dictionary[KeyIndex].Data;
                Dictionary[KeyIndex] = Dictionary[Count - 1];
                Dictionary[Count - 1] = null;
                Count--;
                return Data;
            } else {
                throw new ArgumentOutOfRangeException("Key does not exist in Dictionary.");
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
}