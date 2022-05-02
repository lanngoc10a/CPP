#include <iostream>
#include <string>
using namespace std;

void SquareTwo(int* px, int* py)
{
    *px = *px * *px;
    *py = *py * *py;
}
int main()
{
    int x = 10;
    int y = 20;

    cout << "x =" << x << " y= " << y << endl;
    SquareTwo(&x, &y);
    cout << "x2= " << x << " y2 =" << y << endl;
}