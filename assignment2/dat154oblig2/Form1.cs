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
        }

        Thread thread;
        Thread thread2;
        Graphics graphics;
        Graphics fg;
        Bitmap btm;

        bool drawing = true;

        bool drawingPlanetWithMoons = false;

        bool showNames = true;

        int speed = 10;

        int numberOfDays = 0;

        String selectedPlanet = null;


        /*
        private void Form1_Load(object sender, EventArgs e)
        {
            ;
            btm = new Bitmap(1920, 1080);
            graphics = Graphics.FromImage(btm);
            foreGround = CreateGraphics();
            thread = new Thread(Draw);
            thread.IsBackground = true;
            thread.Start();
        }
        */


        public void Draw()
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

            List<SpaceObject> solarSystem = getSolarSystem();

            
            PointF img = new PointF(20, 20);

            fg.Clear(Color.Black);

            while (drawing)
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

                    pBrush = new SolidBrush(Color.White);
                    PointF objPoint = obj.calculatePositionPointF(numberOfDays);
                    objF.X = (objPoint.X / 8000000) + sun.X - (objF.Height / 2) + 10;
                    objF.Y = (objPoint.Y / 8000000) + sun.Y - (objF.Width / 2) + 10;

                    if (showNames == true)
                    {
                        graphics.DrawString(obj.Name, planetFont, planettextBrush, objF.X + objF.Width, objF.Y + objF.Height, planetFormat);
                    }
                    graphics.FillEllipse(planetBrush, objF);
                }

                fg.DrawImage(btm, img);
                
                Thread.Sleep(10);
                numberOfDays += speed;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btm = new Bitmap(1920, 1080);
            graphics = Graphics.FromImage(btm);
            fg = CreateGraphics();

            thread = new Thread(Draw);
            thread.IsBackground = true;
            thread.Start();
        }

        private List<SpaceObject> getSolarSystem()
        {
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
            };

            return solarSystem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (showNames == true)
            {
                showNames = false;
            } else
            {
                showNames = true;
            }
            
        }

        public void drawPlanetWithMoons()
        {
            drawing = false;

            drawingPlanetWithMoons = true;
          
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
                RectangleF planet = new RectangleF(600, 300, 20, 20);

                List<SpaceObject> solarSystem = getSolarSystem();

                

                PointF img = new PointF(20, 20);

                fg.Clear(Color.Black);

                while (drawingPlanetWithMoons)
                {

                    graphics.Clear(Color.Black);

                    /*
                     *  Number of days text
                     */

                    graphics.DrawString("Antall dager: " + numberOfDays, drawFont, drawBrush, 100, y + 20, drawFormat);

                    /*
                        Draw planet 
                    */

                    graphics.FillEllipse(sunBrush, planet);


                    foreach (Planet obj in solarSystem)
                    {
                       
                        if (obj.Name == selectedPlanet)
                        {

                        List<Moon> moons = obj.getMoons();
                 

                        foreach (Moon moon in moons)
                        {
                            int sunDownScaling = 20;
                            RectangleF objF = new RectangleF(0, 0, ((float)(planet.Width) * sunDownScaling)
                                , ((float)(planet.Height)) * sunDownScaling);

                            pBrush = new SolidBrush(Color.White);
                            PointF objPoint = obj.calculatePositionPointF(numberOfDays);
                            objF.X = (objPoint.X / 8000000) + planet.X - (objF.Height / 2) + 10;
                            objF.Y = (objPoint.Y / 8000000) + planet.Y - (objF.Width / 2) + 10;

                            if (showNames == true)
                            {
                                // graphics.DrawString(obj.Name, planetFont, planettextBrush, objF.X + objF.Width, objF.Y + objF.Height, planetFormat);
                            }
                            graphics.FillEllipse(planetBrush, objF);
                        }

                        fg.DrawImage(btm, img);

                        Thread.Sleep(10);
                        numberOfDays += speed;
                    }


                        
                }
                      
                    
                }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPlanet = (string)comboBox1.SelectedItem;
            
            if (selectedPlanet != null)
            {

                btm = new Bitmap(1920, 1080);
                graphics = Graphics.FromImage(btm);
                fg = CreateGraphics();
                
                thread2 = new Thread(drawPlanetWithMoons);
                thread2.IsBackground = true;
                thread2.Start();
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
    }                                                                                                               
}
