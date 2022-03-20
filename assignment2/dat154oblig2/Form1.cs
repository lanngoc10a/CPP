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
        Thread thread2;
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

        List<SpaceObject> solarSystem;

        List<Moon> moons = null;


        List<Moon> mercuryMoons = new List<Moon>
            {
                  new Moon("Moon1", 50, 22.1, 45.2, 30.1, Color.White),
                  new Moon("Moon2", 100, 25.1, 48.2, 60.1, Color.White),
                  
            };


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

                solarSystem = getSolarSystem();

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


                    foreach (Moon moon in mercuryMoons)
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
                        moons = planetObject.Moons;
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

        private List<SpaceObject> getSolarSystem()
        {
            List<Moon> mercuryMoons = new List<Moon> {};
            };
            List<Moon> venusMoons = new List<Moon> {};
            };

            List<Moon> earthMoons = new List<Moon>
            {
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, Color.White),
            };

            List<Moon> marsMoons = new List<Moon>
                  new Moon("Phobos", 9, 0.32, 41.2, 24.1, "Dark Gray"),
                  new Moon("Deimos", 23, 46023, 41.2, 24.1, "Dark Gray"),

                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> jupiterMoons = new List<Moon>
                new Moon("Metis", 128, 0.29, 41.2, 24.1, "Dark Gray"),
                new Moon("Adrastea", 129, 0.3, 41.2, 24.1, "Dark Gray"),
                new Moon("Amalthea", 181, 0.35, 41.2, 24.1, "Dark Gray"),
                new Moon("Thebe", 222, 0.67, 41.2, 24.1, "Dark Gray"),
                new Moon("Io", 422, 28126, 41.2, 24.1, "Dark Gray"),
                new Moon("Europa", 671, 20149, 41.2, 24.1, "Dark Gray"),
                new Moon("Ganymede", 1070, 42186, 41.2, 24.1, "Dark Gray"),
                new Moon("Callisto", 1883, 16.69, 41.2, 24.1, "Dark Gray"),
                new Moon("Leda", 11094, 238.72, 41.2, 24.1, "Dark Gray"),
                new Moon("Himalia", 11480, 250.57, 41.2, 24.1, "Dark Gray"),
                new Moon("Lysithea", 11720, 259.22, 41.2, 24.1, "Dark Gray"),
                new Moon("Elara", 11737, 259.65, 41.2, 24.1, "Dark Gray"),
                new Moon("Ananke", 21200, 631, 41.2, 24.1, "Dark Gray"),  //minus rotasjon
                new Moon("Carme", 22600, 692, 41.2, 24.1, "Dark Gray"),  //minus rotasjon
                new Moon("Pasiphae", 23500, 735, 41.2, 24.1, "Dark Gray"),  //minus rotasjon
                new Moon("Sinope", 23700, 758, 41.2, 24.1, "Dark Gray"),  //minus rotasjon


                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            {
                  new Moon("Pan", 134, 0.58, 41.2, 24.1, "Dark Gray"),
                  new Moon("Atlas", 138, 0.6, 41.2, 24.1, "Dark Gray"),
                  new Moon("Prometheus", 139, 0.61, 41.2, 24.1, "Dark Gray"),
                  new Moon("Pandora", 142, 0.63, 41.2, 24.1, "Dark Gray"),
                  new Moon("Epimetheus", 151, 0.69, 41.2, 24.1, "Dark Gray"),
                  new Moon("Janus", 151, 0.69, 41.2, 24.1, "Dark Gray"),
                  new Moon("Mimas", 186, 0.94, 41.2, 24.1, "Dark Gray"),
                  new Moon("Enceladus", 238, 13516, 41.2, 24.1, "Dark Gray"),
                  new Moon("Tethys", 295, 32509, 41.2, 24.1, "Dark Gray"),
                  new Moon("Telesto", 295, 32509, 41.2, 24.1, "Dark Gray"),
                  new Moon("Calypso", 295, 32509, 41.2, 24.1, "Dark Gray"),
                  new Moon("Dione", 377, 27061, 41.2, 24.1, "Dark Gray"),
                  new Moon("Helene", 377, 27061, 41.2, 24.1, "Dark Gray"),
                  new Moon("Rhea", 527, 19085, 41.2, 24.1, "Dark Gray"),
                  new Moon("Titan", 1222, 15.95, 41.2, 24.1, "Dark Gray"),
                  new Moon("Hyperion", 1481, 21.28, 41.2, 24.1, "Dark Gray"),
                  new Moon("Iapetus", 3561, 79.33, 41.2, 24.1, "Dark Gray"),
                  new Moon("Phoebe", 12952, 550.48, 41.2, 24.1, "Dark Gray"),   //minus rotasjon

                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> uranusMoons = new List<Moon>
                  new Moon("Cordelia", 50, 0.34, 41.2, 24.1, "Dark Gray"),
                  new Moon("Ophelia", 54, 0.38, 41.2, 24.1, "Dark Gray"),
                  new Moon("Bianca", 59, 0.43, 41.2, 24.1, "Dark Gray"),
                  new Moon("Cressida", 62, 0.46, 41.2, 24.1, "Dark Gray"),
                  new Moon("Desdemona", 63, 0.47, 41.2, 24.1, "Dark Gray"),
                  new Moon("Juliet", 64, 0.49, 41.2, 24.1, "Dark Gray"),
                  new Moon("Portia", 66, 0.51, 41.2, 24.1, "Dark Gray"),
                  new Moon("Rosalind", 70, 0.56, 41.2, 24.1, "Dark Gray"),
                  new Moon("Belinda", 75, 0.62, 41.2, 24.1, "Dark Gray"),
                  new Moon("Puck", 86, 0.76, 41.2, 24.1, "Dark Gray"),
                  new Moon("Miranda", 130, 14977, 41.2, 24.1, "Dark Gray"),
                  new Moon("Ariel", 191, 19025, 41.2, 24.1, "Dark Gray"),
                  new Moon("Umbriel", 266, 41730, 41.2, 24.1, "Dark Gray"),
                  new Moon("Titania", 436, 26146, 41.2, 24.1, "Dark Gray"),
                  new Moon("Oberon", 583, 13.46, 41.2, 24.1, "Dark Gray"),
                  new Moon("Caliban", 7169, 580, 41.2, 24.1, "Dark Gray"),  //minus rotasjon
                  new Moon("Stephano", 7948, 674, 41.2, 24.1, "Dark Gray"),  //minus rotasjon
                  new Moon("Sycorax", 12213, 1289, 41.2, 24.1, "Dark Gray"),  //minus rotasjon
                  new Moon("Porspero", 16568, 2019, 41.2, 24.1, "Dark Gray"),  //minus rotasjon
                  new Moon("Setebos", 17681, 2239, 41.2, 24.1, "Dark Gray"),  //minus rotasjon

                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<Moon> neptuneMoons = new List<Moon>
                  new Moon("Naiad", 48, 0.29, 41.2, 24.1, "Dark Gray"),
                  new Moon("Thalassa", 50, 0.31, 41.2, 24.1, "Dark Gray"),
                  new Moon("Despina", 53, 0.33, 41.2, 24.1, "Dark Gray"),
                  new Moon("Galatea", 62, 0.43, 41.2, 24.1, "Dark Gray"),
                  new Moon("Larissa", 74, 0.55, 41.2, 24.1, "Dark Gray"),
                  new Moon("Proteus", 118, 44166, 41.2, 24.1, "Dark Gray"),
                  new Moon("Trition", 355, 5.88, 41.2, 24.1, "Dark Gray"),  //minus rotasjon
                  new Moon("Nereid", 5513, 360, 41.2, 24.1, "Dark Gray"),
                  new Moon("Moon", 0.1, 20.1, 41.2, 24.1, "Dark Gray"),
            };

            List<SpaceObject> solarSystem = new List<SpaceObject>
            {
                new Star("Sun", 0.0, 0.0, 696340.0, 24.47, Color.Orange),
                new Planet("Mercury", 57909227, 88, 2439, 59, Color.DarkGray, mercuryMoons),
                new Planet("Venus", 108200000, 225, 6052, 243, Color.Yellow, venusMoons),
                new Planet("Earth", 147100000, 365, 6371, 1, Color.Blue, earthMoons),
                new Planet("Mars", 227900000, 687, 3390, 1, Color.Red, marsMoons),
                new Planet("Jupiter", 778000000, 4333, 69911, 0.4, Color.White, jupiterMoons),
                new Planet("Saturn", 1433449370, 10759, 58232, 0.4, Color.PaleGoldenrod, saturnMoons),
                new Planet("Uranus", 2870972200, 30769, 25362, 0.7, Color.Cyan, uranusMoons),
                new Planet("Neptune", 4500000000, 60225, 24622, 0.7, Color.Blue, neptuneMoons),
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
