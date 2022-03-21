using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceSim;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Load += new EventHandler(Form1_Load);
        }

        Thread thread;
        Graphics graphics;
        Graphics fg;
        Bitmap btm;

        bool drawing = true;
        bool drawingSolarSystem = true;
        bool drawingPlanetWithMoons = false;

        bool showNames = true;

        int speed = 10;

        int numberOfDays = 0;

        int scaling = 8000000;

        String selectedPlanet = null;

        SpaceObject planetObject = null;

        List<SpaceObject> solarSystem = getSolarSystem();


        private void Form1_Load(object sender, EventArgs e)
        {

            btm = new Bitmap(1920, 1080);
            graphics = Graphics.FromImage(btm);
            fg = CreateGraphics();
            thread = new Thread(Draw);
            thread.IsBackground = true;
            thread.Start();

        }


        public void Draw()
        {

            while (drawing)
            {
                /*
                 *  SpaceObject
                */

                Brush planetBrush = new SolidBrush(Color.White);
                Brush pBrush;

                // Text
                Font drawFont = new Font("Arial", 16);

                SolidBrush drawBrush = new SolidBrush(Color.White);
                float x = 150.0F;
                float y = 50.0F;
                StringFormat drawFormat = new StringFormat();

                Font planetFont = new Font("Arial", 8);
                SolidBrush planettextBrush = new SolidBrush(Color.White);

                StringFormat planetFormat = new StringFormat();

                /*
                 *  Sun
                 */
                Brush sunBrush = new SolidBrush(Color.Red);
                RectangleF sun = new RectangleF(600, 300, 20, 20);

                PointF img = new PointF(20, 20);

                fg.Clear(Color.Black);

                while (drawingSolarSystem)
                {

                    graphics.Clear(Color.Black);

                    /*
                     *  Number of days text
                     */

                    graphics.DrawString("Antall dager: " + numberOfDays, drawFont, drawBrush, 100, y + 20, drawFormat);

                    /*
                        Draw sun 
                    */

                    graphics.FillEllipse(sunBrush, sun);


                    foreach (SpaceObject obj in solarSystem)
                    {

                        /*
                         * RectangleF objF creates the planet at position 0,0 ( position is updated later)
                         * Width and height is scaled according to the sun
                         * 
                         * int sunDownScaling is used to lower the scale of the sun for visibility purposes
                         * At 20 the sun is scaled down 20 times
                         */

                        int sunDownScaling = 20;
                        RectangleF objF = new RectangleF(0, 0, ((float)(sun.Width / (double)obj.ScalingToSun) * sunDownScaling)
                            , ((float)(sun.Height / (double)obj.ScalingToSun)) * sunDownScaling);

                        pBrush = new SolidBrush(obj.ObjectColor);
                        PointF objPoint = obj.calculatePositionPointF(numberOfDays);
                        objF.X = (objPoint.X / scaling) + sun.X - (objF.Height / 2) + 10;
                        objF.Y = (objPoint.Y / scaling) + sun.Y - (objF.Width / 2) + 10;

                        if (showNames == true)
                        {
                            graphics.DrawString(obj.Name, planetFont, planettextBrush, objF.X + objF.Width, objF.Y + objF.Height, planetFormat);
                        }
                        graphics.FillEllipse(pBrush, objF);
                    }

                    fg.DrawImage(btm, img);

                    Thread.Sleep(10);
                    numberOfDays += speed;
                }

                while (drawingPlanetWithMoons)
                {

                    speed = 1;

                    graphics.Clear(Color.Black);

                    /*
                     *  Number of days text
                     */

                    graphics.DrawString("Antall dager: " + numberOfDays, drawFont, drawBrush, 100, y + 20, drawFormat);

                    RectangleF planet = new RectangleF(600, 300, 20, 20);

                    /*
                        Draw planet 
                    */

                    graphics.FillEllipse(sunBrush, planet);
                    graphics.DrawString(planetObject.Name, planetFont, planettextBrush, planet.X + 25, planet.Y + 25, planetFormat);

                    var moons = GetMoons(selectedPlanet);

                    foreach (Moon moon in moons)
                    {

                        RectangleF objF = new RectangleF(0, 0, ((float)(planet.Width / 5))
                            , ((float)(planet.Height / 5)));

                        pBrush = new SolidBrush(Color.White);
                        PointF objPoint = moon.calculatePositionPointF(numberOfDays);
                        objF.X = (objPoint.X) + planet.X - (objF.Height / 2) + 10;
                        objF.Y = (objPoint.Y) + planet.Y - (objF.Width / 2) + 10;

                        if (showNames == true)
                        {
                            graphics.DrawString(moon.Name, planetFont, planettextBrush, objF.X + objF.Width, objF.Y + objF.Height, planetFormat);
                        }
                        graphics.FillEllipse(planetBrush, objF);

                    }

                    graphics.DrawString("Planet: " + planetObject.Name, planetFont, planettextBrush, 100, 300, planetFormat);
                    graphics.DrawString("Planet radius: " + planetObject.ObjectRadius + " km", planetFont, planettextBrush, 100, 320, planetFormat);
                    graphics.DrawString("Distanse fra sola: " + planetObject.OrbitalRadius + " km", planetFont, planettextBrush, 100, 340, planetFormat);



                    fg.DrawImage(btm, img);

                    Thread.Sleep(10);
                    numberOfDays += speed;
                }
            }
        }

        private IEnumerable<Moon> GetMoons(string selectedPlanet)
        {
            switch (selectedPlanet.ToLower())
            {
                case "earth": return Moons.Earth;
                case "mars": return Moons.Mars;
                case "jupiter": return Moons.Jupiter;
                case "saturn": return Moons.Saturn;
                case "uranus": return Moons.Uranus;
                case "neptune": return Moons.Neptune;
                default: return new List<Moon>();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (showNames == true)
            {
                showNames = false;
            }
            else
            {
                showNames = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPlanet = (string)comboBox1.SelectedItem;

            if (selectedPlanet != "Sun")
            {

                drawingSolarSystem = false;
                drawingPlanetWithMoons = true;

                foreach (SpaceObject obj in solarSystem)
                {
                    if (obj.Name == selectedPlanet)
                    {
                        planetObject = obj;
                    }
                }
            }
            else
            {
                drawingSolarSystem = true;
                drawingPlanetWithMoons = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            speed += 5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (speed >= 5)
            {
                speed -= 5;
            }
        }

        private static List<SpaceObject> getSolarSystem()
        {

            List<SpaceObject> solarSystem = new List<SpaceObject>
            {
                new Star("Sun", 0.0, 0.0, 696340.0, 24.47, Color.Orange),
                new Planet("Mercury", 57909227, 88, 2439, 59, Color.DarkGray),
                new Planet("Venus", 108200000, 225, 6052, 243, Color.Yellow),
                new Planet("Earth", 147100000, 365, 6371, 1, Color.Blue, Moons.Earth),
                new Planet("Mars", 227900000, 687, 3390, 1, Color.Red, Moons.Mars),
                new Planet("Jupiter", 778000000, 4333, 69911, 0.4, Color.White, Moons.Jupiter),
                new Planet("Saturn", 1433449370, 10759, 58232, 0.4, Color.PaleGoldenrod, Moons.Saturn),
                new Planet("Uranus", 2870972200, 30769, 25362, 0.7, Color.Cyan, Moons.Uranus),
                new Planet("Neptune", 4500000000, 60225, 24622, 0.7, Color.Blue, Moons.Neptune),
            };

            return solarSystem;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            scaling -= 500000;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            scaling += 500000;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
