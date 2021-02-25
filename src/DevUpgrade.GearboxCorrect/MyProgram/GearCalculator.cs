using System;

namespace MyProgram
{
    public class GearCalculator
    {
        private RPM minRpm;
        private RPM maxRpm;
        private int maxDrive;

        public GearCalculator(RPM minRpm, RPM maxRpm, int maxDrive)
        {
            this.minRpm = minRpm;
            this.maxRpm = maxRpm;
            this.maxDrive = maxDrive;
        }

        public int Calculate(RPM currentRpm, int currentGear)
        {
            if (currentRpm.GreaterThan(maxRpm))
            {
                if (currentGear == maxDrive)
                {
                    return currentGear;
                }
            }
            if (currentRpm.LowerThan(minRpm))
            {
                if (currentGear == 1)
                {
                    return currentGear - 1;
                }
            }
            return currentGear;
        }
    }
}
