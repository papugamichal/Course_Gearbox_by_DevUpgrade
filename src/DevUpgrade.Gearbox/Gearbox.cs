using System;

namespace Gearbox
{
    public class Gearbox : IGearbox
    {
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

        public void SetCurrentGear(int v)
        {
            throw new NotImplementedException();
        }
    }
}
