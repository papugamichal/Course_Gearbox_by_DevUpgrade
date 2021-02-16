namespace Gearbox
{
    public interface IExternalSystems
    {
        int GetAngularSpeed();
        ILights GetLights();
        double GetCurrentRpm();
    }
}