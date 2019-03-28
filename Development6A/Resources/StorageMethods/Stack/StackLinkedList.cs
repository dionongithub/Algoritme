using System;
using ExtensionMethods;

namespace Development6A.Resources
{
    public class StackLinkedList<T> : StackInterface<T> where T : IComparable
    {
        private LinkedList<T> list;
        public int StackSize { get; private set; }
        public StackLinkedList()
        {
            list = new LinkedList<T>();
            this.StackSize = 0;
        }

        public void Push(T key)
        {
            list.InsertOnBeginning(key);
            this.StackSize++;
        }

        public Option<T> Peek()
        {
            if (!this.isEmpty())
            {
                return new Some<T>(this.list.StartingNode.Data);
            }
            return new Empty<T>();
        }

        public bool isEmpty()
        {
            if (this.StackSize > 0)
            {
                return false;
            }

            return true;
        }

        public Option<T> Pop()
        {
            if (!this.isEmpty())
            {
                
                T key = Peek().data;
                list.Remove(key);

                this.StackSize--;
                return new Some<T>(key);
            }

            return new Empty<T>();
        }
    }
}