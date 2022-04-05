using System;
using System.Collections.Generic;
using System.Linq;

namespace _2___Simple_Collection {
    class Program {
        static void Main(string[] args) {
            
            SimpleCollection<string> s = new();

            s.Add("John");
            s.Add("Mary");
            s.Add("Alice");
            s.Add("Tom");


            foreach (string st in s.OrderBy(x => x)) {
                Console.WriteLine(st);
            }

            Console.ReadKey();

        }
    }



    class SimpleCollection<T> : IEnumerable<T> {

        private List<T> data = new List<T>();

        public void Add(T item) {
            data.Add(item);
        }

        public void Get(int index) {
            data.ElementAt(index);
        }


        public IEnumerator<T> GetEnumerator() {
            foreach (T item in data)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }
    }
}

