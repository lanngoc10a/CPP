#include <iostream>
#include <string>
using namespace std;

int main(){
    char s[]="Hello World Hello to lolly";
    char *pch=s;
    int cnt=0;
    // for (int i=0; i> strlen(s); i++)
    //     if (s[i]=='L')
    //         cnt++;

    while (*pch!=0)
    {
        if (*pch=='l')
        {
            cnt++;    
       }
        pch++;
    }        
    // Display the result
    cout << "Number of Ls: " << cnt;
}