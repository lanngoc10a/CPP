﻿using System;
using System.Collections.Generic;

namespace _8___EF_Core.Models
{
    public partial class Course
    {
        public Course()
        {
            Grades = new HashSet<Grade>();
        }

        public string Coursecode { get; set; } = null!;
        public string Coursename { get; set; } = null!;
        public string Semester { get; set; } = null!;
        public string Teacher { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
