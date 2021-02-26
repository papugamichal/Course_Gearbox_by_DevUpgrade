using System;

namespace MyProgram
{
    public class Gear
    {
        private int Value { get; set; }

        public Gear(int numer)
        {
            this.Value = numer;
        }

        internal Gear Next()
        {
            return new Gear(this.Value + 1);
        }

        internal Gear Previous()
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

        internal int ToIntValue()
        {
            return this.Value;
        }
    }
}
