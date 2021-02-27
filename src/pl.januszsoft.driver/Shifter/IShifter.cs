using PL.Januszsoft.Driver.ValueObjects;

namespace PL.Januszsoft.Driver.Shifter
{
    public interface IShifter
    {
        void ChangeGearTo(Gear gear);
        Gear CurrentGear();
        Gear GetFirstGear();
        Gear GetMaxDrive();
    }
}