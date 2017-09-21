using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    public class World
    {
        readonly public double RealSunTemp = 2000000;
        readonly public double RealSunDiameter = 1392000;
        readonly public double RealSunWattage = 384600000000000000000000000d;
        readonly public double RealAU = 149597871;
        readonly public double EarthAvgTemp = 14;
        readonly public double EarthAreaKm = 510070000;

        // Adjustable settings
        private double _au;
        public double AU
        {
            get
            {
                return _au;
            }
            set
            {
                _auPercent = value / RealAU;
                _au = value;
            }
        }
        public double MinimumHabitable { get; set; }
        public double MaximumHabitable { get; set; }
        public double TorusDiameterInAU { get; set; }
        // in km
        public double ChunkSize { get; set; }

        // Runtime(ish) variables
        public double HabitableLandArea { get; set; }
        public double MinimumHabitableKm { get; set; }
        public double MaximumHabitableKm { get; set; }

        private double _auPercent;
        public double AUPercent { get { return _auPercent; } }
        public double SunAngularDiameter { get; set; }
        public double SunDiameter { get; set; }
        public double SunWattage { get; set; }

        public World(double au = 1000000, double minAU = 0.93, double maxAU = 1.35, double torusDiameter = 2, double chunkSize = 2)
        {
            AU = au;
            MinimumHabitable = minAU;
            MaximumHabitable = maxAU;
            TorusDiameterInAU = torusDiameter;
            ChunkSize = chunkSize;

            SetHabitableLandArea();
            UpdateSunDimensions();
        }

        public void UpdateSunDimensions()
        {
            SunAngularDiameter = Geometry.GetAngularDiameter(RealSunDiameter, RealAU);
            SunDiameter = Geometry.GetBodySize(SunAngularDiameter, AU);
            SunWattage = (RealSunWattage / (RealAU * RealAU)) * (AU * AU);
        }

        public void SetHabitableLandArea()
        {
            MinimumHabitableKm = AU * MinimumHabitable;
            MaximumHabitableKm = AU * MaximumHabitable;

            HabitableLandArea = Geometry.GetCircleArea(MaximumHabitableKm) - Geometry.GetCircleArea(MinimumHabitableKm);
            HabitableLandArea *= 2;

            if (TorusDiameterInAU < (2 * MaximumHabitable))
            {
                double LargeOverlap = Geometry.GetAreaOfCircleIntersection(AU * TorusDiameterInAU, MaximumHabitableKm, MaximumHabitableKm);
                double SmallCircleArea = Geometry.GetCircleArea(MinimumHabitableKm);
                double LargeCircleArea = Geometry.GetCircleArea(MaximumHabitableKm);

                HabitableLandArea = (2 * LargeCircleArea) - LargeOverlap - (2 * SmallCircleArea);
            }
        }
    }
}
