using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gearbox;

namespace MyProgram.ACLs
{
    public class GearBoxACL
    {
        private readonly IGearbox gearbox;

        public GearBoxACL(IGearbox gearbox)
        {
            this.gearbox = gearbox;
        }

        internal Gear CurrentGear()
        {
            return new Gear(this.gearbox.GetCurrentGear());
        }

        internal void ChangeGeatTo(Gear newGear)
        {
            this.gearbox.SetCurrentGear(newGear.ToIntValue());
        }

        public Gear GetFirstGear()
        {
            return new Gear(1);
        }

        public Gear GetMaxDrive()
        {
            return new Gear(this.gearbox.GetMaxDrive());
        }
    }
}
