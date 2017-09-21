using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    class Simulator
    {
        // Constants
        static double RealSunTemp = 2000000;
        static double RealSunDiameter = 1392000;
        static double RealSunWattage = 384600000000000000000000000d;
        static double RealAU = 149597871;
        static double EarthPercentageOfSunlight = 0.00000001;
        static double EarthAvgTemp = 14;
        static double EarthAreaKm = 510070000;
        static string Stars = "********************************************************************************";

        // Settings
        static double AU = 1000000;
        static double MinimumHabitable = 0.93;
        static double MaximumHabitable = 1.35;
        static double TorusDiameterInAU = 2;


        static void Main(string[] args)
        {
            double HabitableLandArea = 0;
            double MinimumHabitableKm = AU * MinimumHabitable;
            double MaximumHabitableKm = AU * MaximumHabitable;
            Console.WriteLine(Stars);
            Console.Write("Settings\n" +
                          "AU: {0:#,###0}km \n" +
                          "Minimum habitable range: {1}% of AU, {2:#,###0}km\n" +
                          "Maximum habitable range: {3}% of AU, {4:#,###0}km\n",
                          AU, MinimumHabitable * 100, Math.Round(MinimumHabitableKm, 2), MaximumHabitable * 100, Math.Round(MaximumHabitableKm, 2));
            Console.WriteLine(Stars);

            HabitableLandArea = Geometry.GetCircleArea(MaximumHabitableKm) - Geometry.GetCircleArea(MinimumHabitableKm);
            HabitableLandArea *= 2;

            if (TorusDiameterInAU < (2 * MaximumHabitable))
            {
                double LargeOverlap = Geometry.GetAreaOfCircleIntersection(AU * TorusDiameterInAU, MaximumHabitableKm, MaximumHabitableKm);
                double SmallOverlap = Geometry.GetAreaOfCircleIntersection(AU * TorusDiameterInAU, MinimumHabitableKm, MaximumHabitableKm) * 2;
                double SmallCircleArea = Geometry.GetCircleArea(MinimumHabitableKm);
                double LargeCircleArea = Geometry.GetCircleArea(MaximumHabitableKm);

                HabitableLandArea = (2 * LargeCircleArea) - LargeOverlap - (2 * SmallCircleArea);
            }

            double AUPercent = AU / RealAU;

            double SunAngularDiameter = 2 * Math.Asin(RealSunDiameter / (2 * RealAU));
            double NewSunDiameter = Math.Sin(SunAngularDiameter / 2) * 2 * AU;

            double NewSunWattage = (RealSunWattage / (RealAU * RealAU)) * (AU * AU);

            Console.Write("This model has a potentially habitable land area of {0:#,###0} square km ({1:#,###0} square miles).\n" +
                "This is {2}% of Earth's surface area.\n" +
                "This implies a sun that is {3:#,###0}km across producing {4} watts to simulate our sun at \n"+
                "{5}% of a real AU.",
                HabitableLandArea, Conversion.SqKmToSqMile(HabitableLandArea), Math.Round(HabitableLandArea / EarthAreaKm, 2),
                Math.Round(NewSunDiameter, 2), Math.Round(NewSunWattage, 2), Math.Round(AUPercent, 4));

            Console.ReadLine();
        }
    }
}
