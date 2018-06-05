/*
Author: Jacob Chandler
File: LinkedList.cs
Version 1.0.1
Description: This file is the LinkedList class file which implements IListInterface.
Date of Comment: 06:02:2018
 */

using System;

namespace DataStructures.Lists {

    public class LinkedList<E> : IListInterface<E>
    {
        private Node FrontNode;
        public int Count { get; private set; }

        public LinkedList() {
            FrontNode = null;
            Count = 0;
        }

        public void Add(E Entry)
        {
            Node NewNode = new Node(Entry);

            if(IsEmpty()) {
                FrontNode = NewNode;
            } else {
                Node LastNode = GetNodeAt(Count);
                LastNode.Next = NewNode;
            }

            Count++;
        }

        public void Add(int Position, E Entry)
        {
            Node NewNode = new Node(Entry);

            if((Position >= 1) && (Position <= Count)) {
                if(Position == 1) {
                    FrontNode = NewNode;
                } else {
                    Node Before = GetNodeAt(Position - 1);
                    Node After = GetNodeAt(Position + 1);
                    NewNode.Next = After;
                    Before.Next = NewNode;
                }

                Count++;

            } else {
                throw new IndexOutOfRangeException("Illegal position for Add.");
            }
        }

        public void Empty()
        {
            FrontNode = null;
            Count = 0;
        }

        public bool Contains(E AnEntry)
        {
            Node TraversalNode = FrontNode;

            for(int i = 1; i < Count; i++) {
                if(TraversalNode.Data.Equals(AnEntry)) {
                    return true;
                }

                TraversalNode = TraversalNode.Next;
            }

            return false;
        }

        public E IndexOf(int Position)
        {
            if((Position >= 1) && (Position <= Count)) {
                return GetNodeAt(Position).Data;
            } else {
                throw new IndexOutOfRangeException("Illegal position for IndexOf.");
            }
        }

        public bool IsEmpty()
        {
            return FrontNode == null;
        }

        public E Remove(int Position)
        {
            E Data = default(E);

            if((Position >= 1) && (Position <= Count)) {
                if(Position == 1) {
                    Data = FrontNode.Data;
                    FrontNode = FrontNode.Next;
                } else {
                    Node Before = GetNodeAt(Position - 1);
                    Node NodeToRemove = Before.Next;
                    Node After = NodeToRemove.Next;

                    Data = NodeToRemove.Data;
                    Before.Next = After;
                }
                Count--;
                return Data;
            } else {
                throw new IndexOutOfRangeException("Illegal position for Remove.");
            }
        }

        public E Replace(int Position, E NewEntry)
        {
            E Data = default(E);
            Node NewNode = new Node(NewEntry);

            if((Position >= 1) && (Position <= Count)) {
                if(Position == 1) {
                    Data = FrontNode.Data;
                    FrontNode = NewNode;
                } else {
                    Node Before = GetNodeAt(Position);
                    Node NodeToReplace = Before.Next;
                    Node After = NodeToReplace.Next;

                    Data = NodeToReplace.Data;

                    Before.Next = NewNode;
                    NewNode.Next = After;
                }

                Count--;
                return Data;
            } else {
                throw new IndexOutOfRangeException("Illegal position for Replace.");
            }
        }

        public E[] ToArray()
        {
            E[] Array = new E[Count];
            Node TraversalNode = FrontNode;

            for(int i = 0; i < Count; i++) {
                Array[i] = TraversalNode.Data;
                TraversalNode = TraversalNode.Next;
            }

            return Array;
        }

        private Node GetNodeAt(int Index) {
            Node CurrentNode = FrontNode;

            for(int i = 1; i < Index; i++) {
                CurrentNode = CurrentNode.Next;
            }

            return CurrentNode;
        }

        internal class Node {
            internal Node Next { get; set; }
            internal E Data;

            internal Node() {
                this.Next = null;
                this.Data = default(E);
            }

            internal Node(E NodeData) {
                this.Next = null;
                this.Data = NodeData;
            }

            internal Node(Node NextNode, E NodeData) {
                this.Next = NextNode;
                this.Data = NodeData;
            }

        }
    }
}