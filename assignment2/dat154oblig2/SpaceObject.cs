using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSim
{
    public class SpaceObject
    {
        public SpaceObject(string name)
        {
            this.Name = name;
        }

        public SpaceObject(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, string objectColor) : this(name)
        {
            this.OrbitalRadius = orbitalRadius;
            this.X = orbitalRadius;
            this.OrbitalPeriod = orbitalPeriod;
            this.ObjectRadius = objectRadius;
            this.RotationalPeriod = rotationalPeriod;
            this.ObjectColor = objectColor;
        }

        public string Name { get; set; }
        public double OrbitalRadius { get; set; }
        public double ObjectRadius { get; set; }
        public double RotationalPeriod { get; set; }
        public string ObjectColor { get; set; }
        public double OrbitalPeriod { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public virtual void calculatePosition(float time)
        {
            this.X = OrbitalRadius * Math.Cos(((2 * Math.PI) * (time - 0)) / (OrbitalPeriod));
            this.Y = OrbitalRadius * Math.Sin(((2 * Math.PI) * (time - 0)) / (OrbitalPeriod));
        }

        public virtual void Draw()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Orbital Radius:" + OrbitalRadius);
            Console.WriteLine("Object Radius: " + ObjectRadius);
            Console.WriteLine("Rotational Period: " + RotationalPeriod);
            Console.WriteLine("Color: " + ObjectColor);
            Console.WriteLine("X position: " + X);
            Console.WriteLine("Y position: " + Y);
        }
    }

    public class Star : SpaceObject
    {
        public Star(string name) : base(name) { }
        public Star(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, string objectColor)
            : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) { }

        public override void Draw()
        {
            Console.Write("Star: ");
            base.Draw();
        }
    }
    public class Planet : SpaceObject
    {

        List<Moon> moons;
        public Planet(string name) : base(name) { }

        // Fix constructor to pass in moons
        public Planet(string name, double orbitalRadius, double orbitalPeriod
            , double objectRadius, double rotationalPeriod, string objectColor, List<Moon> moons)
            : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) 
        {
            this.moons = moons;
        }
 
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }

    public class Moon : SpaceObject
    {
        string planet;

        public Moon(string name) : base(name) { }

        public Moon(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, string objectColor)
            : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) { }

        public override void Draw()
        {
            Console.Write("Moon: ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(string name) : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("Comet: ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(string name) : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("Asteroid: ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(string name) : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("Asteroid Belt: ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(string name) : base(name) { }

        public DwarfPlanet(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, string objectColor)
           : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) { }

        public override void Draw()
        {
            Console.WriteLine("Dwarf planet: ");
            base.Draw();
        }
    }
}
