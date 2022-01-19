//wizard.cpp
#include <iostream>
using namespace std;
#include "wizard.h"

void Wizard::Fight(){
    cout << "Fighting!" << endl;
}
void Wizard::Talk(){
    cout << "Talking." << endl;
}
void Wizard::CastSpell(){
    cout << "Casting spell." << endl;
}
void Wizard::PrintStats(){
    cout << "Wizard stats:"
         << "\nName:\t" << m_name 
         << "\n# hitpoints:\t" << m_hitPoints ;
};


int main()
{
    Wizard wiz; //parameter after the constructor
    wiz.CastSpell();
    wiz.Fight();
    wiz.PrintStats();
    wiz.Talk();
    wiz.Talk();
    return 0;
    //wiz.m:armor=10 //cannot access private member
}