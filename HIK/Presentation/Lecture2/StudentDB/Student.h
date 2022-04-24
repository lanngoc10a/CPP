//#ifndef STUDENTDB_STUDENT_H
//#define STUDENTDB_STUDENT_H

#include <string>
#include <iostream>
using namespace std;

class Student {
    //private:
    string name;
    double gpa;

    public:
    Student(string theName, double theGpa);

    // accessor
    string get_name() const;

    // mutator
    void set_gpa(double newGpa);

    friend ostream& operator<<(ostream& ostr, const Student& stud);
};

ostream& operator<<(ostream& ostr, const Student& stud);

//#endif //STUDENTDB_STUDENT_H