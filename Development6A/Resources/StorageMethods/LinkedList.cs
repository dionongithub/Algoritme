using System;
using ExtensionMethods;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Development6A.Resources
{
    public class LinkedList<T> where T : IComparable
    {
        public node<T> StartingNode { get; private set; }
        public int size { get; private set; }

        public LinkedList()
        {
            this.size = 0;
            this.StartingNode = null;
        }

        public node<T> Search(T key)
        {
            node<T> p = StartingNode;
            while (p != null && p.Data.NietGelijkAan(key))
            {
                p = p.Next;
            }

            return p;
        }

        public void InsertOnBeginning(T key)
        {
            this.size++;
            node<T> NewNode = new node<T>(this.StartingNode, key);

            this.StartingNode = NewNode;
        }

        public void InsertBefore(T key, T SearchItem)
        {
            this.size++;
            if (StartingNode == null || StartingNode.Data.GreaterThen(SearchItem))
            {
                StartingNode = new node<T>(StartingNode, key);
                return;
            }

            node<T> x = StartingNode;
            while (x.Next != null && x.Next.Data.LessThenOREqual(SearchItem))
            {
                x = x.Next;
            }
            x.Next = new node<T>(x.Next, key);
        }

        public void Remove(T key)
        {
            this.size--;
            if (this.StartingNode == null || this.StartingNode.Data.GreaterThen(key))
            {
                return;
            }
            else if (StartingNode.Data.GelijkAan(key))
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
}