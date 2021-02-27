using System;
using PL.Januszsoft.Driver.GearCalculators;
using PL.Januszsoft.Driver.ValueObjects;
using PL.Januszsoft.Engine.ValueObjects;

namespace PL.Januszsoft.CarSpecific.CommonCar.GearCalculators
{
    public class OptimalRange : IGearCalculator
    {
        private readonly RPMRange optimalRpmRange;
        private readonly GearRange gearRange;

        public OptimalRange(RPMRange optimalRange, GearRange gearRange)
        {
            this.optimalRpmRange = optimalRange;
            this.gearRange = gearRange;
        }

        public Gear Calculate(RPM currentRpm, Gear currentGear)
        {
            var gear = CalculateGear(currentRpm, currentGear);
            return this.gearRange.Trim(gear);
        }

        private Gear CalculateGear(RPM currentRpm, Gear currentGear)
        {
            if (currentRpm.IsBelow(optimalRpmRange))
            {
                return currentGear.Previous();
            }
            if (currentRpm.IsAbove(optimalRpmRange))
            {
                return currentGear.Next();
            }
            return currentGear;
        }
    }
}
