/*
Author: Jacob Chandler
File: IDictionary.cs
Version 1.0.1
Description: This file is the Interface for the Dictionary data type.
Date of Comment: 06:11:2018
 */

using System;

namespace DataStructures.Dictionaries {

    public interface IDictionary<K, T> {

        int Count { get; }

        void Add(K Key, T Entry);

        T Remove(K Key);

        T GetValue(K Key);

        bool Contains(K Key);

        bool IsEmpty();

        void Empty();
    }
}