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

            // if reverse, netural, park => nie rob nic

            if (externalSystems.GetCurrentRpm() > characteristics[0])
            {
                if (gearbox.GetCurrentGear() == gearbox.GetMaxDrive()) // ,-- .Equals ????
                {
                    gearbox.SetCurrentGear(gearbox.GetCurrentGear() + 1);
                }
            }

            if (externalSystems.GetCurrentRpm() < characteristics[1])
            {
                if (gearbox.GetCurrentGear() == 1)
                    return;

                gearbox.SetCurrentGear(gearbox.GetCurrentGear() - 1);
            }

            // gearbox.SetGear...
        }
    }
}
