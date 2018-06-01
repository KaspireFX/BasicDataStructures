using System;

namespace DataStructures.Queues {

    public interface IQueueInterface<T> {

        void Enqueue(T NewEntry);

        T Dequeue();

        T GetFront();

        bool IsEmpty();

        void Clear();
    }
}