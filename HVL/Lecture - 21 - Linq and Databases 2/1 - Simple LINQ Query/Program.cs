using System;
using System.Collections.Generic;
using System.Linq;

namespace _1___Simple_LINQ_Query {
    class Program {
        static void Main(string[] args) {
            List<String> l = new List<string>();
            l.Add("Bob");
            l.Add("Alice");
            l.Add("Oscar");
            l.Add("Mike");

            foreach (string x in l.OrderBy(x => x)) {
                Console.WriteLine(x);

            }

            Console.ReadKey();
        }
    }
}
