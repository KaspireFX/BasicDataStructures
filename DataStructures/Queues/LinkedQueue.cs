using System;

namespace DataStructures.Queues {

    public class LinkedQueue<E> : IQueueInterface<E>
    {
        private Node FrontNode;
        private Node BackNode;
        private int NumOfElements;
        private bool Initialized;

        public LinkedQueue() {
            FrontNode = new Node();
            BackNode = new Node(null, FrontNode, default(E));
            FrontNode.Next = BackNode;
            NumOfElements = 0;
            Initialized = true;
        }

        public void Clear()
        {
            for(int i = 0; i < NumOfElements; i++) {
                Node Temp = new Node();
                BackNode.Previous = Temp;
                BackNode = null;
            }
        }

        public E Dequeue()
        {
            E TempData = FrontNode.Data;
            FrontNode = FrontNode.Next;
            FrontNode.Previous = null;
            NumOfElements--;

            return TempData;
        }

        public void Enqueue(E NewEntry)
        {
            Node NewNode = new Node(NewEntry);

            if(IsEmpty()) {
                FrontNode = NewNode;
                FrontNode.Next = BackNode;
                BackNode.Previous = FrontNode;
            } else {
                NewNode.Previous = BackNode.Previous;
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
            return NumOfElements == 0;
        }

        internal class Node {
            internal Node Previous { get; set; }
            internal Node Next { get; set; }
            internal E Data { get; set; }

            internal Node() {
                this.Previous = null;
                this.Next = null;
                this.Data = default(E);
            }

            internal Node(E NodeData) {
                this.Next = null;
                this.Previous = null;
                this.Data = NodeData;
            }

            internal Node(Node NextNode, Node PreviousNode, E NodeData) {
                this.Next = NextNode;
                this.Previous = PreviousNode;
                this.Data = NodeData;
            }
        }   
    }
}