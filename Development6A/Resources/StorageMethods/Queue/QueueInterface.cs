using System;
using ExtensionMethods;

namespace Development6A.Resources
{
    public interface QueueInterface<T>
    {
        void EnQueue(T e);
        Option<T> Peek();
        Option<T> DeQueue();
        bool isEmpty();
    }
}