using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    public enum BodyType { Solid, Liquid, Gas }

    public class Chunk
    {
        // Coordinates refer to the center of the cube

        // East-West
        public double X { get; set; }
        // North-South
        public double Y { get; set; }
        // Altitude
        public double Z { get; set; }
        // Celsius
        public double Temperature { get; set; }
        // Movement
        public Vector Direction { get; set; }
        // Physical state
        public BodyType State { get; set; }
        // How much wattage it absorbs
        public double Absorption { get; set; }

        public double Size { get; set; }

        public double Weight { get; set; }

        public List<Chunk> East { get; set; }
        public List<Chunk> West { get; set; }
        public List<Chunk> North { get; set; }
        public List<Chunk> South { get; set; }
        public List<Chunk> Top { get; set; }
        public List<Chunk> Bottom { get; set; }

        public Chunk(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
