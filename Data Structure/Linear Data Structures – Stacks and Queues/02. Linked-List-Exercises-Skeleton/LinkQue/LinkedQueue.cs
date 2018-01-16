using System;

public class LinkedQueue<T>
{

    private QueueNode<T> head;
    private QueueNode<T> tail;


    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        QueueNode<T> newNode  = new QueueNode<T>(element);

        if (this.IsEmpty())
        {
            this.head = newNode;
            this.tail = newNode;

        }
        else
        {           
            newNode.PrevNode = this.tail;
            this.tail.NextNode = newNode;
            this.tail = newNode;
        }
        this.Count++;
    }

    public T Dequeue()
    {

        if (this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        T returnElement = this.head.Value;

        this.head = this.head.NextNode;
        this.Count--;

        return returnElement;
    }

    public T[] ToArray()
    {
        T[] newArray = new T[this.Count];

        var firstNode = this.head;

        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = firstNode.Value;
            firstNode = firstNode.NextNode;

        }

        return newArray;
    }

    private bool IsEmpty()
    {
        return this.head == null && this.tail == null;
    }

    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }


        public T Value { get; private set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }
    }
}
