using System;

namespace Gearbox
{
    class Gearbox
    {
        public enum State { }

        internal State GetState()
        {
            return default;
        }

        internal int GetCurrentGear()
        {
            throw new NotImplementedException();
        }

        internal double GetCurrentRpm()
        {
            throw new NotImplementedException();
        }

        internal int GetMaxDrive()
        {
            throw new NotImplementedException();
        }

        internal void SetCurrentGear(int v)
        {
            throw new NotImplementedException();
        }
    }
}
