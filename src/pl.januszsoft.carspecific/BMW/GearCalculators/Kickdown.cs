using System;
using PL.Januszsoft.Driver.GearCalculators;
using PL.Januszsoft.Driver.ValueObjects;
using PL.Januszsoft.Engine.ValueObjects;

namespace PL.Januszsoft.CarSpecific.BMW.GearCalculators
{
    public class Kickdown : IGearCalculator
    {
        private readonly RPMRange optimalRange;
        private readonly GearRange gearRange;

        public Kickdown(RPMRange optimalRange, GearRange gearRange)
        {
            this.optimalRange = optimalRange;
            this.gearRange = gearRange;
        }

        public Gear Calculate(RPM currentRpm, Gear currentGear)
        {
            var gear = CalculateGear(currentRpm, currentGear);
            return this.gearRange.Trim(gear);
        }

        private Gear CalculateGear(RPM currentRpm, Gear currentGear)
        {
            if (currentRpm.IsAbove(optimalRange))
            {
                return currentGear.Next();
            }

            if (currentRpm.IsBelow(optimalRange))
            {
                return currentGear.Previous();
            }
            return currentGear;
        }
    }
}
