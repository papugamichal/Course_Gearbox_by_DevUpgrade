using System;
using PL.Januszsoft.Driver.Shifter;
using PL.Januszsoft.Driver.ValueObjects;

namespace PL.Januszsoft.GearboxSpecific.ZF8
{
    public class ZF8Shifter : IShifter
    {
        private readonly Gearbox gearbox;

        public ZF8Shifter(Gearbox gearbox)
        {
            this.gearbox = gearbox;
        }

        public void ChangeGearTo(Gear gear)
        {
            this.gearbox.SetCurrentGear(gear.ToIntValue());
        }

        public Gear CurrentGear()
        {
            return new Gear(this.gearbox.GetCurrentGear());
        }

        public Gear GetFirstGear()
        {
            return new Gear(1);
        }

        public Gear GetMaxDrive()
        {
            throw new NotImplementedException();
        }
    }
}
