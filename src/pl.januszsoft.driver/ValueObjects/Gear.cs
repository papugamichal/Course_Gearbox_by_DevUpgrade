using System;

namespace PL.Januszsoft.Driver.ValueObjects
{
    public class Gear
    {
        private int Value { get; set; }

        public Gear(int numer)
        {
            this.Value = numer;
        }

        public Gear Next()
        {
            return new Gear(this.Value + 1);
        }

        public Gear Previous()
        {
            return new Gear(this.Value -1 );
        }

        bool Equals(Gear gear)
        {
            return this.Value == gear.Value;
        }

        public bool GreaterThan(Gear gear)
        {
            return true;
        }

        public bool LessOrEqualTo(Gear gear)
        {
            return true;
        }

        public int ToIntValue()
        {
            return this.Value;
        }
    }
}
