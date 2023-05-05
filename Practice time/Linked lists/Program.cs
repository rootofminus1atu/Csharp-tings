using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Linked_lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Pair last = new Pair(1, null);
            Pair next = new Pair(2, last);
            Pair nextNext = new Pair(3, next);
            Console.WriteLine(nextNext.pair.value);


            LiList test = new LiList(7, 8, 9);
            Console.WriteLine(test.List.pair.value);

            LinkedList<int> tester = new LinkedList<int>(4, 5, 6);
            Console.WriteLine(tester.Next.Value);

            int[] vals = tester.ExtractValues();
            Console.WriteLine($"[{string.Join(", ", vals)}]");
            Console.WriteLine(tester.ToString());


            LinkedList<int> testerEmpty = new LinkedList<int>();
            Console.WriteLine(testerEmpty.ToString());
            testerEmpty.Append(123);
            Console.WriteLine(testerEmpty.ToString());


            tester.Append(7);
            Console.WriteLine(tester.ToString());
        }
    }

    public class Pair
    {
        public int value { get; set; }
        public Pair? pair { get; set; }

        public Pair(int value, Pair? pair)
        {
            this.value = value;
            this.pair = pair;
        }
    }

    public class LiList
    {
        public Pair? List { get; set; }

        public LiList(params int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (i == 0)
                {
                    this.List = new Pair(values[i], null);
                }
                else
                {
                    this.List = new Pair(values[i], this.List);
                }

            }

        }
    }

    public class LinkedList<T>
    {
        public T? Value { get; set; }
        public LinkedList<T>? Next { get; set; }

        public LinkedList(params T[] values)
        {
            if (values.Length == 1)
            {
                this.Value = values[0];
                this.Next = null;
            }
            else
            {
                int lastIndex = values.Length - 1;

                T[] newValues = new T[lastIndex];

                for (int i = 0; i < lastIndex; i++)
                    newValues[i] = values[i];

                this.Value = values[lastIndex];
                this.Next = new LinkedList<T>(newValues);
            }
        }


        public T[] ExtractValues()
        {
            List<T> values = new List<T>();

            if (this != null)
            {
                if (this.Next != null)
                    values.AddRange(this.Next.ExtractValues());

                values.Add(this.Value);
            }

            return values.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.ExtractValues())}]";
        }

        public void Append(T value)
        {
            this.Next = new LinkedList<T>(this.ExtractValues());
            this.Value = value;
        }
    }
}