using System;

namespace PL.Januszsoft.Driver.ValueObjects
{
    public class GearRange
    {
        private readonly Gear min;
        private readonly Gear maxGear;

        public GearRange(Gear min, Gear max)
        {
            this.min = min;
            this.maxGear = max;
        }

        public bool IsEqualToMin(Gear gear)
        {
            return true;
        }

        public bool IsEqualToMax(Gear gear)
        {
            return true;
        }

        internal Gear Next(Gear gear)
        {
            return Trim(gear.Next());
        }

        internal Gear Previous(Gear gear)
        {
            return Trim(gear.Previous());
        }
        public Gear Trim(Gear gear)
        {
            if (gear.GreaterThan(maxGear))
            {
                return maxGear;
            }

            if (gear.LessOrEqualTo(min))
            {
                return min;
            }

            return gear;
        }
    }
}
