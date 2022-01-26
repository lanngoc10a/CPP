#include <iostream>
using namespace std;

int Myfunction(const char *p)
{
    int i = 0;
    for (; *p; p++)
    {
        i++;
    }

    return i;
}

int main(int, char **)
{
    char buffer[25];
    std::cout << "Enter a word: ";
    std::cin >> buffer;
    std::cout << Myfunction(buffer) << "\n";
}