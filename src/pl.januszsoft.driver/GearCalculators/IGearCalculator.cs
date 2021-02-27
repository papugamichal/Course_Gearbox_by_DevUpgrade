using PL.Januszsoft.Driver.ValueObjects;
using PL.Januszsoft.Engine.ValueObjects;

namespace PL.Januszsoft.Driver.GearCalculators
{
    public interface IGearCalculator
    {
        Gear Calculate(RPM currentRpm, Gear currentGear);
    }
}