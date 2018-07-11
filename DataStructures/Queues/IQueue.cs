/*
Author: Jacob Chandler
File: IQueue.cs
Version: 1.0.1
Description: This file is the Interface file for Queue implementation.
Date of Comment: 06:01:2018
 */

using System;

namespace DataStructures.Queues {

    public interface IQueue<T> {

        int Count { get; }

        void Enqueue(T NewEntry);

        T Dequeue();

        T GetFront();

        bool IsEmpty();

        void Empty();
    }
}