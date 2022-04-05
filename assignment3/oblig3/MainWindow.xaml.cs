using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

namespace oblig3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            dat154Entities dx = new dat154Entities();

            DbSet<student> students = dx.student;

            DbSet<course> courses = dx.course;

            DbSet<grade> grades = dx.grade;

            foreach (student s in students)
            {
                //tbSettingText.Text += "Name: " + s.studentname + ", Age: " + s.studentage + "\n";
            }

            foreach (course s in courses)
            {
                tbSettingText.Text += s.coursename + " " + s.teacher + "\n";
            }

            


        }
    }
}
