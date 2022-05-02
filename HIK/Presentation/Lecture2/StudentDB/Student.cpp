#include "Student.h"

using namespace std;

Student(string theName, double theGpa) : name(theName), gpa(-1) {
    set_gpa(theGpa);
}

// accessor
string Student::get_name() const {
    return name;
}

// mutator
void Student::set_gpa(double newGpa) {
    if (newGpa >= 0 && newGpa <= 4.0) {
        gpa = newGpa;
    }
}

ostream& operator<<(ostream& ostr, const Student& stud) {
    ostr << stud.get_name() << ", " << stud.gpa;
    return ostr;
}