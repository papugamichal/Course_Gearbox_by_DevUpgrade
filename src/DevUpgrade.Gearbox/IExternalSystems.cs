namespace Gearbox
{
    public interface IExternalSystems
    {
        double GetAngularSpeed();
        ILights GetLights();
        double GetCurrentRpm();
        void SetCurrentRpm(double currentRpm);
        void SetAngularSpeed(double angularSpeed);
    }
}