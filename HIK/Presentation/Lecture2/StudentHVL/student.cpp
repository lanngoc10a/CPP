#include <iostream>
#include <string>
using namespace std;

#pragma warning(disable: 4996)

class Stud
{
    public:
    Stud(int nr): _nr(nr){
    }
    int _nr;
};

void Show(Stud* p){
    cout << "Stud" << p->_nr;
}

void main(){
    Stud* ps1 = new Stud(1);
    Stud* ps2 = new Stud(2);

    // cout << "Stud1 " << ps1->_nr;
    // cout << "Stud2 " << ps2->_nr;
    Show(ps1);
    Show(ps2);
    
    //REMEMBER TO DELETE THE STUDENTS
    delete ps1;
    delete ps2;
}