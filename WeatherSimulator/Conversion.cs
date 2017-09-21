using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    class Conversion
    {
        public static double MileToKm(double mi)
        {
            return mi * 1.609344;
        }
        public static double KmToMile(double km)
        {
            return km / 1.609344;
        }
        public static double SqMileToSqKm(double sqmi)
        {
            return sqmi * 2.58998811;
        }
        public static double SqKmToSqMile(double sqkm)
        {
            return sqkm / 2.58998811;
        }
    }
}
