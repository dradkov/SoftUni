﻿using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public class Node
    {

        private T value;
        private Node next;

        public Node(T value)
        {
            this.Value = value;

        }

        public T Value { get => this.value; set => this.value = value; }
        public Node Next { get => this.next; set => this.next = value; }
    }

    public Node Head { get; private set; }
    public Node Tail { get; private set; }


    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node old = this.Head;

        this.Head = new Node(item);

        this.Head.Next = old;

        if (this.Count == 0)
        {
            this.Tail = this.Head;

        }
        this.Count++;
    }

    public void AddLast(T item)
    {
        Node old = this.Tail;
        this.Tail = new Node(item);

        if (this.Count == 0)
        {
            this.Head = this.Tail;
        }
        else
        {
            old.Next = this.Tail;
        }

        this.Count++;


    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T current = this.Head.Value;

        this.Head = this.Head.Next;

        this.Count--;

        if (this.Count == 0)
        {
            this.Tail = null;

        }

        return current;
    }

    public T RemoveLast()
    {

        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }


        T current = this.Tail.Value;


        if (this.Count == 1)
        {
            this.Head = null;
            this.Tail = null;
        }
        else
        {
            Node newTail = this.GetSecondToLast();
            newTail.Next = null;
            this.Tail = newTail;
        }

        this.Count--;



        return current;
    }

    private Node GetSecondToLast()
    {
        Node current = this.Head;

        while (current.Next != this.Tail)
        {
            current = current.Next;
        }
        return current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.Head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

}
