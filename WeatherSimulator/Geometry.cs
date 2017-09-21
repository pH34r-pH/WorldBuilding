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

        public static double GetAreaOfCircleIntersection(double distanceBetweenCenters, double radiusOfSmaller, double radiusOfLarger)
        {
            if (radiusOfLarger < radiusOfSmaller)
            {
                double nope = radiusOfSmaller;
                radiusOfSmaller = radiusOfLarger;
                radiusOfLarger = nope;
            }

            double part1 = Math.Pow(radiusOfSmaller, 2) * Math.Acos((Math.Pow(distanceBetweenCenters, 2) +
                Math.Pow(radiusOfSmaller, 2) - Math.Pow(radiusOfLarger, 2)) / (2 * distanceBetweenCenters * radiusOfSmaller));

            double part2 = Math.Pow(radiusOfLarger, 2) * Math.Acos((Math.Pow(distanceBetweenCenters, 2) + 
                Math.Pow(radiusOfLarger, 2) - Math.Pow(radiusOfSmaller, 2)) / (2 * distanceBetweenCenters * radiusOfLarger));

            double part3 = 0.5 * Math.Sqrt((-distanceBetweenCenters + radiusOfSmaller + radiusOfLarger) * 
                (distanceBetweenCenters + radiusOfSmaller - radiusOfLarger) * 
                (distanceBetweenCenters - radiusOfSmaller + radiusOfLarger) * 
                (distanceBetweenCenters + radiusOfSmaller + radiusOfLarger));

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

        public static double GetBodySizeFromAngularDiameter(double angularDiameter, double range)
        {
            return Math.Sin(angularDiameter / 2) * 2 * range;
        }
    }
}
