using System;
using System.Runtime.InteropServices;
using Gearbox;
using MyProgram.ACLs;
using MyProgram.Providers;

namespace MyProgram
{
    partial class Program
    {
        private static GearBoxACL gearbox = new GearBoxACL(new Gearbox.Gearbox());
        private static RPMProvider rpmProvider = new RPMProvider(new ExternalSystems());
        private static Characteristics characteristics = new Characteristics();

        static void Main(string[] args)
        {
            var gearCalculators = new GearCalculators(gearbox, characteristics);
            var gearDriver = new GearDriver(rpmProvider, gearbox, gearCalculators);
            gearDriver.Recalculate();
        }
    }
}
