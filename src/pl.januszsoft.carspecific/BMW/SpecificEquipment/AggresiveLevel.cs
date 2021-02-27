using PL.Januszsoft.Driver.ValueObjects;
using PL.Januszsoft.Engine.ValueObjects;

namespace PL.Januszsoft.CarSpecific.BMW
{
    internal class AggresiveLevel
    {
        private readonly double multiplier;

        private AggresiveLevel(double multiplier)
        {
            this.multiplier = multiplier;
        }

        public static AggresiveLevel First
            => new AggresiveLevel(1.0);

        public static AggresiveLevel Second
            => new AggresiveLevel(1.75);

        public static AggresiveLevel Third
            => new AggresiveLevel(2.5);

        public RPMRange Modify(RPMRange rpmRange)
        {
            return rpmRange;
        }
    }
}