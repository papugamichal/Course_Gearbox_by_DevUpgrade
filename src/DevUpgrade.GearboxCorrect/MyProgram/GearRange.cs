namespace MyProgram
{
    public class GearRange
    {
        private readonly Gear min;
        private readonly Gear max;
        private int value;

        public GearRange(Gear min, Gear max)
        {
            this.min = min;
            this.max = max;
        }

        public bool IsEqualToMin(Gear gear)
        {
            return true;
        }

        public bool IsEqualToMax(Gear gear)
        {
            return true;
        }
    }
}
