using System;
using System.Collections.Generic;
using System.Threading;

namespace Queues
{
    internal class LimitedQueue<T>
    {
        private readonly SemaphoreSlim _semaphoreRemove, _semaphoreAdd;
        private readonly Queue<T> queue;

        public LimitedQueue(int maximumNumberOfItems)
        {
            _semaphoreRemove = new SemaphoreSlim(0);
            _semaphoreAdd = new SemaphoreSlim(maximumNumberOfItems);
            queue = new Queue<T>();
        }
        public void Enque(T item)
        {
            _semaphoreAdd.Wait();

            lock (queue)
            {
                queue.Enqueue(item);
                Console.WriteLine($"{queue.Count} Was added To the Queue");
            }

            _semaphoreRemove.Release();
        }

        public T Deque()
        {
            T item;
            _semaphoreRemove.Wait();
            lock (queue)
            {
                item = queue.Dequeue();
            }
            _semaphoreAdd.Release();
            return item;
        }
    }
}