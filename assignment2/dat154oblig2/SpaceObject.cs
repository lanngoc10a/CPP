using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSim
{
    public class SpaceObject
    {
        List<Moon> moons;

        public SpaceObject(string name)
        {
            this.Name = name;
        }

        public SpaceObject(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, Color objectColor) : this(name)
        {
            this.OrbitalRadius = orbitalRadius;
            this.X = orbitalRadius;
            this.OrbitalPeriod = orbitalPeriod;
            this.ObjectRadius = objectRadius;
            this.RotationalPeriod = rotationalPeriod;
            this.ObjectColor = objectColor;
            this.ScalingToSun = 696340 / objectRadius;
        }

        public string Name { get; set; }
        public double OrbitalRadius { get; set; }
        public double ObjectRadius { get; set; }
        public double RotationalPeriod { get; set; }
        public Color ObjectColor { get; set; }
        public double ScalingToSun { get; }
        public double OrbitalPeriod { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public List<Moon> Moons { get => moons; set => moons = value; }

        public void CalculatePosition(float time)
        {
            this.X = CalculatePositionX(time);
            this.Y = CalculatePositionY(time);
        }

        public virtual double CalculatePositionX(float time) => OrbitalRadius * Math.Cos(((2 * Math.PI) * (time - 0)) / (OrbitalPeriod));
        public virtual double CalculatePositionY(float time) => OrbitalRadius * Math.Sin(((2 * Math.PI) * (time - 0)) / (OrbitalPeriod));

        public virtual PointF calculatePositionPointF(float time)
        {
            X = (float)(OrbitalRadius * Math.Cos(((2 * Math.PI) * (time - 0)) / (OrbitalPeriod)));
            Y = (float)(OrbitalRadius * Math.Sin(((2 * Math.PI) * (time - 0)) / (OrbitalPeriod)));

            return new PointF((float)X, (float)Y);
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
        public Star(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, Color objectColor)
            : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) { }

        public override void Draw()
        {
            Console.Write("Star: ");
            base.Draw();
        }
    }
    public class Planet : SpaceObject
    {
        public Planet(string name) : base(name) { }

        public Planet(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, Color objectColor)
            : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) { }

        public Planet(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, Color objectColor, List<Moon> moons)
            : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor)
        {
            this.Moons = moons;
        }

        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }

    public class Moon : SpaceObject
    {
        Planet Planet { get; set; }

        public Moon(string name) : base(name) { }

        public Moon(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, Color objectColor)
            : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) { }

        public override double CalculatePositionX(float time) => base.CalculatePositionX(time) + Planet.X;
        public override double CalculatePositionY(float time) => base.CalculatePositionX(time) + Planet.Y;


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

        public DwarfPlanet(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, Color objectColor)
           : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColor) { }

        public override void Draw()
        {
            Console.WriteLine("Dwarf planet: ");
            base.Draw();
        }
    }
}
