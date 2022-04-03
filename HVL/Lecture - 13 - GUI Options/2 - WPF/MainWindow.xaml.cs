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

namespace _2___WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string txt = txtField.Text;

            if (txt.Length > 0)
            {
                byte r = (byte)((txt.Length * 5) % 255);
                byte g = (byte)(txt.Substring(0, 1).ToCharArray()[0] * 5 % 255);
                byte b = (byte)((r + g) % 255);

                Background = new SolidColorBrush(Color.FromRgb(r, g, b));

            }
        }
    }
}
