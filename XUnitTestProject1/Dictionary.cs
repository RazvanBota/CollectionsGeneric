using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IDictionaryImplementation
{
    class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>>[] arrayList;
        private int size = 0;

        public Dictionary(int capacity)
        {
            arrayList = new List<KeyValuePair<TKey, TValue>>[capacity];
        }

        private int Indexer(TKey key) => Math.Abs(key.GetHashCode()) % arrayList.Length;

        public TValue this[TKey key] {
            get{
                int indexer = Indexer(key);
                if (arrayList[indexer] == null)
                    throw new ArgumentNullException();
                for (int i = 0; i < arrayList[indexer].Count; i++)
                    if (Equals(arrayList[indexer][i].Key, key))
                        return arrayList[indexer][i].Value;
                throw new KeyNotFoundException();
            }
            set {
                if (IsReadOnly)
                    throw new NotSupportedException();
                int indexer = Indexer(key);
                if (arrayList[indexer] == null)
                    throw new ArgumentNullException();
                for (int i = 0; i < arrayList[indexer].Count; i++)
                    if (Equals(arrayList[indexer][i].Key, key))
                        arrayList[indexer][i] = new KeyValuePair<TKey, TValue>(key, value);
            }
        }

        public ICollection<TKey> Keys => this.Select(s => s.Key).ToList();

        public ICollection<TValue> Values => this.Select(s => s.Value).ToList();

        public int Count => size;

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            if (IsReadOnly)
                throw new NotSupportedException();
            foreach (var pair in this)
                if (Equals(pair.Key, key))
                    throw new ArgumentException();
            if (key == null)
                throw new ArgumentNullException();
            int indexer = Indexer(key);
            if (arrayList[indexer] == null)
                arrayList[indexer] = new List<KeyValuePair<TKey, TValue>>();
            arrayList[indexer].Add(new KeyValuePair<TKey, TValue>(key, value));
            size++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            if (IsReadOnly)
                throw new NotSupportedException();
            arrayList = new List<KeyValuePair<TKey, TValue>>[arrayList.Length];
            size = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return TryGetValue(item.Key, out TValue value) && Equals(value, item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            return TryGetValue(key, out TValue value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (arrayIndex > this.Count)
                throw new ArgumentException();
            foreach (var pair in this)
                array[arrayIndex++] = pair;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return arrayList
                .Where(p => p != null)
                .SelectMany(s => s)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            if (IsReadOnly)
                throw new NotSupportedException();
            if (key == null)
                throw new ArgumentNullException();

            int index = Indexer(key);
            var item = arrayList[index].FirstOrDefault(keyVP => keyVP.Key.Equals(key));

            return arrayList[index].Remove(item);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
                throw new ArgumentNullException();

            value = default;
            int i = Indexer(key);
            KeyValuePair<TKey, TValue> item;

            try 
            { 
                item = arrayList[i].First(p => p.Key.Equals(key));
            } catch(ArgumentNullException)
            {
                return false;
            }

            value = item.Value;
            return true;
        }
    }
}
