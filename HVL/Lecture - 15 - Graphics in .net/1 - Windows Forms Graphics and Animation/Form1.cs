using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1___Windows_Forms_Graphics_and_Animation {
    public partial class Form1 : Form {

        private bool directionDown = true;
        private bool directionRight = true;
        private int animwidth = 500;
        private int animheight = 300;
        private int canvaswidth;
        private int canvasheight;

        private readonly Image brushimg = Image.FromFile(@"C:\Windows\Web\Wallpaper\Theme1\img3.jpg");

        private readonly Timer t = new();
        public Form1() {
            InitializeComponent();

            
            t.Interval = 25;
            t.Tick += T_Tick;


        }

        private void T_Tick(object sender, EventArgs e) {
            if(directionDown) {
                if(animheight < canvasheight -15 ) {
                    animheight++;
                } else {
                    directionDown = !directionDown;
                }
            } else {
                if (animheight > 100) {
                    animheight--;
                } else {
                    directionDown = !directionDown;
                }
            }
            if (directionRight) {
                if (animwidth < canvaswidth - 15) {
                    animwidth++;
                } else {
                    directionRight = !directionRight;
                }
            } else {
                if (animwidth > 250) {
                    animwidth--;
                } else {
                    directionRight = !directionRight;
                }
            }
            Invalidate();



        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics g = e.Graphics;
            DoubleBuffered = true;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            canvasheight = (int)g.VisibleClipBounds.Height;
            canvaswidth = (int)g.VisibleClipBounds.Width;


            SolidBrush brush1 = new SolidBrush(Color.Red);
            TextureBrush brush2 = new TextureBrush(brushimg);
            HatchBrush brush3 = new HatchBrush(HatchStyle.Plaid, Color.Red, Color.Blue);

            g.FillEllipse(brush1, new Rectangle(10, 10, 90, animheight -20));
            g.FillEllipse(brush2, new Rectangle(110, 10, animwidth - 220, animheight - 20));
            g.FillEllipse(brush3, new Rectangle(animwidth -100, 10, 90, animheight -20));

            Color a = Color.FromArgb(155, 15, 255);
            Pen pen = new Pen(a);

            g.DrawRectangle(pen, new Rectangle(5, 5, animwidth, animheight));

            brush2.Dispose();   // automatic garbage collection is simply too slow to delete this during 
                                // a fast animation so we are forcing the issue.

        }

        private void button1_Click(object sender, EventArgs e) {
            t.Start();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
