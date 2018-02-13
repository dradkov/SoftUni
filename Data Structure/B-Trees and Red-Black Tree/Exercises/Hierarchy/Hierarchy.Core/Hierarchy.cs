//namespace Hierarchy.Core
//{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using Hierarchy.Core;


public class Hierarchy<T> : IHierarchy<T>
    {
        private Dictionary<T, Node> nodeCollection;
        private Node root;



        public Hierarchy(T root)
        {
            this.root = new Node(root, null);
            this.nodeCollection = new Dictionary<T, Node>()
            {
                [root] = this.root
            };
        }

        public int Count
        {
            get
            {
                return this.nodeCollection.Count;
            }
        }

        public void Add(T element, T child)
        {
            if (!this.nodeCollection.ContainsKey(element) || this.nodeCollection.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node newNode = new Node(child, this.nodeCollection[element]);
            this.nodeCollection[element].Chldren.Add(newNode);
            this.nodeCollection[child] = newNode;

        }

        public void Remove(T element)
        {
            if (!this.nodeCollection.ContainsKey(element))
            {
                throw new ArgumentException();
            }
            if (this.nodeCollection[element].Parent == null)
            {
                throw new InvalidOperationException();
            }

            var parent = this.nodeCollection[element].Parent;
            var childrenList = this.nodeCollection[element].Chldren;

            foreach (var child in childrenList)
            {
                child.Parent = parent;

            }
            parent.Chldren.Remove(this.nodeCollection[element]);
            parent.Chldren.AddRange(childrenList);

            this.nodeCollection.Remove(element);


        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this.nodeCollection.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            List<T> childreList = new List<T>();

            this.nodeCollection[item].Chldren.ForEach(ch => childreList.Add(ch.Value));

            return childreList;


        }

        public T GetParent(T item)
        {
            if (!this.nodeCollection.ContainsKey(item))
            {
                throw new ArgumentException();
            }
            if (this.nodeCollection[item].Parent == null)
            {
                return default(T);
            }

            Node parrent = this.nodeCollection[item].Parent;

            return parrent.Value;


        }

        public bool Contains(T value)
        {
            return this.nodeCollection.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            List<T> comonList = new List<T>();

            foreach (var key in this.nodeCollection.Keys)
            {
                if (other.nodeCollection.ContainsKey(key))
                {
                    comonList.Add(key);
                }
            }

            return comonList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<T> queue = new Queue<T>();
            queue.Enqueue(this.root.Value);

            while (queue.Count > 0)
            {
               var current =  queue.Dequeue();

                foreach (var child in this.nodeCollection[current].Chldren)
                {
                    queue.Enqueue(child.Value);
                }
                yield return current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node
        {
            public Node(T value, Node parent)
            {
                this.Value = value;
                this.Parent = parent;
                this.Chldren = new List<Node>();
            }

            public T Value { get; private set; }
            public Node Parent { get; set; }
            public List<Node> Chldren { get; set; }

        }
    }
//}