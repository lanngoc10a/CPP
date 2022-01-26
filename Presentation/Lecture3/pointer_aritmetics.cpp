#include <iostream>
#include <string>
using namespace std;

int main()
{
    char s[] = "Its a nice day, my house is on fire";
    char *p = s;
    int n = 0;
    for (; *p != 0; p++)
    {
        if (*p == 'e')
            n++;
    }
    cout << "Number of e's: " << n;

}