/*
Author: Jacob Chandler
File: IList.cs
Version 1.0.1
Description: This file is the Interface for the list data type.
Date of Comment: 06:02:2018
 */

using System;

namespace DataStructures.Lists {

    public interface IList<T> {

        int Count { get; }

        void Add(T Entry);

        void Add(int Position, T Entry);

        T Remove(int Position);

        void Empty();

        T Replace(int Position, T NewEntry);

        T IndexOf(int Position);

        T[] ToArray();

        bool Contains(T AnEntry);

        bool IsEmpty();
    }
}