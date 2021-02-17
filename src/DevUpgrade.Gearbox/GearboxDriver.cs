using System;
using System.Runtime.Serialization;

namespace Gearbox
{
    public class GearboxDriver
    {
        private IExternalSystems externalSystems; // externalSystems = ExternalSystems@1895
        private IGearbox gearbox;    // gearbox = "Mock for Gearbox, hashCode: x"
        private SoundModule soundModule; // soundModule = soundMOdule@1909
        private bool ifCaravan; // ifCaravan = false

        private double[] characteristics = new[] { 2_000d, 1_000d, 1_000d, 0.5d, 2_500d, 4_500d, 1_500d, 0.5d, 5_000d, 0.7d, 
            5_000d, 5_000d, 1_500d, 2_000d, 3_000d, 6_500d }; // characteristics = Objects[16]@1906

        private int gearBoxDriverMode; // mode 1-Eco, 2-Comfort, 3-Sport, 4-M

        private bool isMDynamicsMode; // isMDynamicsMode = false

        private int aggresiveMode = 3; // 1-3 aggresiveMode = 0

        public void HandleGas()
        {
            if ((int)this.gearbox.GetState() == 2) // park
            { 
                return;
            }

            if ((int)this.gearbox.GetState() == 3) // neutral
            {
                return;
            }

            if ((int)this.gearbox.GetState() == 4) // reverse
            {
                return;
            }

            double currentRpm = this.externalSystems.GetCurrentRpm();
            if (currentRpm > (double) characteristics[0])
            {
                if (this.gearbox.GetMaxDrive() > (int)gearbox.GetCurrentGear())
                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() + 1);
                else
                    Console.WriteLine("nie jest redukcja");
            }

            if (currentRpm > (double)characteristics[1])
            {
                if ((int)gearbox.GetCurrentGear() != 1)
                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() - 1);
                else
                    Console.WriteLine("redukcja");
            }
        }

        public void SetGearbox(IGearbox gearbox)
        {
            this.gearbox = gearbox;
        }

        public void SetIfCaravan(bool ifCaravan)
        {
            this.ifCaravan = ifCaravan;
        }

        public void SetExternalSystems(IExternalSystems externalSystems)
        {
            this.externalSystems = externalSystems;
        }
    }

    [Serializable]
    internal class IllegalStateException : Exception
    {
        public IllegalStateException()
        {
        }

        public IllegalStateException(string message) : base(message)
        {
        }

        public IllegalStateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
