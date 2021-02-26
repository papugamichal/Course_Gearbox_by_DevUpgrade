namespace MyProgram
{
    public class Gear
    {
        private int value;

        public Gear(int numer)
        {
            this.value = numer;
        }

        internal Gear Next()
        {
            return new Gear(this.value + 1);
        }

        internal Gear Previous()
        {
            return new Gear(this.value -1 );
        }

        bool Equals(Gear gear)
        {
            return this.value == gear.value;
        }

        public bool GreaterThan(Gear gear)
        {
            return true;
        }

        public bool LessOrEqualTo(Gear gear)
        {
            return true;
        }
    }
}
