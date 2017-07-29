namespace _03.Stack.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        private Stack<T> stack;

        public CustomStack()
        {
            this.stack = new Stack<T>();
        }


        public void Push(T element)
        {
            stack.Push(element);
        }

        public void Pop()
        {
            this.stack.Pop();

        }



        public IEnumerator<T> GetEnumerator()
        {           
            var count = 0;

            while (count!=2)
            {
                foreach (var element in stack)
                {

                    yield return element;
                }
                count++;
            }         
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
