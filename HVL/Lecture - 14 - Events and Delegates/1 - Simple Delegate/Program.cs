using System;

namespace SimpleDelegate {

    delegate void delegateTest();

    class A {
        public delegateTest t;

        public A() {
            Console.WriteLine("Adding Method B to delegate");
            t += b;
            t();
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Adding B again");
            t += b;
            t();
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Adding Method C to delegate");
            t += c;
            t();
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Adding B yet again");
            t += b;
            t();
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Removing Method B from delegate");
            t -= b;
            t();
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Removing Method B from delegate again");
            t -= b;
            t();
            Console.WriteLine("----------------------------------");

        }
        public void b() {
            System.Console.WriteLine("Hi! I am 'b'.");
        }

        public void c() {
            System.Console.WriteLine("Howdy, 'c' here.");
        }
    }



    class Program {
        static void Main(string[] args) {
            new A();
            Console.ReadKey();
        }
    }
}
