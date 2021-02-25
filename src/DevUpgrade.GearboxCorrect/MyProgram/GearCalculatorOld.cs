namespace MyProgram
{
    partial class Program
    {
        class GearCalculatorOld
        {
            private double minRpm;
            private double maxRpm;
            private int maxDrive;

            public GearCalculatorOld(double minRpm, double maxRpm, int maxDrive)
            {
                this.minRpm = minRpm;
                this.maxRpm = maxRpm;
                this.maxDrive = maxDrive;
            }

            public int calculate(double currentRpm, int currentGear)
            {
                if (currentRpm > maxRpm)
                {
                    if (currentGear == maxDrive)
                    {
                        return currentGear;
                    }

                    return currentGear + 1;
                }
                if (currentRpm < minRpm)
                {
                    if (currentGear == 1)
                    {
                        return currentGear;
                    }
                    return currentGear -1;
                }
                return currentGear;
            }
        }
    }
}
