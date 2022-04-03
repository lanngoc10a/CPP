using System;

namespace ReturnValues {

    delegate int delegateTest(int a, int b);

    class A {
        public delegateTest t;

        public A() {
            t += sum;
            int retval = t(3, 5);
            Console.WriteLine("Delegate: {0}", retval);
            Console.WriteLine("\n-----------------------\n");

            t += diff;
            retval = t(3, 5);
            Console.WriteLine("Delegate: {0}", retval);
            Console.WriteLine("\n-----------------------\n");


        }
        public int sum(int a, int b) {
            Console.WriteLine("Sum: {0}", a + b);
            return a + b;
        }

        public int diff(int a, int b) {
            Console.WriteLine("Diff: {0}", a - b);
            return a - b;
        }
    }


    class Program {
        static void Main(string[] args) {
            new A();
        }
    }
}
