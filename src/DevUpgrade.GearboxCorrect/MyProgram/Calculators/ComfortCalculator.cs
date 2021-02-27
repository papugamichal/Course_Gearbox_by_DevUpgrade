using System;

namespace MyProgram
{

    public class ComfortCalculator : IGearCalculator
    {
        private readonly RPMRange optimalRange;
        private readonly GearRange gearRange;

        public ComfortCalculator(RPMRange optimalRange, GearRange gearRange)
        {
            this.optimalRange = optimalRange;
            this.gearRange = gearRange;
        }

        public Gear CalculateGear(RPM currentRpm, Gear currentGear)
        {
            if (currentRpm.IsAbove(optimalRange))
            {
                return gearRange.Next(currentGear);
            }

            if (currentRpm.IsBelow(optimalRange))
            {
                return gearRange.Previous(currentGear);
            }
            return currentGear;
        }
    }
}
