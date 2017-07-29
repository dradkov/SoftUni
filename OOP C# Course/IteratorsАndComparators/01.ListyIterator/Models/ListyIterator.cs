namespace _01.ListyIterator.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator : IEnumerable<string>
    {
        private IList<string> data;

        private int currentIndex;

        public ListyIterator(params string[] data)
        {

            this.data = new List<string>(data);
            
        }

        public bool Move()
        {

            this.currentIndex++;

            if (currentIndex >= this.data.Count)
            {
                currentIndex--;
                return false;

            }

            return true;
        }
        public bool HasNext()
        {
            if (currentIndex + 1 >= this.data.Count)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {

            Console.WriteLine(this.data[currentIndex]);

        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ",this.data));
        }

        public IEnumerator<string> GetEnumerator()
        {

            this.Reset();
            for (int i = currentIndex; i < this.data.Count; i++)
            {

                yield return this.data[this.currentIndex];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Reset()
        {
            this.currentIndex = 0;
        }
    }

   
}
