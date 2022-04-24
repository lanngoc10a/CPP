#include <iostream>
#include <string>
using namespace std;
//*pointer: a variable that stores an address. In C++ int* intPtr=nullptr; Pointer has a type which indicates which type of variable it points to

int main(){
    int x=10;
    int *p=&x;
    cout << "The value of x is : " << p << "\n" << endl;
    cout << "The value of x is : " << *p;
}