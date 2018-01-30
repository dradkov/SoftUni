using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{

    private Node root;


    public BinarySearchTree()
    {

    }

    private BinarySearchTree(Node node)
    {
        this.Copy(node);
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);

    }

    public void Insert(T element)
    {
        if (this.root == null)
        {
            this.root = new Node(element);
            return;
        }

        Node current = this.root;
        Node parent = null;

        while (current != null)
        {
            parent = current;

            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        current = new Node(element);

        if (parent.Value.CompareTo(element) < 0)
        {
            parent.Right = current;
        }
        else
        {
            parent.Left = current;
        }

    }


    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public void DeleteMin()
    {

        if (this.root == null)
        {
            return;
        }
        Node current = this.root;
        Node parent = null;


        while (current.Left != null)
        {
            parent = current;
            current = current.Left;
        }
        if (parent == null)
        {
            this.root = this.root.Right;
        }
        else
        {
            parent.Left = current.Right;
        }
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);

    }

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {

            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> range = new Queue<T>();

        this.Range(startRange, endRange, range, this.root);

        return range;
    }

    private void Range(T startRange, T endRange, Queue<T> range, Node node)
    {
        if (node == null)
        {
            return;
        }

        int compareLow = startRange.CompareTo(node.Value);
        int compareHigh = endRange.CompareTo(node.Value);

        if (compareLow < 0)
        {
            this.Range(startRange, endRange, range, node.Left);
        }
        if (compareLow <= 0 && compareHigh >= 0)
        {
            range.Enqueue(node.Value);
        }
        if (compareHigh > 0)
        {
            this.Range(startRange, endRange, range, node.Right);
        }

    }

    public void EachInOrder(Action<T> action)
    {

        this.EachInOrder(this.root, action);

    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;

        }
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);


        BinarySearchTree<int> search = bst.Search(5);



        search.EachInOrder(Console.WriteLine);


    }
}
