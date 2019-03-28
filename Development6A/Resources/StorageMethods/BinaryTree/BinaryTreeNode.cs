using System;

namespace Development6A.Resources.BinaryTree
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T value;
        public BinaryTreeNode<T> leftSide { get; set; }
        public BinaryTreeNode<T> rightSide { get; set; }
        public BinaryTreeNode<T> parent { get; set; }
    }
}