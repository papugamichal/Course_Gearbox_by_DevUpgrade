namespace Gearbox
{
    public interface IGearbox
    {
        int GetCurrentGear();
        double GetCurrentRpm();
        int GetMaxDrive();
        Gearbox.State GetState();
        void SetCurrentGear(int v);
        void SetMaxDrive(int maxDrive);
    }
}