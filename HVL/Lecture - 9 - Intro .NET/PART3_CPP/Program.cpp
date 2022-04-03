#include <iostream>
using namespace std;
class CVehicle {
public:
    virtual const char* Info() { return "Vehicle:"; }
    int speed;
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
void SetSpeed(int s, CVehicle* pv)
{   // Stupid way, but demo :=)
    pv->speed = s;
}
int main()
{
    CVehicle* arr[] = { new CCar(),new CBike(),new CSportsCar,new CCar};
    int nCars = 0;
    int nTot = sizeof(arr) / sizeof(arr[0]);

    cout << "C++ program : " << endl;
    for (int i = 0; i < nTot; i++)
    {
        CVehicle* pv = arr[i];
        if (dynamic_cast<CCar*>(pv))
        {
            nCars++;
            SetSpeed(100, pv);
        }
        else
            SetSpeed(20, pv);
        cout << pv->Info() << " Speed: " << pv->speed << endl;      
        delete pv;  // Dont use arr after this !!!!!
    }
    cout << "Total Cars:" << nCars << endl;
}