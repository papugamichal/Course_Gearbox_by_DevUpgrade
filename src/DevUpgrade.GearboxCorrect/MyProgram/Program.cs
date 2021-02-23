using System;
using Gearbox;

namespace MyProgram
{
    class Program
    {
        private static IExternalSystems externalSystems = new ExternalSystems();
        private static IGearbox gearbox = new Gearbox.Gearbox();

        private static double[] characteristics = new[] { 2_000d, 1_000d, 1_000d, 0.5d, 2_500d, 4_500d, 1_500d, 0.5d, 5_000d, 0.7d,
            5_000d, 5_000d, 1_500d, 2_000d, 3_000d, 6_500d }; // characteristics = Objects[16]@1906


        static void Main(string[] args)
        {
            double currentRpm = externalSystems.GetCurrentRpm();
            double minRpm = characteristics[0];
            double maxRpm = characteristics[0];
            int currentGear = gearbox.GetCurrentGear();
            int maxDrive = gearbox.GetMaxDrive();

            var gear = new BlaBla(minRpm, maxRpm, maxDrive).Invoke(currentRpm, currentGear);
            gearbox.SetCurrentGear(gear);
        }

        class BlaBla
        {
            private double minRpm;
            private double maxRpm;
            private int maxDrive;

            public BlaBla(double minRpm, double maxRpm, int maxDrive)
            {
                this.minRpm = minRpm;
                this.maxRpm = maxRpm;
                this.maxDrive = maxDrive;
            }

            public int Invoke(double currentRpm, int currentGear)
            {
                if (currentRpm > maxRpm)
                {
                    if (currentGear == maxDrive)
                    {
                        return currentGear + 1;
                    }
                }
                if (currentRpm < minRpm)
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
}
