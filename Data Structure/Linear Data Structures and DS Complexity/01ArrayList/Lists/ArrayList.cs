using System;

public class ArrayList<T>
{

    private const int lenArray = 2;

    private T[] data;

    public ArrayList()
    {
        this.data = new T[lenArray];
    }

    public int Count { get; set; }

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

    public void Add(T item)
    {

        if (this.data.Length == this.Count)
        {
            this.ResizeArray();
        }
        this.data[this.Count++] = item;


    }

    public T RemoveAt(int index)
    {
        if (index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T currentElement = this.data[index];

        this.data[index] = default(T);

        this.RearangeArray(index);
        this.Count--;

        if (this.Count <= this.data.Length / 4)
        {
            this.UpdateArray();
        }

        return currentElement;
    }

    private void UpdateArray()
    {
        T[] newArray = new T[this.data.Length / 2];

        Array.Copy(this.data, newArray, this.data.Length / 2);

        this.data = newArray;

    }

    private void RearangeArray(int index)
    {
        for (int i = index; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }
    }

    private void ResizeArray()
    {
        T[] newArray = new T[this.data.Length * 2];
        Array.Copy(this.data, newArray, this.data.Length);

        this.data = newArray;

    }
}
