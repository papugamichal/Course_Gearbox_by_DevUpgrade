using System;

namespace Gearbox
{
    public class ExternalSystems : IExternalSystems
    {
        private double currentRpm;
        private double angularSpeed;
        private ILights lights = new Lights();

        public ExternalSystems()
        {
        }

        public double GetAngularSpeed()
        {
            return angularSpeed;
        }

        public void SetAngularSpeed(double angularSpeed)
        {
            this.angularSpeed = angularSpeed;
        }

        public double GetCurrentRpm()
        {   // sciagnij rpm z dostepnego miejsca
            return currentRpm;
        }

        public void SetCurrentRpm(double currentRpm)
        {
            this.currentRpm = currentRpm;
        }

        public ILights GetLights()
        {
            return this.lights;
        }
    }
}