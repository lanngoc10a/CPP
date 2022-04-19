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
        ComboBox cmb;

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

        /*
         *  Task 1
         *  
         *  Search for student and show info
         *  
         *  Listview contains=[studentid, studentname, studentage]
         */
      
        private void studentButton_Click(object sender, RoutedEventArgs e)
        {
            listView.View = null;
            String name = sokTekst.Text;

            List<grade> studs = new List<grade>();

            foreach (grade s in grades)
            {
                if (s.student.studentname == name || s.student.studentname.ToLower() == name)
                {
                    s.grade1 = null;
                    studs.Add(s);
                }
            }

            listView.ItemsSource = studs;

            if (!studs.Any())
            {
                listView.View = null;
                MessageBox.Show($"Ingen resultat på '{name}', prøv igjen");
            }
            else
            {
                listView.View = selectListView(false, false);

                listView.ItemsSource = studs;
            }
        }

        /*
         *  Task 2
         *  
         *  Select course from dropdown list (dropdown list is initialized in MainWindow()
         *  
         *  Listview = [studentid, studentname, studentage, grade, coursecode, coursename]
         */

        private void cmbCourses_SelectionChanged(object sender, EventArgs e)
        {
            List<grade> studs = new List<grade>();

            cmb = sender as ComboBox;

            foreach (course c in courses)
            {
                if (c.coursename == cmb.SelectedItem.ToString())
                {
                    foreach (grade s in grades)
                    {
                        if (s.coursecode == c.coursecode)
                        {
                            studs.Add(s);
                        }
                    }
                }
            }

            listView.View = selectListView(true, false);

            listView.ItemsSource = studs;
        }

        /*
         *  Task 3
         *  
         *  Select grade and show all the grades equal or better, with student information
         *  
         *  Listview = [studentid, studentname, studentage, grade, coursecode, coursename]
         */

        private void karakterButton_click(object sender, RoutedEventArgs e)
        {
            listView.View = null;

            List<String> stringGrade = getGrades(sokTekst.Text);

            List<grade> grads = new List<grade>();

            foreach (grade g in grades)
            {
                if (stringGrade.Contains(g.grade1))
                {
                    grads.Add(g);
                }
            }

            if (!grads.Any())
            {
                MessageBox.Show($"Ingen resultat på '{sokTekst.Text}', prøv igjen");

            }
            else
            {
                listView.View = selectListView(false, true);

                listView.ItemsSource = grads;
            }
        }

        /*
         *  Task 4
         *  
         *  Show all students who failed
         *  
         *  Listview = [studentid, studentname, studentage, grade, coursecode, coursename]
         */

        private void strykButton_click(object sender, RoutedEventArgs e)
        {
            List<grade> studs = new List<grade>();

            foreach (grade g in grades)
            {
                if (g.grade1 == "F")
                {
                    studs.Add(g);
                }
            }

            listView.View = selectListView(false, true);

            listView.ItemsSource = studs;
            
        }

        /*
         *  Task 5
         *  
         *  Add and remove students
         * 
         */

        private void addStudent_click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show($"{nameInput.Text}  ,  {ageInput.Text} " +
                $"{cmb.SelectedItem}, {gradeInput.Text}");

            using (dx)
            {
                if (nameInput.Text != null && ageInput != null && cmb.SelectedItem != null)
                {
                    student newstud = new student();
                }
                
            }
        }


        /*
         *  Returns grade equal or better to given grade
         */

        private List<String> getGrades(String grade)
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

            return grades;

        }

        /*
         *  Creates listview given what information is wanted
         */

        private GridView selectListView(bool showCourse, bool showGrade)
        {
            GridView myGridView = new GridView();
            myGridView.AllowsColumnReorder = true;

            GridViewColumn gvc1 = new GridViewColumn();
            gvc1.DisplayMemberBinding = new Binding("studentid");
            gvc1.Header = "ID";
            gvc1.Width = 50;
            myGridView.Columns.Add(gvc1);
            GridViewColumn gvc2 = new GridViewColumn();
            gvc2.DisplayMemberBinding = new Binding("student.studentname");
            gvc2.Header = "Name";
            gvc2.Width = 150;
            myGridView.Columns.Add(gvc2);
            GridViewColumn gvc3 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("student.studentage");
            gvc3.Header = "Age";
            gvc3.Width = 50;
            myGridView.Columns.Add(gvc3);

            if (showCourse)
            {
                GridViewColumn gvc4 = new GridViewColumn();
                gvc4.DisplayMemberBinding = new Binding("grade1");
                gvc4.Header = "Grade";
                gvc4.Width = 50;
                myGridView.Columns.Add(gvc4);

            }

            if (showGrade)
            {
                GridViewColumn gvc4 = new GridViewColumn();
                gvc4.DisplayMemberBinding = new Binding("grade1");
                gvc4.Header = "Grade";
                gvc4.Width = 50;
                myGridView.Columns.Add(gvc4);

                GridViewColumn gvc5 = new GridViewColumn();
                gvc5.DisplayMemberBinding = new Binding("course.coursecode");
                gvc5.Header = "Course code";
                gvc5.Width = 100;
                myGridView.Columns.Add(gvc5);

                GridViewColumn gvc6 = new GridViewColumn();
                gvc6.DisplayMemberBinding = new Binding("course.coursename");
                gvc6.Header = "Course name";
                gvc6.Width = 200;
                myGridView.Columns.Add(gvc6);
            }

            return myGridView;
        }
    }
}
