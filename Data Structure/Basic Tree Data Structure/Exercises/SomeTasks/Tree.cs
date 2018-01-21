
using System;
using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
        foreach (var child in children)
        {
            this.Children.Add(child);
            child.Parent = this;
        }
    }


    public T Value { get; set; }

    public Tree<T> Parent { get; set; }

    public List<Tree<T>> Children { get; private set; }

    public void PrintNode(int indent = 0)
    {


        Console.WriteLine(new string(' ', indent) + this.Value);

        foreach (var child in this.Children)
        {
            child.PrintNode(indent + 2);
        }
    }


}

