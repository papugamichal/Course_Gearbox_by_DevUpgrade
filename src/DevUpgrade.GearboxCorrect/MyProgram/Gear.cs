namespace MyProgram
{
    public class Gear
    {
        private int value;

        public Gear(int numer)
        {
            this.value = numer;
        }

        public Gear Next()
        {
            return new Gear(this.value + 1);
        }

        public Gear Previous()
        {
            return new Gear(this.value -1 );
        }

        bool Equals(Gear gear)
        {
            return this.value == gear.value;
        }
    }
}
