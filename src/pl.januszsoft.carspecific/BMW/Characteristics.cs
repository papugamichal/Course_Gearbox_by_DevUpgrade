﻿using System;
using PL.Januszsoft.Engine.ValueObjects;

namespace PL.Januszsoft.CarSpecific.BMW 
{
    public class Characteristics
    {
        private static double[] characteristics = new[] { 2_000d, 1_000d, 1_000d, 0.5d, 2_500d, 4_500d, 1_500d, 0.5d, 5_000d, 0.7d,
            5_000d, 5_000d, 1_500d, 2_000d, 3_000d, 6_500d, 40d };

        public RPMRange OptimalComfortRpmRange()
        {
            return new RPMRange(RPM.k(characteristics[1]), RPM.k(characteristics[4]));
        }

        internal RPMRange OptimalEcoRpmRange()
        {
            return new RPMRange(RPM.k(characteristics[1]), RPM.k(characteristics[4]));
        }

        internal double AngularSpeedForDrifting()
        {
            return (Double)characteristics[16];
        }

        internal RPMRange OptimalSportRpmRange()
        {
            return new RPMRange(RPM.k(characteristics[14]), RPM.k(characteristics[15]));
        }
    }
}
