using System;
using System.Collections;
using System.Collections.Generic;

namespace StosLibrary
{
    public class StosWTablicy<T> : IStos<T>, IEnumerable<T>
    {
        private T[] tab;
        private int szczyt = -1;

        public StosWTablicy(int size = 10)
        {
            tab = new T[size];
            szczyt = -1;
        }

        public T this[int index] => tab[index];

        public T Peek => IsEmpty ? throw new StosEmptyException() : tab[szczyt];

        public int Count => szczyt + 1;

        public int Lenght => tab.Length;

        public bool IsEmpty => szczyt == -1;

        public void Clear() => szczyt = -1;

        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            szczyt--;
            return tab[szczyt + 1];
        }

        public void Push(T value)
        {
            if (szczyt == tab.Length - 1)
            {
                Array.Resize(ref tab, tab.Length * 2);
            }

            szczyt++;
            tab[szczyt] = value;
        }

        public T[] ToArray()
        {
            //return tab;  //bardzo źle - reguły hermetyzacji

            //poprawnie:
            T[] temp = new T[szczyt + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = tab[i];
            return temp;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<T> ToArrayReadOnly()
        {
            return Array.AsReadOnly(tab);
        }

        public void TrimExcess()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            Array.Resize(ref tab, Count + (int)Math.Floor(Count * 0.1));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator() => new StosEnumenator(this);
        //{
        //    for (int i = 0; i < Count; i++)
        //    {
        //        yield return tab[i];
        //    }
        //}

        private class StosEnumenator : IEnumerator<T>
        {
            private StosWTablicy<T> stos;
            private int p = -1;
            public T Current => stos[p];

            object IEnumerator.Current => Current;

            public StosEnumenator(StosWTablicy<T> s)
            {
                stos = s;
            }

            public void Dispose()
            { 
            
            }

            public bool MoveNext()
            {
                if (p < stos.Count - 1)
                {
                    p++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset() => p = -1;
        }

        public IEnumerable<T> TopToBottom
        {
            get
            {
                for (int i = Count - 1; i >= 0; i--)
                    yield return this[i];
            }
        }
    }
}