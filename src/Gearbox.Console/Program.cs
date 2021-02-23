using System;   

namespace Gearbox.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new GearboxDriver();
            var gearbox = new Gearbox();
            var externalsytems = new ExternalSystems();

            gearbox.SetCurrentGear(3);
            gearbox.SetGeatboxCurrentParams(new object[] { 1, 3 });

            externalsytems.SetCurrentRpm(3000d);

            driver.SetGearbox(gearbox);
            driver.SetExternalSystems(externalsytems);

            driver.HandleGas(0.4);

            driver.ChangeGear(gearbox.GetCurrentGear());
        }
    }
}
