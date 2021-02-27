using System;
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
        private readonly GearCalculators gearCalculators;
        private DriverState state = DriverState.Park;

        public GearDriver(
            RPMProvider rpmProvider,
            GearBoxACL gearBox,
            GearCalculators gearCalculators)
        {
            this.rpmProvider = rpmProvider;
            this.gearBox = gearBox;
            this.gearCalculators = gearCalculators;
        }

        public void Recalculate()
        {
            if (state == DriverState.Drive)
            {
                var gearCalculator = this.gearCalculators.Choose();
                var newGear = gearCalculator.CalculateGear(rpmProvider.Current(), this.gearBox.CurrentGear());
                this.gearBox.ChangeGeatTo(newGear);
            }
        }

        public void EnableDrive()
            => state = DriverState.Drive;

        public void EnableNeutral()
            => state = DriverState.Neutral;

        public void EnablePark()
            => state = DriverState.Park;

        public void EnableReversse()
            => state = DriverState.Reverse;
    }
}
