using System;

namespace Gearbox
{
    internal class ExternalSystems
    {
        internal int GetAngularSpeed()
        {
            throw new NotImplementedException();
        }

        internal Lights GetLights()
        {
            return new Lights();
        }
    }
}