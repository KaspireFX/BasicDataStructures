/*
Author: Jacob Chandler
File: ArrayQueue.cs
Version: 1.0.1
Description: This file is the ArrayQueue class file which implements IQueueInterface.
Date of Comment: 06:01:2018
 */

using System;

namespace DataStructures.Queues {

    public class ArrayQueue<E> : IQueueInterface<E>
    {
        private E[] Queue;
        private bool Initialized;
        private int FrontIndex;
        private int BackIndex;
        private const int DEFAULT_CAPACITY = 10;


        public ArrayQueue() : this(DEFAULT_CAPACITY) {
        }

        public ArrayQueue(int capacity) {
            Queue = new E[capacity];
            FrontIndex = 1;
            BackIndex = 1;
            Initialized = true;
        }

        private void CheckInitialized() {
            if(!Initialized) {
                throw new InvalidOperationException("Queue not Initialized properly.");
            }
        }

        private bool CheckAvailablility()
        {
            if((BackIndex + 1) == FrontIndex) {
                return false;
            }
            return true;
        }

        private void ReSize() {
            E[] NewQueue = new E[Queue.Length * 2];
            int Indexer = FrontIndex;

            while((Indexer % Queue.Length) != BackIndex) {
                NewQueue[Indexer] = Queue[Indexer % Queue.Length];
                Indexer++;
            }

            Queue = NewQueue;
            BackIndex = Indexer;
        }

        public void Clear()
        {
            CheckInitialized();

            if(IsEmpty()) {
                throw new InvalidOperationException("ArrayQueue is Empty.");
            }

            int Indexer = FrontIndex;

            while((Indexer % Queue.Length) != BackIndex) {
                Queue[Indexer % Queue.Length] = default(E);
                Indexer++;
            }
        }

        public E Dequeue()
        {
            CheckInitialized();

            if(IsEmpty()) {
                throw new InvalidOperationException("ArrayQueue is Empty.");
            }

            E Temp = Queue[FrontIndex];
            Queue[FrontIndex] = default(E);
            FrontIndex = (FrontIndex + 1) % Queue.Length;
            return Temp;
        }

        public void Enqueue(E NewEntry)
        {
            CheckInitialized();

            if(CheckAvailablility()) {
                Queue[BackIndex] = NewEntry;
                BackIndex = (BackIndex + 1) % Queue.Length;
            } else {
                ReSize();
                Enqueue(NewEntry);
            }
        }

        public E GetFront()
        {
            CheckInitialized();

            if(IsEmpty()) {
                throw new InvalidOperationException("ArrayQueue is Empty.");
            }

            return Queue[FrontIndex];
        }

        public bool IsEmpty()
        {
            CheckInitialized();
            
            return FrontIndex == BackIndex;
        }
    }
}