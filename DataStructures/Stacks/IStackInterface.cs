/*
Author: Jacob Chandler
File: IStackInterface.cs
Version: 1.0.1
Description: This file is the Interface file for Stack implementation.
Date of Comment: 06:01:2018
 */

using System;

namespace DataStructures.Stacks {

    public interface IStackInterface<T> {

        int Count { get; }

        void Push(T element);

        T Pop();

        T Peek();

        void Empty();

        bool IsEmpty();
    }
}