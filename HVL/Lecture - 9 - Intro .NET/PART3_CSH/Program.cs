using static System.Console;
class Program
{
    class CVehicle
    {
        public virtual string Info() => "Vehicle"; // Short as {return ...};
        public int speed;
    }
    class CCar : CVehicle
    {
        public override string Info() => "Car";
    }
    class CBike : CVehicle
    {
        public override string Info() => "Bike";
    }
    class CSportsCar : CCar
    {
        public override string Info() => "SportCar";
    }
    static void SetSpeed(int s, CVehicle v)
    {
        v.speed = s;
    }
    static void Main(string[] args)
    {
        CVehicle[] arr =  { new CCar(), new CBike(), new CSportsCar(), new CCar() };
        int nCars = 0;

        WriteLine("C Sharp program:");
        for (int i = 0; i < arr.Length; i++)
        {
            CVehicle v = arr[i];
            if (v is CCar)
            {
                nCars++;
                SetSpeed(100, v);
            }
            else
                SetSpeed(20, v);
            WriteLine(v.Info() + " Speed:" + v.speed);
        }
        WriteLine("Cars:" + nCars); 
    }
}

