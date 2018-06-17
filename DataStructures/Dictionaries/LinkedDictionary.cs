/*
Author: Jacob Chandler
File: LinkedDictionary.cs
Version 1.0.1
Description: This file is the LinkedDictionary class file which implements IDictionaryInterface.
Date of Comment: 06:11:2018
 */

using System;
using DataStructures.Iterator;

namespace DataStructures.Dictionaries {

    public class LinkedDictionary<K, E> : IDictionaryInterface<K, E> {
        private Node FrontNode;
        private Node BackNode;
        bool Initialized = false;
        public int Count { get; private set; }

        public LinkedDictionary() {
            FrontNode = null;
            BackNode = null;
            Count = 0;
            Initialized = true;
        }

        private void CheckInitialization() {
            if (!Initialized) {
                throw new InvalidOperationException("LinkedDictionary was not initialized correctly.");
            }
        }

        private Node LocateNode(K Key) {
            Node TraversalNode = FrontNode;

            while (!Key.Equals(TraversalNode.Key)) {
                TraversalNode = TraversalNode.Next;
                if (TraversalNode == null) {
                    break;
                }
            }

            return TraversalNode;
        }

        public void Add(K Key, E Entry) {
            CheckInitialization();
            Node NewNode = new Node(Key, Entry);

            if (FrontNode == null) {
                FrontNode = NewNode;
                BackNode = FrontNode;
            } else {
                Node NodeWithKey = LocateNode(Key);

                if (NodeWithKey != null) {
                    NodeWithKey.Data = Entry;
                } else {
                    Node Copy = BackNode;
                    BackNode.Next = NewNode;
                    BackNode = NewNode;
                    BackNode.Previous = Copy;
                }
            }
            Count++;
        }

        public bool Contains(K Key) {
            CheckInitialization();

            return LocateNode(Key)!= null;
        }

        public void Empty() {
            CheckInitialization();

            FrontNode = null;
            BackNode = null;
        }

        public E GetValue(K Key) {
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Cannot get a value from an empty dictionary.");
            }

            Node NodeWithKey = LocateNode(Key);
            if (NodeWithKey != null) {
                return NodeWithKey.Data;
            } else {
                throw new ArgumentOutOfRangeException("Key does not exist in dictionary.");
            }
        }

        public bool IsEmpty() {
            return FrontNode == null;
        }

        public E Remove(K Key) {
            // TODO: This method is really messy, may figure out a way to clean up this code later.
            CheckInitialization();

            if (IsEmpty()) {
                throw new InvalidOperationException("Cannot remove entry from empty dictionary.");
            }

            Node NodeWithKey = LocateNode(Key);
            E Data = default(E);

            if (NodeWithKey == null) {
                throw new ArgumentOutOfRangeException("Key does not exist in dictionary, nothing removed.");
            }

            if (NodeWithKey == FrontNode) {
                Data = FrontNode.Data;
                FrontNode = FrontNode.Next;
                FrontNode.Previous = null;
            } else if (NodeWithKey == BackNode) {
                BackNode = BackNode.Previous;
            } else {
                Data = NodeWithKey.Data;
                Node Before = NodeWithKey.Previous;
                Node After = NodeWithKey.Next;

                Before.Next = After;
                After.Previous = Before;
            }

            return Data;
        }

        public IIteratorInterface<E> ValueIterator => new LinkedDictionaryValueIterator(this);

        internal class Node {
            internal K Key { get; }
            internal E Data { get; set; }
            internal Node Next { get; set; }
            internal Node Previous { get; set; }

            internal Node() {
                this.Key = default(K);
                this.Data = default(E);
                this.Next = null;
                this.Previous = null;
            }

            internal Node(K NodeKey, E NodeData) {
                this.Key = NodeKey;
                this.Data = NodeData;
                this.Next = null;
                this.Previous = null;
            }
        }

        internal class LinkedDictionaryValueIterator : IIteratorInterface<E> {
            internal LinkedDictionary<K, E> MyDictionary;
            internal bool WasNextCalled = false;
            internal Node CurrentNode;

            internal LinkedDictionaryValueIterator(LinkedDictionary<K, E> ParentDictionary) {
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