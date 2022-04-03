﻿using System;
using System.Collections.Generic;

namespace Dex {
    // Delegate definition
    public delegate void Alarm(Stock s);

    public class Stock {
        // Event that is fired when 100pt limit is reached
        public event Alarm Notify;

        private Random rnd = new Random();

        public int Rate { get; set; }
        public String Name { get; set; }

        public Stock(String n, int r) {
            Name = n; Rate = r;
        }

        //  Caclulate new rate for this stock object
        //  Fire event if 100 pt limit is passed
        public void CalcNewRate() {
            int change = rnd.Next(-35, 45);
            Rate += change;
            if ((Rate - change) / 100 != Rate / 100)
            {
                Notify(this);   // Fire the event
            }
        }
    };

    public class Person {
        public String Name { get; set; }
        public int Price { get; set; } = 10;
        public int Amount { get; set; } = 0;

        public Person(String n) { Name = n; }

        // Event Handler
        public virtual void Alert(Stock s) {
            Console.WriteLine(
                " Day  : " + Dex.Day +
                " Name : " + Name +
                " Stock  : " + s.Name +
                " Rate : " + s.Rate);
            Amount += Price;
        }
        public void Invoice() {
            Console.WriteLine(" Cust: " + Name + " Inv kr :" + Amount);
        }
    };

    public class Broker : Person {
        // A broker must pay 5 times the price as a normal 
        // person
        public Broker(String n) : base(n) { Price = 50; }
    };

    public class Dex {
        public static int Day { get; set; } = 1;
        static void Main(string[] args) {
            List<Stock> stocks = new List<Stock>();
            List<Person> traders = new List<Person>();

            Stock h, d, t;

            // CREATE STOCKS
            stocks.Add(h = new Stock("HYDRO", 210));
            stocks.Add(d = new Stock("DNB", 310));
            stocks.Add(t = new Stock("TELENOR", 410));

            // Create Broker and Persons
            Person k, s, r;
            traders.Add(k = new Broker("KÅRE"));
            traders.Add(s = new Broker("SVEIN"));
            traders.Add(r = new Person("RICH"));

            // Subscribing to the event
            h.Notify += k.Alert;
            d.Notify += k.Alert;
            t.Notify += s.Alert;
            h.Notify += r.Alert;


            // Run simulation for one month
            Console.WriteLine("Hit a key to advance a day. Not all days will print anything");

            for (; Day < 31; Day++)
            {
                Console.ReadKey();
                foreach (Stock a in stocks)
                {
                    a.CalcNewRate();
                }
                

            }
            // Invoice the customers
            foreach (Person p in traders) {
                p.Invoice();
            }

            Console.Read();
        }
    }
}

