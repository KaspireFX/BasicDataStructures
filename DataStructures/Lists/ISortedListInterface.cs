/*
Author: Jacob Chandler
File: ISortedListInterface.cs
Version 1.0.1
Description: This file is the Interface for the SortedList data type.
Date of Comment: 06:10:2018
 */

using System;

namespace DataStructures.Lists {

    public interface ISortedListInterface<T> {

        int Count { get; }
        
        void Add(T Entry);

        T Remove(int Position);

        void Empty();

        T IndexOf(int Position);

        T[] ToArray();

        bool Contains(T AnEntry);

        bool IsEmpty();
    }
}