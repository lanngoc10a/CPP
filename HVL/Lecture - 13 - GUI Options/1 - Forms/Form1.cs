using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1___Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;

            if (txt.Length > 0) {
                int r = (txt.Length*5) % 255;
                int g = ((int)txt.Substring(0, 1).ToCharArray()[0] * 5) % 255;
                int b = (r + g) % 255;

                this.BackColor = Color.FromArgb(r, g, b);

            }
        }
    }
}
