﻿using System;
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

        private DriveMode mode = DriveMode.Comfort;
        
        enum DriveMode { Eco, Comfort, Sport }

        int aggresiveMode = 1; // 1 - 2 - 3

        public void HandleGas(double threshold)
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

            switch (mode)
            {
                case DriveMode.Eco:
                    {

                        if (currentRpm > (double)characteristics[0])
                        {
                            if (this.gearbox.GetMaxDrive() > (int)gearbox.GetCurrentGear())
                                this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() + 1);
                            else
                                Console.WriteLine("nie jest redukcja");
                        }

                        if (currentRpm > (double)characteristics[0])
                        {
                            if ((int)gearbox.GetCurrentGear() != 1)
                                this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() - 1);
                            else
                                Console.WriteLine("redukcja");
                        }
                        break;
                    }

                case DriveMode.Comfort:
                    {
                        if (threshold <= 0.5)
                        {
                            if (currentRpm > (double)characteristics[2] && aggresiveMode == 1)
                            {
                                if (this.gearbox.GetMaxDrive() > (int)gearbox.GetCurrentGear())
                                {
                                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() + 1);
                                    Console.WriteLine("nie jest redukcja");
                                }
                            }
                            else if (currentRpm > (double)characteristics[2] * 120 / 100 && aggresiveMode == 1)
                            {
                                if (this.gearbox.GetMaxDrive() > (int)gearbox.GetCurrentGear())
                                {
                                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() + 1);
                                    Console.WriteLine("nie jest redukcja");
                                }
                            }
                            else if (currentRpm > (double)characteristics[2] * 130 / 100 && aggresiveMode == 1)
                            {
                                if (this.gearbox.GetMaxDrive() > (int)gearbox.GetCurrentGear())
                                {
                                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() + 1);
                                    Console.WriteLine("nie jest redukcja");
                                }
                            }
                            else if (currentRpm > (double)characteristics[3])
                            {
                                if ((int)gearbox.GetCurrentGear() != 1)
                                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() - 1);
                                else
                                    Console.WriteLine("redukcja");
                            }
                            break;
                        }
                        else
                        {
                            if ((int)gearbox.GetCurrentGear() != 1)
                                this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() - 1);
                            else
                                Console.WriteLine("redukcja");
                        }
                        break;
                    }

                case DriveMode.Sport:
                    {
                        if (threshold <= 0.5)
                        {
                            if (currentRpm > (double)characteristics[6] && aggresiveMode == 1)
                            {
                                if (this.gearbox.GetMaxDrive() > (int)gearbox.GetCurrentGear())
                                {
                                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() + 1);
                                    Console.WriteLine("nie jest redukcja");
                                }
                            }
                            else if (currentRpm > (double)characteristics[6] * 120 / 100 && aggresiveMode == 1)
                            {
                                if (this.gearbox.GetMaxDrive() > (int)gearbox.GetCurrentGear())
                                {
                                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() + 1);
                                    Console.WriteLine("nie jest redukcja");
                                }
                            }
                            else if (currentRpm > (double)characteristics[6] * 130 / 100 && aggresiveMode == 1)
                            {
                                if (this.gearbox.GetMaxDrive() > (int)gearbox.GetCurrentGear())
                                {
                                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() + 1);
                                    Console.WriteLine("nie jest redukcja");
                                }
                            }
                            else if (currentRpm > (double)characteristics[7])
                            {
                                if ((int)gearbox.GetCurrentGear() != 1)
                                    this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() - 1);
                                else
                                    Console.WriteLine("redukcja");
                            }
                            break;
                        }
                        else if (threshold > 0.5)
                        {
                            if ((int)gearbox.GetCurrentGear() != 1)
                            {
                                this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() - 1);
                                Console.WriteLine("redukcja");
                            }
                        }
                        else if (threshold > 0.7)
                        {
                            if ((int)gearbox.GetCurrentGear() != 1)
                            {
                                this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() - 1);
                                Console.WriteLine("redukcja");
                            }
                            if ((int)gearbox.GetCurrentGear() != 1)
                            {
                                this.gearbox.SetCurrentGear((int)gearbox.GetCurrentGear() - 1);
                                Console.WriteLine("redukcja");
                            }
                        }
                        break;
                    }
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

        public void ChangeGear(int gear)
        {
            if (gearbox.GetMaxDrive() < gear)
            {
                return;
            }

            if (gear < 1)
            {
                return;
            }

            gearbox.SetCurrentGear(gear);
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
