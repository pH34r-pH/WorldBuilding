using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    public class Geometry
    {
        public static double GetCircleArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        public static double GetAreaOfCircleIntersection(double d, double r, double R)
        {
            if (R < r)
            {
                double nope = r;
                r = R;
                R = nope;
            }

            double part1 = r * r * Math.Acos((d * d + r * r - R * R) / (2 * d * r));
            double part2 = R * R * Math.Acos((d * d + R * R - r * r) / (2 * d * R));
            double part3 = 0.5 * Math.Sqrt((-d + r + R) * (d + r - R) * (d - r + R) * (d + r + R));

            return part1 + part2 - part3;
        }

        public static double GetSphereArea(double radius)
        {
            return 4 * Math.PI * radius * radius;
        }

        public static double GetAngularDiameter(double bodyDiameter, double range)
        {
            return 2 * Math.Asin(bodyDiameter / (2 * range));
        }

        public static double GetBodySize(double angularDiameter, double range)
        {
            return Math.Sin(angularDiameter / 2) * 2 * range;
        }
    }
}
