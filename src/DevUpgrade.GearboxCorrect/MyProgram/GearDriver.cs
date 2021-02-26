using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProgram.ACLs;
using MyProgram.Providers;

namespace MyProgram
{
    public class GearDriver
    {
        enum DriverState
        {
            Reverse, Neutral, Park, Drive
        };

        private readonly RPMProvider rpmProvider;
        private readonly GearBoxACL gearBox;
        private readonly GearCalculator gearCalculator;
        private DriverState state = DriverState.Park;

        public GearDriver(
            RPMProvider rpmProvider, 
            GearBoxACL gearBox, 
            GearCalculator gearCalculator)
        {
            this.rpmProvider = rpmProvider;
            this.gearBox = gearBox;
            this.gearCalculator = gearCalculator;
        }

        public void Recalculate()
        {
            if (state == DriverState.Drive)
            {
                var newGear = this.gearCalculator.CalculateGear(rpmProvider.Current(), this.gearBox.CurrentGear());
                this.gearBox.ChangeGeatTo(newGear);
            }
        }

    }
}
