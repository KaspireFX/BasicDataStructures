/*
Author: Jacob Chandler
File: ITreeIterator.cs
Version 1.0.1
Description: This file is the Interface for the TreeIterator data type.
Date of Comment: 08:07:2018
 */
using System;

namespace DataStructures.Iterator {

    public interface ITreeIterator<T> {

        IIterator<T> PreorderIterator();
        IIterator<T> PostorderIterator();
        IIterator<T> InorderIterator();
        IIterator<T> LevelorderIterator();
    }
}