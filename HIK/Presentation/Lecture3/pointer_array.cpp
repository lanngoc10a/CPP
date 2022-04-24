//Since a pointer is a variable you may change its value. It will then point to another memory area.

#include <iostream>
#include <string>
using namespace std;

// An interger is 4 bytes in this version

// Val: 0Ptr Adr: 0x7ffee09a2480
// Val: 1Ptr Adr: 0x7ffee09a2484
// Val: 9Ptr Adr: 0x7ffee09a248c
// 0x7ffee09a248c is hex value and it is exactly 4

int main(){
    int t[] = {0,1,4,9,16,25,36,49,64,81,100};
    int* pi = t;
    cout << "Val: " << *pi << " Ptr Adr: " << pi << endl;
    pi = pi+1;
    cout << "Val: " << *pi << " Ptr Adr: " << pi << endl;
    pi = pi+2;
    cout << "Val: " << *pi << " Ptr Adr: " << pi << endl;
}