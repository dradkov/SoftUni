namespace _04.Froggy.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<long>
    {
        private readonly IList<long> stones;

        public Lake(IList<long> stones)
        {
            this.stones = stones;
        }


        public IEnumerator<long> GetEnumerator()
        {


            for (int i = 0; i < this.stones.Count; i++)
            {

                if (i % 2 == 0)
                {
                    yield return this.stones[i];
                   
                }
               
            }
            for (int i = this.stones.Count - 1; i >= 0; i--)
            {

                if (i % 2 == 1)
                {
                    yield return this.stones[i];

                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
