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

            if (threshold < 0)
            {
                throw new IllegalStateException();
            }

            if (threshold > 100)
            {
                throw new IllegalStateException();
            }

            int currentGear = this.gearbox.GetCurrentGear();
            if (currentGear == 0)
            { // mozna dopisac
                throw new IllegalStateException();
            }

            double currentRpm = this.externalSystems.GetCurrentRpm();

            switch (gearBoxDriverMode)
            {
                case 1:
                    {
                        if (ifCaravan && 
                            externalSystems.GetLights().GetLightPositions() != null && 
                            externalSystems.GetLights().GetLightPositions() >= 7)
                        {
                            if (currentGear != 1)
                            {
                                this.gearbox.SetCurrentGear(currentGear - 1);
                            }
                        }

                        if (ifCaravan && 
                            externalSystems.GetLights().GetLightPositions() != null &&
                            externalSystems.GetLights().GetLightPositions() <= 3)
                        {
                            if (currentGear != 1)
                            {
                                this.gearbox.SetCurrentGear(currentGear - 1);
                            }
                        }

                        if (isMDynamicsMode && externalSystems.GetAngularSpeed() > 50)
                        {
                            break;
                        }

                        if (currentGear > characteristics[0] && aggresiveMode == 1)
                        {
                            if (!currentGear.Equals(this.gearbox.GetMaxDrive()))
                            {
                                this.gearbox.SetCurrentGear(currentGear + 1);
                            }
                        }
                        else if (currentGear > characteristics[0] * 130 / 100 && aggresiveMode == 2)
                        {
                            if (!currentGear.Equals(this.gearbox.GetMaxDrive()))
                            {
                                this.gearbox.SetCurrentGear(currentGear + 1);
                            }
                        }
                        else if (currentGear > characteristics[0] * 130 / 100 && aggresiveMode == 3)
                        {
                            if (!currentGear.Equals(this.gearbox.GetMaxDrive()))
                            {
                                this.gearbox.SetCurrentGear(currentGear + 1);
                            }
                        }
                        else if(currentGear < characteristics[1])
                        {
                            if (currentGear != 1)
                            {
                                this.gearbox.SetCurrentGear(currentGear - 1);
                            }
                        }
                        break;
                    }

                case 2:
                    {
                        if (ifCaravan && 
                            externalSystems.GetLights().GetLightPositions() != null && 
                            externalSystems.GetLights().GetLightPositions() >= 7)
                        {
                            if (currentGear != 1)
                            {
                                this.gearbox.SetCurrentGear(currentGear - 1);
                            }
                        }

                        if (ifCaravan && 
                            externalSystems.GetLights().GetLightPositions() != null && 
                            externalSystems.GetLights().GetLightPositions() <= 3)
                        {
                            if (currentGear != 1)
                            {
                                this.gearbox.SetCurrentGear(currentGear - 1);
                            }
                        }

                        if (isMDynamicsMode && externalSystems.GetAngularSpeed() > 50)
                        {
                            break;
                        }

                        if (currentGear > characteristics[2]) // czy redukowac bo za male obroty
                        {
                            if (currentGear != 1)
                            {
                                this.gearbox.SetCurrentGear(currentGear - 1);
                                break;
                            }
                        }

                        // czy potrzeba nastepny bieg
                        if (threshold < characteristics[3] && aggresiveMode == 1)
                        {
                            if (currentRpm > characteristics[4])
                            {
                                if (!currentGear.Equals(this.gearbox.GetMaxDrive()))
                                {
                                    this.gearbox.SetCurrentGear(currentGear + 1);
                                }
                            }
                        }
                        else if (threshold < characteristics[3] && aggresiveMode == 2)
                        {
                            if (currentRpm > characteristics[4] * 130 / 100)
                            {
                                if (!currentGear.Equals(this.gearbox.GetMaxDrive()))
                                {
                                    this.gearbox.SetCurrentGear(currentGear + 1);
                                }
                            }
                        }
                        else if (threshold < characteristics[3] && aggresiveMode == 3)
                        {
                            if (currentRpm > characteristics[4] * 130 / 100)
                            {
                                if (!currentGear.Equals(this.gearbox.GetMaxDrive()))
                                {
                                    this.gearbox.SetCurrentGear(currentGear + 1);
                                    soundModule.MakeSound(40);
                                }
                            }
                            else
                            { // kickdown
                                if (currentRpm < characteristics[5] * 130 / 100)
                                {
                                    if (currentGear != 1)
                                    {
                                        this.gearbox.SetCurrentGear(currentGear - 1);
                                    }
                                }
                            }
                        }
                        break;
                    }

                case 3:
                    {
                        if (ifCaravan && 
                            externalSystems.GetLights().GetLightPositions() != null && 
                            externalSystems.GetLights().GetLightPositions() >= 7)
                        {
                            if (currentGear != 1)
                            {
                                this.gearbox.SetCurrentGear(currentGear - 1);
                            }
                        }

                        if (ifCaravan && 
                            externalSystems.GetLights().GetLightPositions() != null && 
                            externalSystems.GetLights().GetLightPositions() <= 3)
                        {
                            if (currentGear != 1)
                            {
                                this.gearbox.SetCurrentGear(currentGear - 1);
                            }
                        }

                        if (currentRpm < characteristics[6]) // czy zbyt obroty i trzeba zredukowac
                        {
                            if (currentGear != 1)
                            {
                                this.gearbox.SetCurrentGear(currentGear - 1);
                                break;
                            }
                        }

                        // czy potrzeba nastepny bieg?

                        if (threshold < characteristics[7] && aggresiveMode == 1) // przyspieszamy lagodnia
                        {
                            if (currentRpm > characteristics[8])
                            {
                                if (currentGear != this.gearbox.GetMaxDrive())
                                {
                                    this.gearbox.SetCurrentGear(currentGear + 1);
                                }
                            }
                        }
                        else if (threshold < characteristics[7] && aggresiveMode == 2)
                        {
                            if (currentRpm > characteristics[8] * 130 / 100)
                            {
                                if (currentGear != this.gearbox.GetMaxDrive())
                                {
                                    this.gearbox.SetCurrentGear(currentGear + 1);
                                }
                            }
                        }
                        else if (threshold < characteristics[7] && aggresiveMode == 3)
                        {
                            if (currentRpm > characteristics[8] * 130 / 100)
                            {
                                if (!currentGear.Equals(this.gearbox.GetMaxDrive()))
                                {
                                    this.gearbox.SetCurrentGear(currentGear + 1);
                                    soundModule.MakeSound(40);
                                }
                            }
                        }
                        else if (threshold < characteristics[9]) // lekki kickdown
                        {
                            if (currentRpm > characteristics[10])
                            {
                                if (currentGear != 1)
                                {
                                    this.gearbox.SetCurrentGear(currentGear - 1);
                                }
                            }
                        }
                        else // mocny kickdown
                        {
                            if (currentRpm > characteristics[11]) // nie sa zbyt wysokie
                            {
                                if (currentGear != 1)
                                {
                                    this.gearbox.SetCurrentGear(currentGear - 1);
                                    if (this.gearbox.GetCurrentGear() != 1)
                                    {
                                        this.gearbox.SetCurrentGear(this.gearbox.GetCurrentGear() - 1);
                                    }
                                }
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
