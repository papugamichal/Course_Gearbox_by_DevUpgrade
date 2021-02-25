using System;

namespace MyProgram
{

    public class GearCalculator
    {
        private RPM minRpm;
        private RPM maxRpm;
        private readonly RPMRange optimalRange;
        private Gear maxDrive;

        public GearCalculator(RPMRange optimalRange, Gear maxDrive)
        {
            this.optimalRange = optimalRange;
            this.maxDrive = maxDrive;
        }

        public Gear Calculate(RPM currentRpm, Gear currentGear)
        {
            if (currentRpm.IsAbove(optimalRange))
            {
                if (currentGear.Equals(maxDrive))
                {
                    return currentGear;
                }
                return currentGear.Next();
            }
            if (currentRpm.IsBelow(optimalRange))
            {
                if (currentGear.Equals(new Gear(1)))
                {
                    return currentGear.Previous();
                }
            }
            return currentGear;
        }
    }
}
