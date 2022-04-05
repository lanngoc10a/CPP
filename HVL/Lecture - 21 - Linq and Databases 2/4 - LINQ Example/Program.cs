﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// The following 3 classes represent the 3 main items in our
// application: Students, Grades and Courses.
class Student {
    public string StudentName { get; set; }
    public int StudentID { get; set; }
}

class Course {
    public string CourseName { get; set; }
    public string CourseID { get; set; }
}

class Grade {
    public char grade { get; set; }
    public string CourseID { get; set; }
    public int StudentID { get; set; }
}

// The following three classes are collection classes for
// storing lists of the above classes. Each of these
// collections implements the IEnumerable interface to
// make them iterable.
class StudentList : IEnumerable<Student> {
    private List<Student> students = new List<Student>();

    public void Add(string n, int id) {
        students.Add(new Student { StudentName = n, StudentID = id });
    }

    IEnumerator<Student> IEnumerable<Student>.GetEnumerator() {
        foreach (Student s in students)
            yield return s;
    }

    IEnumerator IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
    }
}

class CourseList : IEnumerable<Course> {
    private List<Course> courses = new List<Course>();

    public void Add(string n, string id) {
        courses.Add(new Course { CourseName = n, CourseID = id });
    }

    IEnumerator<Course> IEnumerable<Course>.GetEnumerator() {
        foreach (Course c in courses)
            yield return c;
    }

    IEnumerator IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
    }
}

class GradeList : IEnumerable<Grade> {
    private List<Grade> grades = new List<Grade>();

    public void Add(char g, string cid, int sid) {
        grades.Add(new Grade { grade = g, CourseID = cid, StudentID = sid });
    }

    IEnumerator<Grade> IEnumerable<Grade>.GetEnumerator() {
        foreach (Grade g in grades)
            yield return g;
    }

    IEnumerator IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
    }
}
// Main program. Creates an instance of each list and // populates it with data. It then uses both forms of // LINQ to query the dataset. Note that both the LINQ // queries produce identical results, except that the // last one also introduces a where condition to only
// show grades better than a define threshold.class Program {
class Program {
    static void Main(string[] args) {

        StudentList sl = new StudentList();
        CourseList cl = new CourseList();
        GradeList gl = new GradeList();

        sl.Add("Roger Rabbit", 123);
        sl.Add("Donald Duck", 456);
        sl.Add("Superman", 111);

        cl.Add("Programming 101", "TOD765");
        cl.Add("Difficult Math", "FOA432");
        cl.Add("Sleepwalking", "TVD879");

        gl.Add('A', "TOD765", 123);
        gl.Add('B', "TOD765", 111);
        gl.Add('F', "FOA432", 123);
        gl.Add('E', "FOA432", 456);
        gl.Add('C', "FOA432", 111);
        gl.Add('D', "TVD879", 123);
        gl.Add('C', "TVD879", 456);

        // Queries the dataset and stores the result in the
        // studcourse variable
        var studcourse = sl
         .Select(stud => new { stud.StudentName, stud.StudentID })
         .Join(gl, stud => stud.StudentID, gr => gr.StudentID, (stud, gr)
                 => new { stud.StudentName, gr.CourseID, gr.grade })
         .Join(cl, gr => gr.CourseID, course => course.CourseID, (gr, course)
                  => new { gr.StudentName, gr.grade, course.CourseName });

        // Iterates through the result set stored in studcourse
        foreach (var s in studcourse) {
            Console.WriteLine("{0} - {1} - {2}", s.StudentName, s.CourseName, s.grade);
        }
        Console.WriteLine();
        Console.ReadKey();

        char gradeLimit = 'B';

        // Queries the dataset and stores the result in the
        // studcoursesql variable
        var studcoursesql = from stud in sl
                            join gr in gl
                            on stud.StudentID equals gr.StudentID
                            join c in cl
                            on gr.CourseID equals c.CourseID
                            where gr.grade <= gradeLimit
                            select new { stud.StudentName, gr.grade, c.CourseName };

        foreach (var s in studcoursesql) {
            Console.WriteLine("{0} - {1} - {2}", s.StudentName, s.CourseName, s.grade);
        }

        Console.ReadKey();

    }
}


