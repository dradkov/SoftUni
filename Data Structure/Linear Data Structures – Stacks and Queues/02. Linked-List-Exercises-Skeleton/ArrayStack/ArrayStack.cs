using System;


public class ArrayStack<T>
{
    private const int InitialCapacity = 16;
    private T[] elements;
   

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        this.Grow();
        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.IsEmpty())
        {
            throw new ArgumentNullException();
        }

        T element = this.elements[--this.Count];

        this.elements[this.Count] = default(T);

        return element;
    }



    public T[] ToArray()
    {
        var array = new T[this.Count];
        Array.Copy(this.elements, array, this.Count);

        return array;
    }

    private void Grow()
    {
        if (this.Count == this.elements.Length)
        {
            T[] newElements = new T[2 * this.elements.Length];
            Array.Copy(this.elements, newElements, this.Count);
            this.elements = newElements;
        }
    }

    public bool IsEmpty()
    {
        return this.Count == 0;
    }

}

