 #include <iostream>
using namespace std;

int Myfunction(const char* p) { 
    int i = 0; 
    for (; *p; p++) { 
        i++; 
    } 
 
    return i; 
} 
 
 //*p is a variable that stores an address.