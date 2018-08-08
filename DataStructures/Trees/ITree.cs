/*
Author: Jacob Chandler
File: ITree.cs
Version 1.0.1
Description: This file is the Interface for the Tree data type.
Date of Comment: 08:07:2018
 */
using System;

namespace DataStructures.Trees {

    public interface ITree<T> where T : IComparable {

        int Count { get; }
        int Height { get; }

        T GetRoot();

        void Add(T element);

        bool IsEmpty();

        void Empty();
    }
}