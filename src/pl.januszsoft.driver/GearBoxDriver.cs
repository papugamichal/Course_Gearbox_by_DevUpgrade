using System;
using PL.Januszsoft.Driver.GearCalculators;
using PL.Januszsoft.Driver.Shifter;
using PL.Januszsoft.Driver.ValueObjects;
using PL.Januszsoft.Engine;

namespace MyProgram
{
    public class GearBoxDriver
    {
        enum DriverState
        {
            Reverse, Neutral, Park, Drive
        };

        private readonly IRPMProvider rpmProvider;
        private readonly IShifter shifter;
        private readonly IGearCalculators gearCalculators;

        private DriverState state = DriverState.Park;

        public GearBoxDriver(
            IRPMProvider rpmProvider,
            IShifter shifter,
            IGearCalculators gearCalculators)
        {
            this.rpmProvider = rpmProvider;
            this.shifter = shifter;
            this.gearCalculators = gearCalculators;
        }

        public void EnableDrive()
            => state = DriverState.Drive;

        public void EnableNeutral()
            => state = DriverState.Neutral;

        public void EnablePark()
            => state = DriverState.Park;

        public void EnableReversse()
            => state = DriverState.Reverse;

        public void Recalculate()
        {
            if (state == DriverState.Drive)
            {
                var newGear = SuggestGear();
                this.shifter.ChangeGearTo(newGear);
            }
        }

        private Gear SuggestGear()
        {
            var gearCalculator = this.gearCalculators.Suggest();
            var newGear = gearCalculator.Calculate(rpmProvider.Current(), this.shifter.CurrentGear());
            return newGear;
        }
    }
}
