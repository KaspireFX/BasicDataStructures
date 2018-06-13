/*
Author: Jacob Chandler
File: LinkedDictionary.cs
Version 1.0.1
Description: This file is the LinkedDictionary class file which implements IDictionaryInterface.
Date of Comment: 06:11:2018
 */

using System;

namespace DataStructures.Dictionaries {

    public class LinkedDictionary<K, E> : IDictionaryInterface<K, E>
    {
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
            if(!Initialized) {
                throw new InvalidOperationException("LinkedDictionary was not initialized correctly.");
            }
        }

        private Node LocateNode(K Key) {
            Node TraversalNode = FrontNode;

            while(!Key.Equals(TraversalNode.Key)) {
                TraversalNode = TraversalNode.Next;
                if(TraversalNode == null) {
                    break;
                }
            }

            return TraversalNode;
        }

        public void Add(K Key, E Entry)
        {
            CheckInitialization();
            Node NewNode = new Node(Key, Entry);

            if(FrontNode == null) {
                FrontNode = NewNode;
                BackNode = FrontNode;
            } else {
                Node NodeWithKey = LocateNode(Key);

                if(NodeWithKey != null) {
                    NodeWithKey.Data = Entry;
                } else {
                    BackNode.Next = NewNode;
                    BackNode = NewNode;
                }
            }
        }

        public bool Contains(K Key)
        {
            CheckInitialization();

            return LocateNode(Key) != null;
        }

        public void Empty()
        {
            CheckInitialization();

            FrontNode = null;
            BackNode = null;
        }

        public E GetValue(K Key)
        {
            CheckInitialization();

            if(IsEmpty()) {
                throw new InvalidOperationException("Cannot get a value from an empty dictionary.");
            }

            Node NodeWithKey = LocateNode(Key);
            if(NodeWithKey != null) {
                return NodeWithKey.Data;
            } else {
                throw new ArgumentOutOfRangeException("Key does not exist in dictionary.");
            }
        }

        public bool IsEmpty()
        {
            return FrontNode == null;
        }

        public E Remove(K Key)
        {
            CheckInitialization();

            if(IsEmpty()) {
                throw new InvalidOperationException("Cannot remove entry from empty dictionary.");
            }

            Node NodeWithKey = LocateNode(Key);

            if(NodeWithKey.Equals(FrontNode)) {
                FrontNode = FrontNode.Next;
            } else if(NodeWithKey.Equals(BackNode)) {
                BackNode = null;
            } else {
                //TODO: Fix me
            }
        }

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
        }
    }
}