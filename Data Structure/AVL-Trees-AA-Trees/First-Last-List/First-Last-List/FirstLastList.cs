using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{

    private LinkedList<T> factory;
    private OrderedBag<LinkedListNode<T>> ordered;
    private OrderedBag<LinkedListNode<T>> orderedReversed;


    public FirstLastList()
    {
        this.factory = new LinkedList<T>();
        this.ordered = new OrderedBag<LinkedListNode<T>>((x, y) => x.Value.CompareTo(y.Value));
        this.orderedReversed = new OrderedBag<LinkedListNode<T>>((x,y)=>  -x.Value.CompareTo(y.Value));
    }


    public int Count
    {
        get { return this.factory.Count; }
    }

    public void Add(T element)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(element);
        this.factory.AddLast(node);
        this.ordered.Add(node);
        this.orderedReversed.Add(node);


    }

    public void Clear()
    {
        this.factory.Clear();
        this.ordered.Clear();
        this.orderedReversed.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        this.ValidCount(count);

        LinkedListNode<T> current = this.factory.First;

        while (count>0)
        {

            yield return current.Value;
            current = current.Next;
            count--;
        }
        
    } 

    public IEnumerable<T> Last(int count)
    {
        this.ValidCount(count);

        LinkedListNode<T> current = this.factory.Last;

        while (count > 0)
        {

            yield return current.Value;
            current = current.Previous;
            count--;
        }
    }

    public IEnumerable<T> Max(int count)
    {
        this.ValidCount(count);

        foreach (var item in this.orderedReversed)
        {

            if (count<=0)
            {
                break;
            }
            yield return item.Value;
            count--;
        }
    }

    public IEnumerable<T> Min(int count)
    {
       this.ValidCount(count);

        foreach (var item in this.ordered)
        {

            if (count <= 0)
            {
                break;
            }
            yield return item.Value;
            count--;
        }
    }

    public int RemoveAll(T element)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(element);

        var range = this.ordered.Range(node, true, node, true);

        foreach (var item in range)
        {
            this.factory.Remove(item); 
        }

        int count = this.ordered.RemoveAllCopies(node);
        this.orderedReversed.RemoveAllCopies(node);

        return count;

    }

    private void ValidCount(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
