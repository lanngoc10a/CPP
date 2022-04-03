#include <iostream>
using namespace std;
class CVehicle {
public: virtual
    const char* Info() { return "Vehicle:"; }
};
class CBike : public CVehicle {
public:
    const char* Info() { return "Bike"; }
};
class CCar : public CVehicle {
public:
    const char* Info() { return "Car"; }
};

class CSportsCar : public CCar {
public:
    const char* Info() { return "Sport Car"; }
};
int main()
{
    CVehicle* arr[] = { new CCar(),new CBike(),new CSportsCar,
                        new CCar, new CCar, new CCar };
    int nCars = 0;
    for (int i = 0; i < sizeof(arr) / sizeof(arr[0]); i++)
    {
        cout << arr[i]->CVehicle::Info() << arr[i]->Info() << endl;
        if (dynamic_cast<CCar*>(arr[i]))
            nCars++;
    }
    cout << "Total Cars:" << nCars << endl;
}
//// Number of elements of an array
//int sa = sizeof(arr);
//int se = sizeof(arr[0]); // Also use sizeof(CVehicle*);
//int n = sizeof(arr) / sizeof(arr[0]);
//cout << "sa=" << sa << " se=" << se << endl;
//cout << "Number of elements : " << n;