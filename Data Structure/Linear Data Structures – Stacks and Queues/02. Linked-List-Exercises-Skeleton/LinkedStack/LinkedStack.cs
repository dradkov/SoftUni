namespace LinkedStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedStack<T> : IEnumerable<T>
    {


        public int Count { get; private set; }

        private StackNode top;

        public void Push(T element)
        {
            this.top = new StackNode(element, this.top);

            this.Count++;
        }
        public T Pop()
        {

            if (this.Count == 0)
            {
                throw  new InvalidOperationException();
            }

            T current = this.top.Value;

            this.top = this.top.Next;

            this.Count--;

            return current;
        }

        public T Peek()
        {

            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T current = this.top.Value;


            return current;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            StackNode current = this.top;

            int index = 0;

            while (current != null)
            {
                array[index++] = current.Value;

                current = current.Next;
            }
            return array;
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private class StackNode
        {
            public StackNode(T value, StackNode next)
            {
                this.Value = value;
                this.Next = next;
            }
            public T Value { get; set; }
            public StackNode Next { get; set; }
        }
    }
}
