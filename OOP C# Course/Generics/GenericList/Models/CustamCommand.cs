namespace GenericList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;


    public class CustamCommand<T> : ICustamCommand<T>, IEnumerable<T>
        where T : IComparable<T>
    {

        public CustamCommand()
        {
            this.StoreData = new List<T>();
        }

        public IList<T> StoreData { get; private set; }



        public void Add(T element)
        {
            this.StoreData.Add(element);
        }

        public bool Contains(T element)
        {

            if (this.StoreData.Count != 0)
            {
                if (this.StoreData.Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        public int CountGreaterThan(T element)
        {
            var count = 0;

            foreach (var item in this.StoreData)
            {
                if (item.CompareTo(element) == 1)
                {
                    count++;
                }
            }
            return count;
        }

        public T Max()
        {
            return this.StoreData.Max();
        }

        public T Min()
        {
            return this.StoreData.Min();
        }

        public T Remove(int index)
        {
            var element = this.StoreData.ElementAt(index);
            this.StoreData.RemoveAt(index);

            return element;
        }

        public void Swap(int index1, int index2)
        {
            if (this.StoreData.Count != 0)
            {
                T temp = this.StoreData[index1];
                this.StoreData[index1] = this.StoreData[index2];
                this.StoreData[index2] = temp;
            }
        }

        public void Sort()
        {

            this.StoreData = this.StoreData.OrderBy(x => x).ToList();
        }

        //public override string ToString()
        //{

        //    var sb = new StringBuilder();



        //    foreach (var item in this.StoreData)
        //    {
        //        sb.AppendLine(item.ToString());
        //    }
        //    return sb.ToString().Trim();
        //}

        public IEnumerator<T> GetEnumerator()
        {
            return this.StoreData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.StoreData.GetEnumerator();
        }
    }
}

