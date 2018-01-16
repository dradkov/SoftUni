namespace SequenceN_M
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int>[] function =
            {
                n => n + 1,
                n => n + 2,
                n => n * 2,
            };

            foreach (var sequence in ShortestSequence.GetShortestSequences(numbers[0], numbers[1], function))
            {
                Console.WriteLine(string.Join(" -> ", sequence));
                return;
                
            }
        }

        public class Node<T>
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node<T> Previous { get; set; }
        }

        public class ReversedLinkedList<T> : IEnumerable<T>
        {
            public Node<T> Last { get; set; }

            public ReversedLinkedList(Node<T> last)
            {
                this.Last = last;
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (Node<T> current = this.Last; current != null; current = current.Previous)
                    yield return current.Value;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public static class ShortestSequence
        {
            public static IList<IEnumerable<T>> GetShortestSequences<T>(T start, T end, IList<Func<T, T>> functions)
                where T : IComparable<T>
            {
                var results = new List<IEnumerable<T>>();
                var visited = new HashSet<T>();
                var currentNodes = new Queue<Node<T>>();

                visited.Add(start);
                currentNodes.Enqueue(new Node<T>(start));

                while (currentNodes.Count > 0)
                {
                    var nextNodes = new Queue<Node<T>>();

                    var nextVisited = new HashSet<T>();

                    while (currentNodes.Count > 0)
                    {
                        var currentNode = currentNodes.Dequeue();

                        foreach (var function in functions)
                        {
                            T nextElement = function(currentNode.Value);

                            if (nextElement.CompareTo(end) > 0)
                                continue;

                            if (visited.Contains(nextElement))
                                continue;

                            var nextNode = new Node<T>(nextElement);
                            nextNode.Previous = currentNode;

                            nextVisited.Add(nextElement);
                            nextNodes.Enqueue(nextNode);

                            if (nextElement.Equals(end))
                            {
                                var sequence = new ReversedLinkedList<T>(nextNode);
                                results.Add(sequence.Reverse());
                            }
                        }
                    }
                    visited.UnionWith(nextVisited);

                    if (results.Count != 0)
                    {
                        nextNodes.Clear();
                    }
                    currentNodes = nextNodes;
                }
                return results;
            }
        }
    }
}
