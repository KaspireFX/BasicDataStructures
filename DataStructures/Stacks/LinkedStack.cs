using System;

namespace DataStructures.Stacks {

    public class LinkedStack<E> : IStackInterface<E>
    {
        private Node TopNode;
        private int NumOfElements;
        private bool Initialized = false;

        public LinkedStack() {
            TopNode = null;
            NumOfElements = 0;
            Initialized = true;
        }

        public void Empty()
        {
            Node tmp;
            while(NumOfElements != 0) {
                tmp = TopNode.Previous;
                TopNode = null;
                TopNode = tmp;
                NumOfElements--;
            }
        }

        public int GetNumOfElements()
        {
            return NumOfElements;
        }

        public bool IsEmpty()
        {
            return TopNode == null;
        }

        public E Peek()
        {
            return TopNode.Data;
        }

        public E Pop()
        {
            E tmp = TopNode.Data;
            TopNode = TopNode.Previous;
            NumOfElements--;
            return tmp;
        }

        public void Push(E element)
        {
            Node NewNode = new Node();
            NewNode.Previous = TopNode;
            TopNode = NewNode;
            TopNode.Data = element;
            NumOfElements++;
        }

        private void CheckInitialization() {
            if(!Initialized) {
                throw new InvalidOperationException("Linked Stack not initialized properly.");
            }
        }

        internal class Node {
            internal Node Previous { get; set;}
            internal E Data { get; set; }

            internal Node() {
                Previous = null;
                Data = default(E);
            }

            internal Node(Node PreviousNode, E NodeData) {
                Previous = PreviousNode;
                Data = NodeData;
            }
        }
    }
}