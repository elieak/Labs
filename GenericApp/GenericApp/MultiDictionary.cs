using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericApp
{
    public class MultiDictionary<TK,TV> : IMultiDictionary<TK,TV> , IEnumerable<KeyValuePair<TK, IEnumerable<TV>>>
    {
        public  Dictionary<TK, LinkedList<TV>> Dictionary { get; }
        public MultiDictionary()
        {
            Dictionary = new Dictionary<TK, LinkedList<TV>>();
            Count = 0;
        }
        public void Add(TK key, TV value)
        {
            if (typeof(TK).GetCustomAttributes(typeof(KeyAttribute), true) == null)
            {
                throw new Exception("Missing Attribute");
            }
            if (Dictionary.ContainsKey(key))
            {
                Dictionary[key].AddLast(value);
            }
            else
            {
                Dictionary.Add(key, new LinkedList<TV>());
                Dictionary[key].AddLast(value);
            }
            ++Count;
        }

        public bool Remove(TK key)
        {
            if (!Dictionary.Remove(key)) return false;
            --Count;
            return true;
        }

        public bool Remove(TK key, TV value)
        {
            if (!Dictionary.ContainsKey(key))
                return false;
            if (!Dictionary[key].Remove(value))
                return false;
            --Count;
            return true;
        }

        public void Clear()
        {
            Dictionary.Clear();
            Count = 0;
        }

        public bool ContainsKey(TK key)
        {
            return Dictionary.ContainsKey(key);
        }

        public bool Contains(TK key, TV value)
        {
            return Dictionary.ContainsKey(key) && Dictionary[key].Contains(value);
        }

        public ICollection<TK> Keys => Dictionary.Keys;
        public ICollection<LinkedList<TV>> Values => Dictionary.Values;
        public int Count { get; private set; }

        public IEnumerator<KeyValuePair<TK, IEnumerable<TV>>> GetEnumerator()
        {
            var list = Dictionary.Select(item => new KeyValuePair<
                TK, IEnumerable<TV>>(item.Key, item.Value)).ToList();

            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class KeyAttribute : Attribute
    {
        
    }
}
