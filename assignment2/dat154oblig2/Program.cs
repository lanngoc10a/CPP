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

            List<SpaceObject> solarSystem = new List<SpaceObject>
            {
            new Star("Sun", 0.0, 0.0, 696340.0, 24.47, "Orange"),
            new Planet("Mercury", 57909227, 88, 2439, 59, "Dark Gray"),
            };

            

            Console.ReadLine();
        }
    }
}
