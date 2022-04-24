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
}

