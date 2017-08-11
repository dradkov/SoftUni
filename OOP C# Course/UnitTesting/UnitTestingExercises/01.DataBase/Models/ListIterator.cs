namespace _01.DataBase.Models
{
    using System;
    using System.Collections.Generic;


    public class ListIterator<T>
    {
        private int index;


        public ListIterator(IEnumerable<T> collection)
        {
            this.Data = new List<T>();
            if (collection is null)
            {
                throw new ArgumentNullException();
            }
            foreach (var item in collection)
            {
                this.Data.Add(item);
            }

        }

        public IList<T> Data { get; }

        public bool HasNext()
        {
            if (this.index + 1 < this.Data.Count)
            {
                return true;
            }
            return false;
        }


        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public string Print()
        {

            if (this.Data.Count > 0)
            {

                return this.Data[this.index].ToString();
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

    }
}
