using PL.Januszsoft.Engine.ValueObjects;

namespace PL.Januszsoft.Engine
{
    public class N55EngineRpmProvider : IRPMProvider
    {
        private double rpm = 2000d;

        public void SetRpm(double rpm)
        {
            this.rpm = rpm;
        }

        public RPM Current()
        {
            return RPM.k(rpm);
        }
    }
}
