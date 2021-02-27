
using System;
using PL.Januszsoft.Driver.GearCalculators;
using PL.Januszsoft.Driver.ValueObjects;
using PL.Januszsoft.Engine.ValueObjects;

namespace PL.Januszsoft.CarSpecific.CommonCar.GearCalculators
{
    public class MaintainGear : IGearCalculator
    {
        public MaintainGear()
        {
        }

        public Gear Calculate(RPM currentRpm, Gear currentGear)
        {
            return currentGear;
        }
    }
}
