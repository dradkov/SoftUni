using System;
using System.Collections.Generic;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
{
    private Node root;

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

    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);
        return node;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
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

    private BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }

    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }

    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {

        this.root = this.DeleteMin(this.root);
        //if (this.root == null)
        //{
        //    return;
        //}

        //Node current = this.root;
        //Node parent = null;
        //while (current.Left != null)
        //{
        //    parent = current;
        //    current = current.Left;
        //}

        //if (parent == null)
        //{
        //    this.root = this.root.Right;
        //}
        //else
        //{
        //    parent.Left = current.Right;
        //}
    }

    private Node DeleteMin(Node node)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }
        if (node.Left == null)
        {
            return node.Right;
        }

        node.Left = this.DeleteMin(node.Left);

        node.Count = node.Count - 1;

        return node;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public void Delete(T element)
    {
        if (this.root == null || !this.Contains(element))
        {
            throw new NullReferenceException();
        }

        this.root = this.Delete(element, this.root);

    }

    private Node Delete(T element, Node node)
    {

        if (node == null)
        {
            return null;
        }

        int compare = element.CompareTo(node.Value);

        if (compare<0)
        {
            node.Left = this.Delete(element, node.Left);
        }
        if (compare>0)
        {
            node.Right = this.Delete(element,node.Right);
        }
        else
        {
            if (node.Left==null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            node.Value = this.MinValue(node.Right);

            node.Right = this.Delete(node.Value, node.Right);

        }
        return node;
    }

    private T MinValue(Node node)
    {
        T minValue = node.Value;
        while (node.Left != null)
        {
            minValue = node.Left.Value;
            node = node.Left;
        }

        return minValue;
    }

    public void DeleteMax()
    {
        this.root = this.DeleteMax(this.root);
        //if (this.root == null)
        //{
        //    return;
        //}

        //Node current = this.root;
        //Node parent = null;

        //while (current.Right != null)
        //{
        //    parent = current;
        //    current = current.Right;
        //}
        //if (parent == null)
        //{
        //    this.root = this.root.Left;
        //}
        //else
        //{
        //    parent.Right = null;

        //}
    }

    private Node DeleteMax(Node node)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }
        if (node.Right == null)
        {
            return node.Left;
        }

        node.Right = this.DeleteMax(node.Right);

        node.Count = node.Count - 1;

        return node;
    }

    public int Count()
    {
        return this.Count(this.root);

    }

    private int Count(Node node)
    {
        if (node == null)
        {
            return 0;
        }
        return node.Count;
    }

    public int Rank(T element)
    {
        return this.Rank(element, this.root);
    }

    private int Rank(T element, Node node)
    {
        if (node == null)
        {
            return 0;
        }

        int compare = element.CompareTo(node.Value);

        if (compare < 0)
        {
            return this.Rank(element, node.Left);
        }

        if (compare > 0)
        {
            return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
        }

        return this.Count(node.Left);

    }

    public T Select(int rank)
    {
        return this.Select(this.root, rank);
    }

    private T Select(Node node, int rank)
    {
        if (node == null || this.root.Count < rank)
        {
            throw new InvalidOperationException();
        }

        int compare = rank.CompareTo(this.Rank(node.Value));

        if (compare < 0)
        {
          return  this.Select(node.Left, rank);
        }
        if (compare > 0)
        {
            return this.Select(node.Right, rank);
        }
        return node.Value;

    }

    public T Ceiling(T element)
    {
        Node result = this.Ceiling(element, this.root);

        if (result == null)
        {
            throw new NullReferenceException();
        }
        return result.Value;
    }

    private Node Ceiling(T element, Node node)
    {
        if (node == null)
        {
            return null;
        }

        int compare = element.CompareTo(node.Value);

        if (compare>=0)
        {
            return this.Ceiling(element, node.Right);
        }

        Node current = this.Ceiling(element, node.Left);

        if (current == null)
        {
            return node;
        }

        return current;
    }

    public T Floor(T element)
    {
        Node result = this.Floor(element, this.root);

        if (result == null)
        {
            throw new NullReferenceException();
        }

        return result.Value;
    }

    private Node Floor(T element, Node node)
    {
        if (node == null)
        {
            return null;
        }

        int compare = element.CompareTo(node.Value);

        if (compare <= 0)
        {
           return this.Floor(element, node.Left);
        }

        Node current = this.Floor(element, node.Right);


        if (current == null)
        {
            return node;
        }

        return current;
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
        public int Count { get; set; }
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


      
        bst.EachInOrder(Console.WriteLine);
        bst.Delete(8);
        Console.WriteLine();
        Console.WriteLine(bst.Count());
        Console.WriteLine();
        bst.EachInOrder(Console.WriteLine);
    }
}