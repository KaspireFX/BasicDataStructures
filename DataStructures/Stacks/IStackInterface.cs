using System;

namespace DataStructures.Stacks {

    public interface IStackInterface<T> {

        void Push(T element);

        T Pop();

        T Peek();

        void Empty();

        int GetNumOfElements();

        bool IsEmpty();
    }
}