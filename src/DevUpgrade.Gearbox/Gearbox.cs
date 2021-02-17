using System;

namespace Gearbox
{
    public class Gearbox : IGearbox
    {
        private int maxDrive;
        private object[] gearboxCurrentParams = new object[2]; // state, currentGear

        // stat 1-Drive, 2-Park, 3-Reverse, 4-Neutral

        public enum State { S1, S2, S3}

        public State GetState()
        {
            return default;
        }

        public int GetCurrentGear()
        {
            throw new NotImplementedException();
        }

        public double GetCurrentRpm()
        {
            throw new NotImplementedException();
        }

        public int GetMaxDrive()
        {
            throw new NotImplementedException();
        }

        public void SetMaxDrive(int maxDrive)
        {
            this.maxDrive = maxDrive;
        }

        public void SetCurrentGear(int currentGear)
        {
            this.gearboxCurrentParams[1] = currentGear;
        }

        public void SetGeatboxCurrentParams(Object[] gearboxCurrentParams)
        {
            if (gearboxCurrentParams[0] != this.gearboxCurrentParams[0])
            {
                // zmienil sie state
                this.gearboxCurrentParams[0] = gearboxCurrentParams[0];
                int state = (int)gearboxCurrentParams[0];

                if (state == 2)
                {
                    this.SetCurrentGear(0);
                }
                if (state == 3)
                {
                    this.SetCurrentGear(-1);
                }
                if (state == 4)
                {
                    this.SetCurrentGear(0);
                }
                SetCurrentGear((int)this.gearboxCurrentParams[1]);
            }
            else
            {
                SetCurrentGear((int)this.gearboxCurrentParams[1]);
            }
        }
    }
}
