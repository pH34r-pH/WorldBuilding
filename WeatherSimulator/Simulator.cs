using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    class Simulator
    {
        static string Stars = "********************************************************************************";

        static void Main(string[] args)
        {
            World ThePlane = new World();
            
            Console.WriteLine(Stars);
            Console.Write("Settings\n" +
                          "AU: {0:#,###0}km \n" +
                          "Minimum habitable range: {1}% of AU, {2:#,###0}km\n" +
                          "Maximum habitable range: {3}% of AU, {4:#,###0}km\n",
                          ThePlane.AU, ThePlane.MinimumHabitable * 100, Math.Round(ThePlane.MinimumHabitableKm, 2), ThePlane.MaximumHabitable * 100, 
                          Math.Round(ThePlane.MaximumHabitableKm, 2));
            Console.WriteLine(Stars);

            Console.Write("This model has a potentially habitable land area of {0:#,###0} square km ({1:#,###0} square miles).\n" +
                "This is {2}% of Earth's surface area.\n" +
                "This implies a sun that is {3:#,###0}km across producing {4} watts to simulate our sun at \n"+
                "{5}% of a real AU.",
                ThePlane.HabitableLandArea, Conversion.SqKmToSqMile(ThePlane.HabitableLandArea), 
                Math.Round(ThePlane.HabitableLandArea / ThePlane.EarthAreaKm, 2),
                Math.Round(ThePlane.SunDiameter, 2), Math.Round(ThePlane.SunWattage, 2), Math.Round(ThePlane.AUPercent, 4));

            Console.ReadLine();
        }


    }
}
