using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ExtensionMethods;

namespace Development6A.Resources.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> root { get; private set; }
        public int Count { get; private set; }

        // Private Pre-Order function for recursive use.
        private DoublyLinkedList<T> PreOrder(BinaryTreeNode<T> CurrentNode, DoublyLinkedList<T> Collenction)
        {
            if (CurrentNode != null)
            {
                Collenction.InsertOnEnd(CurrentNode.value);
                Collenction = PreOrder(CurrentNode.leftSide, Collenction);
                Collenction = PreOrder(CurrentNode.rightSide, Collenction);
            }
            return Collenction;
        }

        /// <summary>
        /// Pre-order traversing a binary tree.
        /// It return an doublyLinkedList of a Collection in pre order of the tree.
        /// </summary>
        /// <returns>DoublyLinkedList<T></returns>
        public DoublyLinkedList<T> PreOrder()
        {
            return PreOrder(this.root, new DoublyLinkedList<T>());
        }

        // Private In-Order function for recursive use.
        private DoublyLinkedList<T> InOrder(BinaryTreeNode<T> CurrentNode, DoublyLinkedList<T> Collection)
        {
            if (CurrentNode != null)
            {
                Collection = PreOrder(CurrentNode.leftSide, Collection);
                Collection.InsertOnEnd(CurrentNode.value);
                Collection = PreOrder(CurrentNode.rightSide, Collection);
            }

            return Collection;
        }

        /// <summary>
        /// In-Order traversing a binary tree.
        /// It return an doublyLinkedList of a Collection in pre order of the tree.
        /// </summary>
        /// <returns>DoublyLinkedList<T></returns>
        public DoublyLinkedList<T> InOrder()
        {
            return InOrder(this.root, new DoublyLinkedList<T>());
        }

        // Private Post-Order function for recursive use.
        private DoublyLinkedList<T> PostOrder(BinaryTreeNode<T> CurrentNode, DoublyLinkedList<T> Collection)
        {
            if (CurrentNode != null)
            {
                Collection = PreOrder(CurrentNode.leftSide, Collection);
                Collection = PreOrder(CurrentNode.rightSide, Collection);
                Collection.InsertOnEnd(CurrentNode.value);
            }

            return Collection;
        }

        /// <summary>
        /// Post-Order traversing a binary tree.
        /// It return an doublyLinkedList of a Collection in pre order of the tree.
        /// </summary>
        /// <returns>DoublyLinkedList<T></returns>
        public DoublyLinkedList<T> PostOrder()
        {
            return PostOrder(this.root, new DoublyLinkedList<T>());
        }

        // Calculates the minimum of the tree.
        private BinaryTreeNode<T> TreeMinimum(BinaryTreeNode<T> CurrentNode)
        {
            while (CurrentNode.leftSide != null)
            {
                CurrentNode = CurrentNode.leftSide;
            }

            return CurrentNode;
        }

        // TreeSuccessor
        private BinaryTreeNode<T> TreeSuccessor(BinaryTreeNode<T> CurrentNode)
        {
            if (CurrentNode.rightSide != null)
            {
                return TreeMinimum(CurrentNode.rightSide);
            }

            BinaryTreeNode<T> SelectedNode = CurrentNode.parent;
            while (SelectedNode != null && CurrentNode == SelectedNode.rightSide)
            {
                CurrentNode = SelectedNode;
                SelectedNode = SelectedNode.parent;
            }

            return SelectedNode;
        }

        // Private Search function for recusive use.
        private BinaryTreeNode<T> Search(BinaryTreeNode<T> CurrentNode, T value)
        {
            if (CurrentNode == null || value.GelijkAan(CurrentNode.value))
            {
                return CurrentNode;
            }

            if (value.LessThen(CurrentNode.value))
            {
                return Search(CurrentNode.leftSide, value);
            }

            return Search(CurrentNode.rightSide, value);
        }

        /// <summary>
        /// Search function to check if an item is in the tree.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Option<BinaryTreeNode<T>></returns>
        public Option<BinaryTreeNode<T>> Search(T value)
        {
            BinaryTreeNode<T> tempnode = Search(this.root, value);
            if (tempnode == null)
            {
                return new Empty<BinaryTreeNode<T>>();
            }

            return new Some<BinaryTreeNode<T>>() { data = tempnode };
        }

        /// <summary>
        /// It ads an value to the tree.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            // Create a node that is current select for adding an leaf.
            BinaryTreeNode<T> SelectedNode = null;
            // Node to loop through for adding an leaf.
            BinaryTreeNode<T> CurrentNode = this.root;

            // Loop to check and select where to add an leaf.
            while (CurrentNode != null)
            {
                SelectedNode = CurrentNode;
                if (value.LessThen(CurrentNode.value))
                {
                    CurrentNode = CurrentNode.leftSide;
                }
                else
                {
                    CurrentNode = CurrentNode.rightSide;
                }
            }

            // Check if the leaf must be added to the root/
            if (SelectedNode == null)
            {
                // Add the leaf to the root.
                this.root = new BinaryTreeNode<T>() { value = value };
            }
            // Check if the leaf must be added to the leftside.
            else if(value.LessThen(SelectedNode.value))
            {
                // Add the leaf to the rightside.
                SelectedNode.leftSide = new BinaryTreeNode<T>() { value = value, parent = SelectedNode};
            }
            else
            {
                // Add the leaf to the leftside.
                SelectedNode.rightSide = new BinaryTreeNode<T>() { value = value, parent = SelectedNode};
            }

            this.Count++;
        }

        // TransPlant
        private void Transplant(BinaryTreeNode<T> u, BinaryTreeNode<T> v)
        {
            if (u.parent == null)
            {
                this.root = v;
            } else if (u == u.parent.leftSide)
            {
                u.parent.leftSide = v;
            }
            else
            {
                u.parent.rightSide = v;
            }

            if (v != null)
            {
                v.parent = u.parent;
            }
        }

        /// <summary>
        /// It remove's an value from the tree.
        /// </summary>
        /// <param name="value"></param>
        public bool Remove(T value)
        {
            Option<BinaryTreeNode<T>> tempStorage = Search(value);
            if (!tempStorage.empty)
            {
                BinaryTreeNode<T> RemovedNode = tempStorage.data;
                if (RemovedNode.leftSide == null)
                {
                    this.Transplant(RemovedNode, RemovedNode.rightSide);
                }
                else if (RemovedNode.rightSide == null)
                {
                    this.Transplant(RemovedNode, RemovedNode.leftSide);
                }
                else
                {
                    BinaryTreeNode<T> SuccessorofRemovedNode = this.TreeMinimum(RemovedNode.rightSide);
                    if (SuccessorofRemovedNode.parent != RemovedNode)
                    {
                        Transplant(SuccessorofRemovedNode, SuccessorofRemovedNode.rightSide);
                        SuccessorofRemovedNode.rightSide = RemovedNode.rightSide;
                        SuccessorofRemovedNode.rightSide.parent = SuccessorofRemovedNode;
                    }

                    Transplant(RemovedNode, SuccessorofRemovedNode);
                    SuccessorofRemovedNode.leftSide = RemovedNode.leftSide;
                    SuccessorofRemovedNode.leftSide.parent = SuccessorofRemovedNode;
                }

                this.Count--;
                return true;
            }

            return false;
        }
    }
}