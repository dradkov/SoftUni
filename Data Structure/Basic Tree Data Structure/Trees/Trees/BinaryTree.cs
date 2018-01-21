using System;
using System.Xml;

public class BinaryTree<T>
{
    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
    }


    public T Value { get; set; }

    public BinaryTree<T> LeftChild { get; set; }

    public BinaryTree<T> RightChild { get; set; }



    public void PrintIndentedPreOrder(int indent = 0)
    {
  
        Console.WriteLine(new string(' ', 2 * indent)+this.Value);

        if (this.LeftChild != null)
        {
            this.LeftChild.PrintIndentedPreOrder(indent + 1);
        }
        if (this.RightChild != null)
        {
            this.RightChild.PrintIndentedPreOrder(indent + 1);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachNodeInOrder(this, action);
       
    }

    private void EachNodeInOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        EachNodeInOrder(node.LeftChild,action);
        action(node.Value);
        EachNodeInOrder(node.RightChild,action);
    }

    public void EachPostOrder(Action<T> action)
    {
        this.EachNodePostOrder(this,action);
    }

    private void EachNodePostOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        EachNodePostOrder(node.LeftChild, action);
        EachNodePostOrder(node.RightChild, action);
        action(node.Value);

    }
}
