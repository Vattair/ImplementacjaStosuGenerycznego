using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StosLibrary
{
    public class StosWLiscie<T> : IStos<T>
    {
        private List<Node<T>> stos;

        public StosWLiscie()
        {
            stos = new List<Node<T>>();
        }

        public T this[int index] => stos.ElementAt(index).data;

        public T Peek => IsEmpty ? throw new StosEmptyException() : stos.Last().data;

        public int Count => stos.Count;

        public int Lenght => throw new NotImplementedException();

        public bool IsEmpty => !stos.Any();

        public void Clear() => stos.Clear();

        public T Pop()
        {
            if (IsEmpty) throw new StosEmptyException();
            T data = stos.Last().data;
            if (Count == 1)
            {
                stos.RemoveAt(Count);
            }
            else
            {
                stos[Count - 1].next = null;
                stos.Remove(stos.Last());
            }

            return data;
        }

        public void Push(T value)
        {
            Node<T> node;
            if(Count == 0)
            {
                node = new Node<T>(value);
                stos.Add(node);
            }
            else
            {
                node = new Node<T>(value, null, stos[Count - 1]);
                stos[Count - 1].next = node;
                stos.Add(node);
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                array[i] = stos[i].data;
            }
            return array;
        }

        public void TrimExcess() => throw new NotImplementedException();


        class Node<T>
        {
            public T data;
            public Node<T> next;
            public Node<T> prev;

            public Node(T data, Node<T> next = null, Node<T> prev = null)
            {
                this.data = data;
                this.next = next;
                this.prev = prev;
            }
        }
    }
}
