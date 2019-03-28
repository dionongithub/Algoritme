using System;
using ExtensionMethods;
using System.Collections.Generic;

namespace Development6A.Resources
{
    public class DoublyLinkedList<T> where T : IComparable
    {
        public Doublynode<T> FirstNode;
        public Doublynode<T> LastNode;
        public int size;

        public DoublyLinkedList()
        {
            this.size = 0;
        }

        public Doublynode<T> Search(T key)
        {
            Doublynode<T> p = FirstNode;
            while (p != null && p.Data.NietGelijkAan(key))
            {
                p = p.Next;
            }

            return p;
        }

        public void InsertOnBeginning(T key)
        {
            this.size++;
            Doublynode<T> NewDoublyNode = new Doublynode<T>(this.FirstNode, null, key);
            if (this.FirstNode != null)
            {
                this.FirstNode.Prev = NewDoublyNode;
            }

            this.FirstNode = NewDoublyNode;

            if (this.LastNode == null)
            {
                this.LastNode = FirstNode;
            }

        }

        public void InsertBefore(T key, T SearchItem)
        {
            this.size++;
            if (FirstNode == null || FirstNode.Data.GreaterThen(SearchItem))
            {
                FirstNode = new Doublynode<T>(FirstNode, null, key);
                LastNode = FirstNode;
                return;
            }

            Doublynode<T> x = LastNode;
            while (x.Next != null && x.Next.Data.LessThenOREqual(SearchItem))
            {
                x = x.Next;
            }
            x.Next = new Doublynode<T>(x.Next, x.Prev, key);
        }

        public void InsertAfter(T key, T SearchItem)
        {
            this.size++;
            if (LastNode == null || LastNode.Data.GreaterThen(SearchItem))
            {
                LastNode = new Doublynode<T>(null, LastNode, key);
                FirstNode = LastNode;
                return;
            }

            Doublynode<T> x = LastNode;
            while (x.Prev != null && x.Prev.Data.LessThenOREqual(SearchItem))
            {
                x = x.Prev;
            }
            x.Prev = new Doublynode<T>(x.Next, x.Prev, key);
        }

        public void InsertOnEnd(T key)
        {
            this.size++;
            Doublynode<T> NewDoublyNode = new Doublynode<T>(null, this.LastNode, key);
            if (this.LastNode != null)
            {
                this.LastNode.Next = NewDoublyNode;
            }

            this.LastNode = NewDoublyNode;

            if (this.FirstNode == null)
            {
                this.FirstNode = null;
            }

        }

        public void RemoveFromFront(T key)
        {
            this.size--;
            if (this.FirstNode == null || this.FirstNode.Data.GreaterThen(key))
            {
                return;
            } else if (FirstNode.Data.GelijkAan(key))
            {
                FirstNode = FirstNode.Next;
                return;
            }

            Doublynode<T> x = FirstNode;

            while (x.Next != null && x.Next.Data.LessThenOREqual(key))
            {
                if (x.Next.Data.GelijkAan(key))
                {
                    x.Next = x.Next.Next;
                    return;
                }

                x = x.Next;
            }
        }

        public void RemoveFromBack(T key)
        {
            this.size--;
            if (this.LastNode == null || this.LastNode.Data.GreaterThen(key))
            {
                return;
            }
            else if (LastNode.Data.GelijkAan(key))
            {
                LastNode = LastNode.Prev;
                return;
            }

            Doublynode<T> x = LastNode;

            while (x.Prev != null && x.Next.Data.LessThenOREqual(key))
            {
                if (x.Prev.Data.GelijkAan(key))
                {
                    x.Prev = x.Prev.Prev;
                    return;
                }

                x = x.Prev;
            }
        }
    }

    public class Doublynode<T> where T : IComparable
    {
        public Doublynode<T> Next;
        public Doublynode<T> Prev;
        public T Data;

        public Doublynode(Doublynode<T> Next, Doublynode<T> Prev, T Data)
        {
            this.Next = Next;
            this.Data = Data;
            this.Prev = Prev;
        }
    }
}