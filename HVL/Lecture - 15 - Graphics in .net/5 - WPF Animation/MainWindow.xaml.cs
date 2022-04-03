using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _5___WPF_Animation {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private System.Windows.Threading.DispatcherTimer t;
        private Planet p;
        private Planet p2;
        int time = 0;
        public event Action<int> MoveIt;

        public MainWindow() {
            InitializeComponent();

            t = new System.Windows.Threading.DispatcherTimer
            {
                Interval = new TimeSpan(200000)
            };
            t.Tick += T_Tick;
            t.Start();

            p = new Planet
            {
                Shape = planet
            };
            MoveIt += p.CalcPos;

            p2 = new Planet
            {
                Shape = planet2,
                OrbitalRadius = 100,
                OrbitalSpeed = 2
            };
            MoveIt += p2.CalcPos;

        }

        private void T_Tick(object sender, EventArgs e) {
            MoveIt(time++);
        }
    }


    class Planet {

        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public int OrbitalRadius { get; set; } = 200;
        public int OrbitalSpeed { get; set; } = 1;

        public Ellipse Shape { get; set; }

        public void CalcPos(int time) {
            Canvas c = (Canvas)Shape.Parent;

            Xpos = (int)(c.RenderSize.Width / 2 - Shape.Width / 2 +
                (Math.Cos(time * OrbitalSpeed * 3.1416 / 180) * OrbitalRadius));
            Ypos = (int)(c.RenderSize.Height / 2 - Shape.Height / 2 +
                (Math.Sin(time * OrbitalSpeed * 3.1416 / 180) * OrbitalRadius));

            Canvas.SetLeft(Shape, Xpos);
            Canvas.SetTop(Shape, Ypos);

        }
    }


}
