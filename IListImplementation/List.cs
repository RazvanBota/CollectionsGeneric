using System;
using System.Collections;
using System.Collections.Generic;

namespace IListImplementation
{
    class List<T> : IList<T>
    {
        private T[] list = new T[] { };
        private int size;

        public int Count => size;

        private void EnsureCapacity()
        {
            if (list.Length == 0)
                Array.Resize(ref list, list.Length + 1);

            if (list.Length == Count)
                Array.Resize(ref list, list.Length * 2);
        }

        public void Add(T item)
        {
            if (IsReadOnly)
                throw new NotSupportedException("List is Read-Only!");

            EnsureCapacity();
            list[size++] = item;
        }

        public void Insert(int index, T item)
        {
            if (IsReadOnly)
                throw new NotSupportedException("List is Read-Only!");

            EnsureCapacity();
            for (int i = list.Length - 1; i > index; i--)
                list[i] = list[i - 1];

            list[index] = item;

        }

        public T this[int index]
        {
            get
            {
                if (index > size)
                    throw new IndexOutOfRangeException("Index out of range!");
                else
                    return list[index];
            }
            set
            {
                if (index > size)
                    throw new IndexOutOfRangeException("Index out of range!");
                if (IsReadOnly)
                    throw new NotSupportedException("List is Read-Only!");

                list[index] = value;
            }
        }

        public bool IsReadOnly => false;

        public void Clear()
        {
            if (IsReadOnly)
                throw new NotSupportedException("List is Read-Only!");

            size = 0;
        }

        public bool Contains(T item) => IndexOf(item) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0 || arrayIndex > list.Length)
                throw new IndexOutOfRangeException("Index out of range!");
            if (array.Length < list.Length)
                throw new ArgumentException("Array don't have enough space!");

            for (; arrayIndex < list.Length; arrayIndex++)
                array[arrayIndex] = list[arrayIndex];
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < size; i++)
                if (list[i].Equals(item))
                    return i;
            return -1;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < size; i++)
                if (list[i].Equals(item)) 
                {
                    RemoveAt(i);
                    return true;
                }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
                throw new NotSupportedException("List is Read-Only!");
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException("Index is out of range!");

            for (int i = index; i < list.Length - 1; i++)
                list[i] = list[i + 1];
            size--;
        }

        public IEnumerator<T> GetEnumerator() => new Enumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}