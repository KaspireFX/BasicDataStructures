/*
Author: Jacob Chandler
File: IIteratorInterface.cs
Version 1.0.1
Description: This file is the Interface for the Iterator data type.
Date of Comment: 06:07:2018
 */

namespace DataStructures.Lists {

    public interface IIteratorInterface<T> {

        bool HasNext();

        T Next();

        void Reset();

        bool IsEqualTo(T Entry);
    }
}