using System;
using ExtensionMethods;

namespace Development6A.Resources
{
    public class QueueDoublyLinkedList<T> : QueueInterface<T> where T : IComparable
    {
        private DoublyLinkedList<T> DoublyLinkedList;
        public int QueueSize { get; private set; }

        public QueueDoublyLinkedList()
        {
            this.DoublyLinkedList = new DoublyLinkedList<T>();
            this.QueueSize = 0;
        }

        public void EnQueue(T key)
        {
            QueueSize++;
            this.DoublyLinkedList.InsertOnEnd(key);
        }

        public Option<T> Peek()
        {
            if (!this.isEmpty())
            {
                return new Some<T>(this.DoublyLinkedList.FirstNode.Data);
            }
            return new Empty<T>();
        }

        public bool isEmpty()
        {
            if (QueueSize > 0)
            {
                return false;
            }

            return false;
        }

        public Option<T> DeQueue()
        {
            if (!this.isEmpty())
            {
                T tempData = this.DoublyLinkedList.FirstNode.Data;
                this.DoublyLinkedList.RemoveFromFront(tempData);

                QueueSize--;
                return new Some<T>(tempData);
            }

            return new Empty<T>();
        }
    }
}