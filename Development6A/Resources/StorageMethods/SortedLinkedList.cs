using System;
using ExtensionMethods;
using System.Collections.Generic;

namespace Development6A.Resources
{
    public class SortedLinkedList<T> where T : IComparable
    {
        public node<T> StartingNode;

        public node<T> Search(T key)
        {
            node<T> p = StartingNode;
            while (p != null && p.Data.NietGelijkAan(key))
            {
                p = p.Next;
            }

            return p;
        }

        public void Insert(T key)
        {
            if (StartingNode == null || StartingNode.Data.GreaterThen(key))
            {
                StartingNode = new node<T>(StartingNode, key);
                return;
            }

            node<T> x = StartingNode;
            while (x.Next != null && x.Next.Data.LessThenOREqual(key))
            {
                x = x.Next;
            }
            x.Next = new node<T>(x.Next, key);
        }

        public void Delete(T key)
        {
            if (StartingNode == null || StartingNode.Data.GreaterThen(key))
            {
                return;
            } else if (StartingNode.Data.GelijkAan(key))
            {
                StartingNode = StartingNode.Next;
                return;
            }

            node<T> x = StartingNode;

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
    }

    public class node<T> where T : IComparable
    {
        public node<T> Next;
        public T Data;

        public node(node<T> Next, T Data)
        {
            this.Next = Next;
            this.Data = Data;
        }
    }
}