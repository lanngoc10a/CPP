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
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            
            

            SpaceObject sun = new Star("Sun", 0.0, 0.0, 696340.0, 24.47, "Red");

                
            //formGraphics.FillEllipse(myBrush, new Rectangle(Convert.ToInt32(sun.X) + 600, Convert.ToInt32(sun.Y) + 250, 50, 50));

            formGraphics.FillEllipse(myBrush, new Rectangle(Convert.ToInt32(sun.X) + 600
                , Convert.ToInt32(sun.Y) + i, 50, 50));
            Thread.Sleep(50);
            formGraphics.ReleaseHdc();
            formGraphics.Dispose();
            myBrush.Dispose();

            




           




        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpaceObject moon = new Moon("Moon", 20.4, 0.4, 600000.0, 25.47, "DarkGray");
            
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGray);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(myBrush, new Rectangle(155, 115, 50, 50));
            myBrush.Dispose();
            formGraphics.Dispose();
        }
    }                                                                                                               
}
