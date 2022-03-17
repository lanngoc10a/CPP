using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSim
{
    public class SpaceObject
    {
        private string name;
        private double orbitalRadius;
        private double orbitalPeriod;
        private double objectRadius;
        private double rotationalPeriod;
        private string objectColor;

        private double x = 0;
        private double y = 0;


        public SpaceObject(String name)
        {
            this.name = name;
        }

        public SpaceObject(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, string objectColor) : this(name)
        {
            this.orbitalRadius = orbitalRadius;
            this.x = orbitalRadius;
            this.orbitalPeriod = orbitalPeriod;
            this.objectRadius = objectRadius;
            this.rotationalPeriod = rotationalPeriod;
            this.objectColor = objectColor;
        }

        public string Name { get => name; set => name = value; }
        public double OrbitalRadius { get => orbitalRadius; set => orbitalRadius = value; }
        public double ObjectRadius { get => objectRadius; set => objectRadius = value; }
        public double RotationalPeriod { get => rotationalPeriod; set => rotationalPeriod = value; }
        public string ObjectColor { get => objectColor; set => objectColor = value; }
        public double OrbitalPeriod { get => orbitalPeriod; set => orbitalPeriod = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public virtual void calculatePosition(float time)
        {
            this.x = orbitalRadius * Math.Cos(((2 * Math.PI) * (time - 0)) / (orbitalPeriod));
            this.y = orbitalRadius * Math.Sin(((2 * Math.PI) * (time - 0)) / (orbitalPeriod));
        }

        public virtual void Draw()
        {
            Console.WriteLine(name);
            Console.WriteLine("Orbital Radius:" + orbitalRadius);
            Console.WriteLine("Object Radius: " + objectRadius);
            Console.WriteLine("Rotational Period: " + rotationalPeriod);
            Console.WriteLine("Color: " + objectColor);
            Console.WriteLine("X position: " + x);
            Console.WriteLine("Y position: " + y);
        }
    }

    public class Star : SpaceObject
    {
        public Star(String name) : base(name) { }
        public Star(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, string objectColor)
            : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) { }

        public override void Draw()
        {
            Console.Write("Star: ");
            base.Draw();
        }
    }
    public class Planet : SpaceObject
    {
        public Planet(String name) : base(name) { }

        public Planet(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, string objectColor)
            : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) { }
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }

    public class Moon : SpaceObject
    {
        public Moon(String name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Moon: ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(String name) : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("Comet: ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(String name) : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("Asteroid: ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(String name) : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("Asteroid Belt: ");
            base.Draw();
        }
    }
}
