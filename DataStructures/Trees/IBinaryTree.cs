/*
Author: Jacob Chandler
File: IBinaryTree.cs
Version 1.0.1
Description: This file is the Interface for the BinaryTree data type.
Date of Comment: 08:07:2018
 */
using System;

namespace DataStructures.Trees {

    public interface IBinaryTree<T> : ITree<T> where T : IComparable {
        void SetTree(T rootData);

        void SetTree(T rootData, IBinaryTree<T> leftTree, IBinaryTree<T> rightTree);
    }
}