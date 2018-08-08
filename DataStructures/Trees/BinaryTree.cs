/*
Author: Jacob Chandler
File: BinaryTree.cs
Version 1.0.1
Description: This file is the BinaryTree class file which implements IBinaryTree.
Date of Comment: 08:07:2018
 */
using System;

namespace DataStructures.Trees {

    public class BinaryTree<E> : IBinaryTree<E> where E : IComparable {
        private Node RootNode;
        private Node CurrentNode;
        private bool Initialized = false;
        public int Count { get; private set; }
        public int Height { get; private set; }

        public BinaryTree() : this(default(E)) {
        }

        public BinaryTree(E rootData) {
            Initialized = true;
            Count = 1;
            Height = 1;
            RootNode = new Node(rootData);
        }

        public BinaryTree(E rootData, BinaryTree<E> leftTree, BinaryTree<E> rightTree) {
            Initialized = true;
            Count = 1;
            Height = 1;
            RootNode = new Node(leftTree.RootNode, rootData, rightTree.RootNode);
        }

        private void CheckInitialization() {
            if (!Initialized) {
                throw new InvalidOperationException("Binary tree not initialized properly.");
            }
        }

        public void Add(E element) {
            CheckInitialization();

            Add(element, RootNode, 2);
        }

        private void Add(E element, Node currentNode, int height) {
            Node newNode = new Node(element);

            if (IsEmpty()) {
                RootNode = newNode;
                height = 1;
            } else {
                if (newNode.NodeData.CompareTo(currentNode.NodeData) >= 0) {
                    if (currentNode.RightTree != null) {
                        Add(element, currentNode.RightTree, height++);
                    } else {
                        currentNode.RightTree = newNode;
                    }
                } else {
                    if (currentNode.LeftTree != null) {
                        Add(element, currentNode.LeftTree, height++);
                    } else {
                        currentNode.LeftTree = newNode;
                    }
                }
            }

            Height = (height > Height) ? height : Height;
            Count++;
        }

        public void Empty() {
            CheckInitialization();

            RootNode = null;
        }

        public E GetRoot() {
            CheckInitialization();

            return RootNode.NodeData;
        }

        public bool IsEmpty() {
            CheckInitialization();

            return RootNode == null;
        }

        public void SetTree(E rootData) {
            CheckInitialization();

            // TODO: Implement ME!
            throw new NotImplementedException();
        }

        public void SetTree(E rootData, IBinaryTree<E> leftTree, IBinaryTree<E> rightTree) {
            CheckInitialization();

            // TODO: Implement ME!
            throw new NotImplementedException();
        }

        internal class Node {
            internal Node LeftTree { get; set; }
            internal E NodeData { get; set; }
            internal Node RightTree { get; set; }

            internal Node() {
                LeftTree = null;
                NodeData = default(E);
                RightTree = null;
            }

            internal Node(Node leftTree, E nodeData, Node rightTree) {
                LeftTree = leftTree;
                NodeData = nodeData;
                RightTree = rightTree;
            }

            internal Node(Node leftTree, E nodeData) {
                LeftTree = leftTree;
                NodeData = nodeData;
                RightTree = null;
            }

            internal Node(E nodeData, Node rightTree) {
                LeftTree = null;
                NodeData = nodeData;
                RightTree = rightTree;
            }

            internal Node(E nodeData) {
                LeftTree = null;
                NodeData = nodeData;
                RightTree = null;
            }
        }

    }

}