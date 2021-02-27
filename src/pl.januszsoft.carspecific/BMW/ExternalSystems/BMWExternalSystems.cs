using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Januszsoft.CarSpecific.BMW.ExternalSystems
{
    public class BMWExternalSystems : IBmwExternalSystems
    {
        private double angularSpeed = 150;
        private ILights lights = new Lights();
        private Characteristics characteristics = new Characteristics();

        public double AangularSpeedForDrifting()
        {
            return characteristics.AngularSpeedForDrifting();
        }

        public double GetAngularSpeed()
        {
            return angularSpeed;
        }

        public void SetAngularSpeed(double angularSpeed)
        {
            this.angularSpeed = angularSpeed;
        }

        public ILights GetLights()
        {
            return lights;
        }
    }
}
