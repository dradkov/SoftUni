namespace _01.DataBase.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Database : IEnumerable<int>
    {
        private const int Capacity = 16;

        private int[] storage;

        private int count;

        public Database(params int[] items)
        {
            this.storage = new int[Capacity];

            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public int Count
        {
            get { return this.count; }
        }




        public void Add(int number)
        {
            if (this.count == Capacity)
            {
                throw new InvalidOperationException("The Storage reach Max Capacity");
            }


            this.storage[this.count] = number;
            this.count++;

        }

        public int Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The Storage is Empty");
            }

            var item = this.storage[this.count - 1];

            this.storage[this.count - 1] = default(int);
            this.count--;

            return item;

        }


        public int[] Fetch()
        {
           var result = new int[this.count];
            Array.Copy(this.storage, result, this.count);

            return result;
        }



        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this.storage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
