//main.cpp
#include "wizard.h"

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