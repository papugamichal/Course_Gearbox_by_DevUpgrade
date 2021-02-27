using System;
using PL.Januszsoft.CarSpecific.BMW;
using PL.Januszsoft.CarSpecific.BMW.ExternalSystems;
using PL.Januszsoft.Driver.GearCalculators;
using PL.Januszsoft.Driver.Shifter;
using PL.Januszsoft.Engine;
using PL.Januszsoft.GearboxSpecific.ZF8;

namespace MyProgram
{
    partial class Program
    {
        private static IRPMProvider rpmProvider = new N55EngineRpmProvider();
        private static IShifter shifter = new ZF8Shifter( new Gearbox());
        private static BmwGearCalculators gearCalculators = new BmwGearCalculators(new Characteristics(), shifter,  new BMWExternalSystems());

        static void Main(string[] args)
        {
            var gearDriver = new GearBoxDriver(rpmProvider, shifter, gearCalculators);
            gearDriver.Recalculate();
        }
    }
}
