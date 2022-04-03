using System;
using System.Collections.Generic;
using LibFSH;
using LibVB;

using static System.Console;


class Program
{
    // Vehicle from VB.NET
    class Car : Vehicle
    {
        public ConsoleColor col;
        public Car(string b, string m, int yr, int hk) : base(b, m, yr, hk)
        {
        }
        public int Price {get;set;}
    }
    static void Main(string[] args)
    {
        Car v = new ("Volvo", "PV 544", 1965, 75); 
        v.col = ConsoleColor.Yellow;
        v.Price = 10000;

        Car j = new ("Jaguar", "E-Type", 1965, 275);
        j.col = ConsoleColor.Red;
        j.Price = 100000;

        Car t = new("Tesla", "Model X", 2020, 400);
        t.col = ConsoleColor.Blue;
        t.Price = 50000;

        List<Car> lst = new (); // C# 9.0 -> NET.CORE 5.0
        lst.Add(v);
        lst.Add(j);
        lst.Add(t);

        // GetCurrencyFromCar is F# function
        // Same with hello function !!
        Currency.hello("This is my cars");
        foreach (var c in lst)
        {
            Console.ForegroundColor = c.col;
            WriteLine(c.Info());       
            WriteLine("    Price (NOK)" +
                c.Price * Currency.GetCurrencyFromCar(c.brand));
        }
        ResetColor();
    }
}

