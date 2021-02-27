using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Januszsoft.CarSpecific.BMW.ExternalSystems
{
    public interface IBmwExternalSystems
    {
        double GetAngularSpeed();
        ILights GetLights();
        void SetAngularSpeed(double angularSpeed);
    }
}
