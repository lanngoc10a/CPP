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

        dat154Entities dx;
        List<student> students;
        List<course> courses;
        List<grade> grades;

        public MainWindow()
        {

            dx = new dat154Entities();

            dx.Configuration.ProxyCreationEnabled = false;

            students = dx.student.ToList();

            courses = dx.course.ToList();

            grades = dx.grade.ToList();

            InitializeComponent();

            foreach (course c in courses)
            {
                cmbCourses.Items.Add(c.coursename);
                
            }
        }

        private void showGrades(List<String> stringGrade)
        {

            foreach (grade g in grades)
            {
                if (stringGrade.Contains(g.grade1))
                {
                    outputBox.Text += $"Student: {g.student.studentname}  Karakter: {g.grade1}  Fag: {g.coursecode} \n";
                }
            }

            if (outputBox.Text == "")
            {
                outputBox.Text = "Ingen resultat";
            }
        }

        private void showStudent(String name)
        {
            foreach (student s in students)
            {
                if (s.studentname == name || s.studentname.ToLower() == name)
                {
                    outputBox.Text += $"Student: {s.studentname} \n";
                }
            }

            if (outputBox.Text == "")
            {
                outputBox.Text = $"Ingen resultat på '{name}'";
            }
        }
      

        private void studentButton_Click(object sender, RoutedEventArgs e)
        {
            outputBox.Text = "";
            showStudent(sokTekst.Text);
        }

        private void karakterButton_click(object sender, RoutedEventArgs e)
        {
            outputBox.Text = "";
            getGrades(sokTekst.Text);
            
        }

        private void strykButton_click(object sender, RoutedEventArgs e)
        {
            outputBox.Text = "";
            foreach (grade g in grades)
            {
                if (g.grade1 == "F")
                {
                    outputBox.Text += $"Student: {g.student.studentname} strøk i {g.course.coursename} \n";
                }
            }
        }

        private void cmbCourses_SelectionChanged(object sender, EventArgs e)
        {
            outputBox.Text = "";
            ComboBox cmb = sender as ComboBox;
            
            foreach (course c in courses)
            {
                if (c.coursename == cmb.SelectedItem.ToString())
                {
                    foreach (grade s in grades)
                    {
                        if (s.coursecode == c.coursecode)
                        {
                            outputBox.Text += s.student.studentname + "   " + s.grade1 + "\n";
                        }
                    }
                }
            }
        }

        private void getGrades(String grade)
        {
            List<String> grades = new List<String>();

            switch (grade.ToUpper())
            {
                case "A":
                    grades.Add("A");
                    break;
                case "B":
                    grades = new List<String> { "A", "B" };
                    break;
                case "C":
                    grades = new List<String> { "A", "B", "C"};
                    break;
                case "D":
                    grades = new List<String> { "A", "B", "C", "D"};
                    break;
                case "E":
                    grades = new List<String> { "A", "B", "C", "D", "E"};
                    break;
                case "F":
                    grades = new List<String> { "A", "B", "C", "D", "E", "F"};
                    break;
            }

           showGrades(grades);

        }
    }
}
