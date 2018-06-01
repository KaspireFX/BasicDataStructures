using System;

namespace DataStructures.Queues {

    public class LinkedQueue<E> : IQueueInterface<E>
    {
        private Node FrontNode;
        private Node BackNode;
        private bool Initialized = false;
        public int NumOfElements { get; private set; } = 0;

        public LinkedQueue() {
            FrontNode = null;
            BackNode = null;
            NumOfElements = 0;
            Initialized = true;
        }

        public void Clear()
        {
            FrontNode = null;
            BackNode = null;
            NumOfElements = 0;
        }

        public E Dequeue()
        {
            E TempData = GetFront();
            FrontNode.Data = default(E);
            FrontNode = FrontNode.Next;
            NumOfElements--;
            return TempData;
        }

        public void Enqueue(E NewEntry)
        {
            Node NewNode = new Node(NewEntry);

            if(IsEmpty()) {
                FrontNode = NewNode;
            } else {
                BackNode.Next = NewNode;
                BackNode = NewNode;
            }

            NumOfElements++;
        }

        public E GetFront()
        {
            return FrontNode.Data;
        }

        public bool IsEmpty()
        {
            return (NumOfElements == 0) && (FrontNode == null && BackNode == null);
        }

        internal class Node {
            internal Node Next { get; set; }
            internal E Data { get; set; }

            internal Node() {
                this.Next = null;
                this.Data = default(E);
            }

            internal Node(E NodeData) {
                this.Next = null;
                this.Data = NodeData;
            }

            internal Node(Node NextNode, E NodeData) {
                this.Next = NextNode;
                this.Data = NodeData;
            }
        }   
    }
}