using System;

namespace SpaceSim {
    public class SpaceObject {

        protected String name;

        public SpaceObject(String _name) {
            name = _name;
        }
        public virtual void Draw() {
            Console.WriteLine(name);
        }
    }

    public class Star : SpaceObject {
        public Star(String _name) : base(_name) { }
        public override void Draw() {
            Console.Write("Star  : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject {
        public Planet(String _name) : base(_name) { }
        public override void Draw() {
            Console.Write("Planet: ");
            base.Draw();
        }
    }

    public class Moon : SpaceObject {
        public Moon(String _name) : base(_name) { }

        public override void Draw() {
            Console.Write("Moon  : ");
            base.Draw();
        }
    }
}

