using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void Center(Form form)
        {
            form.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (form.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (form.Size.Height / 2));
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            SpaceObject sun = new Star("Sun", 0.0, 0.0, 696340.0, 24.47, "Red");
            
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(myBrush, new Rectangle(0, 0, 100, 100));
            myBrush.Dispose();
            formGraphics.Dispose();
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
