using System.Collections.Generic;

namespace GenericApp
{
    public interface IMultiDictionary<TK, TV>
    {
        void Add(TK key, TV value);
        bool Remove(TK key);
        bool Remove(TK key, TV value);
        void Clear();
        bool ContainsKey(TK key);
        bool Contains(TK key, TV value);
        ICollection<TK> Keys { get; }
        ICollection<LinkedList<TV>> Values { get; }
        int Count { get; }
    }
}
