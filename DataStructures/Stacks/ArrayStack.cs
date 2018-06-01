using System;

namespace DataStructures.Stacks {

    public class ArrayStack<E> : IStackInterface<E> {
        private E[] StackOfElements;
        private const int DEFAULT_CAPACITY = 10;
        private int NumOfElements;
        private int TopElement;
        private bool Initialized = false;
        public int Length { get; private set; }

        public ArrayStack () : this (DEFAULT_CAPACITY) { }

        public ArrayStack (int capacity) {
            StackOfElements = new E[capacity];
            Length = StackOfElements.Length;
            NumOfElements = 0;
            TopElement = -1;
            Initialized = true;
        }

        public void Empty () {
            CheckInitialization ();

            for (int i = 0; i < NumOfElements; i++) {
                StackOfElements[i] = default (E);
                TopElement--;
            }
            NumOfElements = 0;
        }

        public int GetNumOfElements () {
            CheckInitialization ();

            return NumOfElements;
        }

        public E Peek () {
            CheckInitialization ();

            return StackOfElements[TopElement];
        }

        public E Pop () {
            CheckInitialization ();

            if (IsEmpty ()) {
                throw new IndexOutOfRangeException ("Cannot pop an empty stack.");
            }

            E tmp = StackOfElements[TopElement];
            StackOfElements[TopElement] = default (E);
            NumOfElements--;
            TopElement--;
            return tmp;
        }

        public void Push (E element) {
            CheckInitialization ();

            if (NumOfElements >= StackOfElements.Length) {
                StackOfElements = ReSize ();
            }

            StackOfElements[TopElement + 1] = element;
            NumOfElements++;
            TopElement++;
        }

        public bool IsEmpty () {
            CheckInitialization ();

            return TopElement < 0;
        }

        private void CheckInitialization () {
            if (!Initialized) {
                throw new InvalidOperationException ("Stack not initialized properly.");
            }
        }

        private E[] ReSize () {
            E[] tmp = new E[StackOfElements.Length * 2];

            for (int i = 0; i < StackOfElements.Length; i++) {
                tmp[i] = StackOfElements[i];
            }

            Length = tmp.Length;
            return tmp;
        }
    }
}