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

        double speed = 10;

        double numberOfDays = 0;

        int scaling = 8000000;

        int planetScaling = 5;

        String selectedPlanet = null;

        SpaceObject planetObject = null;

        List<SpaceObject> solarSystem = getSolarSystem();

        List<Moon> moons;

        double moonScaling = 1;

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
                 *  Text and fonts
                 */
                Font drawFont = new Font("Arial", 16);
                Font draw2Font = new Font("Arial", 12);
                SolidBrush textBrush = new SolidBrush(Color.White);
                StringFormat drawFormat = new StringFormat();
                Font planetFont = new Font("Arial", 8);

                /*
                 *  Sun
                 */
                Brush sunBrush = new SolidBrush(Color.OrangeRed);
                RectangleF sun = new RectangleF(600, 300, 20, 20);

                PointF img = new PointF(20, 20);

                fg.Clear(Color.Black);

                while (drawingSolarSystem)
                {

                    graphics.Clear(Color.Black);

                    /*
                     *  Number of days and days per second text
                     */

                    graphics.DrawString("Antall dager: " + (int)numberOfDays, drawFont, textBrush, 80, 0, drawFormat);
                    graphics.DrawString("Dager per sekund: " + (double)speed * 10, draw2Font, textBrush, 80, 30, drawFormat);

                    /*
                     *  Draw sun
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

                        Brush pBrush = new SolidBrush(obj.ObjectColor);
                        PointF objPoint = obj.calculatePositionPointF((float)numberOfDays);
                        objF.X = (objPoint.X / scaling) + sun.X - (objF.Height / 2) + 10;
                        objF.Y = (objPoint.Y / scaling) + sun.Y - (objF.Width / 2) + 10;

                        if (showNames == true)
                        {
                            graphics.DrawString(obj.Name, planetFont, textBrush, objF.X + objF.Width, objF.Y + objF.Height, drawFormat);
                        }
                        
                        graphics.FillEllipse(pBrush, objF);
                    }

                    fg.DrawImage(btm, img);

                    Thread.Sleep(10);
                    numberOfDays += speed;
                }

                while (drawingPlanetWithMoons)
                {

                    graphics.Clear(Color.Black);

                    /*
                     *  Number of days and days per second text
                     */

                    graphics.DrawString("Antall dager: " + (int)numberOfDays, drawFont, textBrush, 80, 0, drawFormat);
                    graphics.DrawString("Dager per sekund: " + String.Format("{0:0.00}", speed * 10), draw2Font, textBrush, 80, 30, drawFormat);


                    /*
                     *  Draw Planet
                     */

                    RectangleF planet = new RectangleF(600, 300, 20, 20);
                    Brush planetBrush = new SolidBrush(planetObject.ObjectColor);
                    graphics.FillEllipse(planetBrush, planet);

                    if (showNames)
                    {
                        graphics.DrawString(planetObject.Name, planetFont, textBrush, planet.X + 20, planet.Y + 20, drawFormat);

                    }

                    /*
                     *  Planet information
                     */
                    int informationX = 0;
                    int informationY = 500;
                    graphics.DrawString("Planet: " + planetObject.Name, draw2Font, textBrush, informationX, informationY, drawFormat);
                    graphics.DrawString("Planet radius: " + planetObject.ObjectRadius + " km", draw2Font, textBrush, informationX, informationY + 20, drawFormat);
                    graphics.DrawString("Distanse fra sola: " + planetObject.OrbitalRadius + " km", draw2Font, textBrush, informationX, informationY + 40, drawFormat);

                    /*
                     *  Draw moons
                     */

                    foreach (Moon moon in moons)
                    {
                        
                        int scalingToPlanet = 2;
                        RectangleF objF = new RectangleF(0, 0, (float)(planet.Width / (planetObject.ObjectRadius / moon.ObjectRadius) + scalingToPlanet)
                            , (float)(planet.Height / (planetObject.ObjectRadius / moon.ObjectRadius) + scalingToPlanet));

                        Brush moonBrush = new SolidBrush(moon.ObjectColor);
                        PointF objPoint = moon.calculatePositionPointF((float)numberOfDays);

                        if (moonScaling < 17)
                        {
                            objF.X = (objPoint.X * 5) + planet.X - (objF.Height / 2) + 10;
                            objF.Y = (objPoint.Y * 5) + planet.Y - (objF.Width / 2) + 10;
                        } else
                        {
                            objF.X = (objPoint.X / planetScaling) + planet.X - (objF.Height / 2) + 10;
                            objF.Y = (objPoint.Y / planetScaling) + planet.Y - (objF.Width / 2) + 10;
                        }

                        if (showNames == true)
                        {
                            graphics.DrawString(moon.Name, planetFont, textBrush, objF.X + objF.Width, objF.Y + objF.Height, drawFormat);
                        }
                        graphics.FillEllipse(moonBrush, objF);

                    }

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
            if (showNames)
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
                moonScaling = 0;
                speed = 0.05f;

                foreach (SpaceObject obj in solarSystem)
                {
                    if (obj.Name == selectedPlanet)
                    {
                        planetObject = obj;
                    }
                }

                moons = (List<Moon>)GetMoons(selectedPlanet);

                foreach (Moon moon in moons)
                {
                    moonScaling += moon.OrbitalRadius;
                    
                }

                moonScaling /= moons.Count;
            }
            else
            {
                selectedPlanet = null;
                drawingSolarSystem = true;
                drawingPlanetWithMoons = false;
                speed = 10;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedPlanet == null)
            {
                speed += 2;
            }
            else
            {
                speed += 0.005;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedPlanet == null && speed >= 2)
            {
                speed -= 2;
            }
            else
            {
                if (speed > 0.005)
                {
                    speed -= 0.005;
                }
                
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
            if (selectedPlanet == null)
            {
                scaling -= 500000;
            }
            else
            {
                if (planetScaling > 1)
                {
                    planetScaling -= 1;
                }
               
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedPlanet == null)
            {
                scaling += 500000;
            } 
            else
            {

                planetScaling += 1;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
