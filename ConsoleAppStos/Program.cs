using System;
using StosLibrary;

namespace ConsoleAppStos
{
    class Program
    {
        static void Main(string[] args)
        {
            StosWTablicy<string> s = new StosWTablicy<string>(2);
            s.Push("km");
            s.Push("aa");
            s.Push("xx");
            foreach (var x in s.ToArray())
                Console.WriteLine(x);

            Console.WriteLine();

            StosWLiscie<string> s2 = new StosWLiscie<string>();
            s2.Push("km");
            s2.Push("aa");
            s2.Push("xx");
            foreach (var x in s2.ToArray())
                Console.WriteLine(x);

            Console.WriteLine();
        }
    }
}
