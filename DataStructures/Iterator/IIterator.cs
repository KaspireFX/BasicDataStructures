/*
Author: Jacob Chandler
File: IIterator.cs
Version 1.0.1
Description: This file is the Interface for the Iterator data type.
Date of Comment: 06:07:2018
 */

namespace DataStructures.Iterator {

    public interface IIterator<T> {

        bool HasNext();

        T Next();

        void Reset();

        bool IsEqualTo(T Entry);
    }
}