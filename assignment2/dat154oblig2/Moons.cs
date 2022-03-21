using SpaceSim;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class Moons
    {

        public static List<Moon> Earth { get; } = new List<Moon>
        {
            new Moon("Moon", 384, 27.32, 41.2, 24.1, Color.White)
        };

        public static List<Moon> Mars { get; } = new List<Moon>
        {
            new Moon("Phobos", 9, 0.32, 41.2, 24.1, Color.White),
            new Moon("Deimos", 23, 46023, 41.2, 24.1, Color.White)
        };

        public static List<Moon> Jupiter { get; } = new List<Moon>
        {
            new Moon("Metis", 128, 0.29, 41.2, 24.1, Color.White),
            new Moon("Adrastea", 129, 0.3, 41.2, 24.1, Color.White),
            new Moon("Amalthea", 181, 0.35, 41.2, 24.1, Color.White),
            new Moon("Thebe", 222, 0.67, 41.2, 24.1, Color.White),
            new Moon("Io", 422, 28126, 41.2, 24.1, Color.White),
            new Moon("Europa", 671, 20149, 41.2, 24.1, Color.White),
            new Moon("Ganymede", 1070, 42186, 41.2, 24.1, Color.White),
            new Moon("Callisto", 1883, 16.69, 41.2, 24.1, Color.White),
            new Moon("Leda", 11094, 238.72, 41.2, 24.1, Color.White),
            new Moon("Himalia", 11480, 250.57, 41.2, 24.1, Color.White),
            new Moon("Lysithea", 11720, 259.22, 41.2, 24.1, Color.White),
            new Moon("Elara", 11737, 259.65, 41.2, 24.1, Color.White),
                new Moon("Ananke", 21200, 631, 41.2, 24.1, Color.White),  //minus rotasjon
                new Moon("Carme", 22600, 692, 41.2, 24.1, Color.White),  //minus rotasjon
                new Moon("Pasiphae", 23500, 735, 41.2, 24.1, Color.White),  //minus rotasjon
                new Moon("Sinope", 23700, 758, 41.2, 24.1, Color.White)  //minus rotasjon
        };

        public static List<Moon> Saturn { get; } = new List<Moon>
        {
            new Moon("Pan", 134, 0.58, 41.2, 24.1, Color.White),
            new Moon("Atlas", 138, 0.6, 41.2, 24.1, Color.White),
            new Moon("Prometheus", 139, 0.61, 41.2, 24.1, Color.White),
            new Moon("Pandora", 142, 0.63, 41.2, 24.1, Color.White),
            new Moon("Epimetheus", 151, 0.69, 41.2, 24.1, Color.White),
            new Moon("Janus", 151, 0.69, 41.2, 24.1, Color.White),
            new Moon("Mimas", 186, 0.94, 41.2, 24.1, Color.White),
            new Moon("Enceladus", 238, 13516, 41.2, 24.1, Color.White),
            new Moon("Tethys", 295, 32509, 41.2, 24.1, Color.White),
            new Moon("Telesto", 295, 32509, 41.2, 24.1, Color.White),
            new Moon("Calypso", 295, 32509, 41.2, 24.1, Color.White),
            new Moon("Dione", 377, 27061, 41.2, 24.1, Color.White),
            new Moon("Helene", 377, 27061, 41.2, 24.1, Color.White),
            new Moon("Rhea", 527, 19085, 41.2, 24.1, Color.White),
            new Moon("Titan", 1222, 15.95, 41.2, 24.1, Color.White),
            new Moon("Hyperion", 1481, 21.28, 41.2, 24.1, Color.White),
            new Moon("Iapetus", 3561, 79.33, 41.2, 24.1, Color.White),
            new Moon("Phoebe", 12952, 550.48, 41.2, 24.1, Color.White)   //minus rotasjon
        };

        public static List<Moon> Uranus { get; } = new List<Moon>
        {
                  new Moon("Cordelia", 50, 0.34, 41.2, 24.1, Color.White),
                  new Moon("Ophelia", 54, 0.38, 41.2, 24.1, Color.White),
                  new Moon("Bianca", 59, 0.43, 41.2, 24.1, Color.White),
                  new Moon("Cressida", 62, 0.46, 41.2, 24.1, Color.White),
                  new Moon("Desdemona", 63, 0.47, 41.2, 24.1, Color.White),
                  new Moon("Juliet", 64, 0.49, 41.2, 24.1, Color.White),
                  new Moon("Portia", 66, 0.51, 41.2, 24.1, Color.White),
                  new Moon("Rosalind", 70, 0.56, 41.2, 24.1, Color.White),
                  new Moon("Belinda", 75, 0.62, 41.2, 24.1, Color.White),
                  new Moon("Puck", 86, 0.76, 41.2, 24.1, Color.White),
                  new Moon("Miranda", 130, 14977, 41.2, 24.1, Color.White),
                  new Moon("Ariel", 191, 19025, 41.2, 24.1, Color.White),
                  new Moon("Umbriel", 266, 41730, 41.2, 24.1, Color.White),
                  new Moon("Titania", 436, 26146, 41.2, 24.1, Color.White),
                  new Moon("Oberon", 583, 13.46, 41.2, 24.1, Color.White),
                  new Moon("Caliban", 7169, 580, 41.2, 24.1, Color.White),  //minus rotasjon
                  new Moon("Stephano", 7948, 674, 41.2, 24.1, Color.White),  //minus rotasjon
                  new Moon("Sycorax", 12213, 1289, 41.2, 24.1, Color.White),  //minus rotasjon
                  new Moon("Porspero", 16568, 2019, 41.2, 24.1, Color.White),  //minus rotasjon
                  new Moon("Setebos", 17681, 2239, 41.2, 24.1, Color.White)  //minus rotasjon
        };

        public static List<Moon> Neptune { get; } = new List<Moon>
        {
                  new Moon("Naiad", 48, 0.29, 41.2, 24.1, Color.White),
                  new Moon("Thalassa", 50, 0.31, 41.2, 24.1, Color.White),
                  new Moon("Despina", 53, 0.33, 41.2, 24.1, Color.White),
                  new Moon("Galatea", 62, 0.43, 41.2, 24.1, Color.White),
                  new Moon("Larissa", 74, 0.55, 41.2, 24.1, Color.White),
                  new Moon("Proteus", 118, 44166, 41.2, 24.1, Color.White),
                  new Moon("Trition", 355, 5.88, 41.2, 24.1, Color.White),  //minus rotasjon
                  new Moon("Nereid", 5513, 360, 41.2, 24.1, Color.White)
        };

    }
}
