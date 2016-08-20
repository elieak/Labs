using System;
using System.Threading;

namespace Queues
{
    class Program
    {
        static LimitedQueue<int> _limitQueue;
        static void Main(string[] args)
        {
            _limitQueue = new LimitedQueue<int>(300);
            ThreadPool.QueueUserWorkItem(add);
            ThreadPool.QueueUserWorkItem(remove);
            Console.ReadLine();
        }

        private static void add(object obj)
        {
            for (var i = 0; i < 500; i++)
                _limitQueue.Enque(i);

        }
        private static void remove(object obj)
        {
            for (var i = 0; i < 500; i++)
            {
                Console.WriteLine($"{_limitQueue.Deque()} Was Removed from the queue");
            }
        }
    }
}
