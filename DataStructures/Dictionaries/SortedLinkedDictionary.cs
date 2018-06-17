/*
Author: Jacob Chandler
File: SortedLinkedDictionary.cs
Version 1.0.1
Description: This file is the SortedLinkedDictionary class file which implements IDictionaryInterface.
Date of Comment: 06:11:2018
 */

using System;
using DataStructures.Iterator;

namespace DataStructures.Dictionaries {

    public class SortedLinkedDictionary<K, E> : IDictionaryInterface<K, E> where K : IComparable {
        private Node FrontNode;
        private bool Initialized = false;
        public int Count { get; private set; }

        public SortedLinkedDictionary() {
            FrontNode = null;
            Initialized = true;
            Count = 0;
        }

        private void CheckInitialization() {
            if (!Initialized) {
                throw new InvalidOperationException("SortedLinkedDictionary was not intialized correctly.");
            }
        }

        public void Add(K Key, E Entry) {
            CheckInitialization();
            FrontNode = Add(FrontNode, Key, Entry);
            Count++;
        }

        private Node Add(Node CurrentNode, K Key, E Entry) {
            if ((CurrentNode == null) || (Key.CompareTo(CurrentNode.Key)) <= 0) {
                CurrentNode = new Node(CurrentNode, Key, Entry);
            } else {
                Node After = Add(CurrentNode.Next, Key, Entry);
                CurrentNode.Next = After;
            }

            return CurrentNode;
        }

        public bool Contains(K Key) {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Cannot check Contains, dictionary is empty.");
            }

            Node TraversalNode = FrontNode;
            for (int i = 0; i < Count; i++) {
                if (TraversalNode.Key.Equals(Key)) {
                    return true;
                }
            }

            return false;
        }

        public void Empty() {
            CheckInitialization();

            FrontNode = null;
        }

        public E GetValue(K Key) {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Cannot get value from empty dictionary.");
            }

            Node TraversalNode = FrontNode;
            E Data = default(E);
            for (int i = 0; i < Count; i++) {
                if (Key.Equals(TraversalNode.Key)) {
                    Data = TraversalNode.Data;
                }
                TraversalNode = TraversalNode.Next;
            }

            if (Data == null) {
                throw new ArgumentOutOfRangeException("Key does not exist in dictionary.");
            } else {
                return Data;
            }

        }

        public bool IsEmpty() {
            CheckInitialization();

            return FrontNode == null;
        }

        public E Remove(K Key) {
            // TODO: This method is also really gross, will probably go back and make more efficient
            // soon.
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Cannot remove frmo empty dictionary.");
            }

            E Data = default(E);
            bool Removed = false;

            if (FrontNode.Key.Equals(Key)) {
                Data = FrontNode.Data;
                FrontNode = FrontNode.Next;
            } else {
                Node TraversalNode = FrontNode;
                while (!Removed) {
                    if (TraversalNode.Next == null) {
                        throw new ArgumentOutOfRangeException("Key does not exist in dictionary, nothing Removed.");
                    } else if (TraversalNode.Next.Key.Equals(Key)) {
                        Data = TraversalNode.Next.Data;
                        Node NextNode = TraversalNode.Next;
                        TraversalNode.Next = NextNode.Next;
                        Removed = true;
                    } else {
                        TraversalNode = TraversalNode.Next;
                    }
                }
            }

            Count--;
            return Data;
        }

        public IIteratorInterface<E> ValueIterator => new LinkedDictionaryValueIterator(this);

        internal class Node {
            internal K Key { get; }
            internal E Data { get; set; }
            internal Node Next { get; set; }

            internal Node() {
                this.Key = default(K);
                this.Data = default(E);
                this.Next = null;
            }

            internal Node(K NodeKey, E NodeData) {
                this.Key = NodeKey;
                this.Data = NodeData;
                this.Next = null;
            }

            internal Node(Node NextNode, K NodeKey, E NodeData) {
                this.Key = NodeKey;
                this.Data = NodeData;
                this.Next = NextNode;
            }
        }

        internal class LinkedDictionaryValueIterator : IIteratorInterface<E> {
            internal SortedLinkedDictionary<K, E> MyDictionary;
            internal bool WasNextCalled = false;
            internal Node CurrentNode;

            internal LinkedDictionaryValueIterator(SortedLinkedDictionary<K, E> ParentDictionary) {
                this.MyDictionary = ParentDictionary;
                CurrentNode = MyDictionary.FrontNode;
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
                    throw new InvalidOperationException("Iterator is at end of Dictionary, cannot iterate further.");
                }
            }

            public void Reset() {
                CurrentNode = MyDictionary.FrontNode;
            }
        }
    }
}