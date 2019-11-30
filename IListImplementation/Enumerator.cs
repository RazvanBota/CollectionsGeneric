using System;
using System.Collections;
using System.Collections.Generic;

namespace IListImplementation
{
    class Enumerator<T> : IEnumerator<T>
    {
        private int curentIndex = -1;
        private readonly List<T> list;

        public Enumerator(List<T> list)
        {
            this.list = list;
        }

        public T Current {
            get 
            {
                return list[curentIndex];
            }
        }

        object IEnumerator.Current => Current;

        void IDisposable.Dispose() { }

        public bool MoveNext()
        {
            curentIndex++;
            return list.Count > curentIndex;
        }

        public void Reset()
        {
            curentIndex = -1;
        }
    }
}
