using System;

namespace Gearbox
{
    public class ExternalSystems : IExternalSystems
    {
        public int GetAngularSpeed()
        {
            throw new NotImplementedException();
        }

        public double GetCurrentRpm()
        {
            throw new NotImplementedException();
        }

        public ILights GetLights()
        {
            throw new NotImplementedException();
        }
    }
}