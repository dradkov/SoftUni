
using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private const int colectionLength = 2;

    private T[] data;



    public ReversedList()
    {
        this.data = new T[colectionLength];
    }

    public int Count { get; set; }

    public int Capacity => this.data.Length;


    public T this[int index]
    {
        get
        {

            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.data[index];

        }

        set
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.data[index] = value;
        }
    }


    public void Add(T element)
    {
        if (this.Count == this.data.Length)
        {
            OptimizeCapacity(true);
        }

        this.data[this.Count] = element;
        this.Count++;
    }

    //removing element by index
    public void Remove(int index)
    {
        if (this.data.Length == 2 * this.Count)
        {
            this.OptimizeCapacity(false);
        }
        if (index >= this.Count || index < 0)
        {
            throw new IndexOutOfRangeException("Index was outside the bounds of the array");
        }
        T[] helpArray = new T[this.data.Length];
        Array.Copy(this.data, 0, helpArray, 0, index);
        Array.Copy(this.data, index + 1, helpArray, index, this.data.Length - index - 1);
        this.data = helpArray;
        this.Count--;
    }

    // clearing the list
    public void Clear()
    {
        this.data = new T[colectionLength];
        this.Count = 0;
    }

    private void OptimizeCapacity(bool increase)
    {
        int newSize;
        if (increase)
        {
            newSize = this.Count * 2;
        }
        else
        {
            newSize = this.data.Length / 2;
        }
        Array.Resize<T>(ref this.data, newSize);
    }


    public IEnumerator<T> GetEnumerator()
    {
        int currentIndex = this.Count - 1;

        while (currentIndex != 0)
        {
            yield return this.data[currentIndex];
            currentIndex--;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

