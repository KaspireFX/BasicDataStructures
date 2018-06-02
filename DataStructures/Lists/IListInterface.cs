using System;

namespace DataStructures.Lists {

    public interface IListInterface<T> {

        void Add(T Entry);

        void Add(int Position, T Entry);

        T Remove(int Position);

        void Clear();

        T Replace(int Position, T NewEntry);

        T GetEntryAt(int Position);

        T[] ToArray();

        bool Contains(T AnEntry);

        bool IsEmpty();
    }
}