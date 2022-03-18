using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceSim;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            List<Moon> mercuryMoons = new List<Moon>
            {
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> venusMoons = new List<Moon>
            {
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> earthMoons = new List<Moon>
            {
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> marsMoons = new List<Moon>
            {
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> jupiterMoons = new List<Moon>
            {
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> saturnMoons = new List<Moon>
            {
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> uranusMoons = new List<Moon>
            {
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> neptuneMoons = new List<Moon>
            {
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<SpaceObject> solarSystem = new List<SpaceObject>
            {
                new Star("Sun", 0.0, 0.0, 696340.0, 24.47, "Orange"),
                new Planet("Mercury", 57909227, 88, 2439, 59, "Dark Gray", mercuryMoons),
                new Planet("Venus", 108200000, 225, 6052, 243, "Yellow", venusMoons),
                new Planet("Earth", 147100000, 365, 6371, 1, "Blue", earthMoons),
                new Planet("Mars", 227900000, 687, 3390, 1, "Red", marsMoons),
                new Planet("Jupiter", 778000000, 4333, 69911, 0.4, "White", jupiterMoons),
                new Planet("Saturn", 1433449370, 10759, 58232, 0.4, "Pale Yellow", saturnMoons),
                new Planet("Uranus", 2870972200, 30769, 25362, 0.7, "Blue-Green", uranusMoons),
                new Planet("Neptune", 4500000000, 60225, 24622, 0.7, "Blue", neptuneMoons),
                new DwarfPlanet("Ceres", 413000000, 1682, 473, 0.4, "Gray"),
                new DwarfPlanet("Pluto", 5906380000, 90520, 1188, 6, "White"),
                new DwarfPlanet("Haumea", 6452000000, 104025, 816, 0.25, "Red-White"),
                new DwarfPlanet("Makemake", 6839000000, 111325, 715, 1, "Red"),
                new DwarfPlanet("Eris", 10125000000, 203305, 1163, 1.1, "Gray")
            };

            Console.ReadLine();
        }
    }
}
