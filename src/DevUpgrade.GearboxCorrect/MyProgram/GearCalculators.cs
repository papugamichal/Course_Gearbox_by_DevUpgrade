using MyProgram.ACLs;
using MyProgram.Providers;

namespace MyProgram
{
    public class GearCalculators
    {
        enum DriveMode
        {
            Eco, Comfort, Sport
        };

        private readonly GearBoxACL gearBox;
        private readonly Characteristics characteristics;
        private DriveMode driveMode = DriveMode.Comfort;

        public GearCalculators(GearBoxACL gearBox, Characteristics characteristics)
        {
            this.gearBox = gearBox;
            this.characteristics = characteristics;
        }

        public void EnableEco()
            => driveMode = DriveMode.Eco;

        public void EnableComfort()
            => driveMode = DriveMode.Comfort;

        public void EnableSport() 
            => driveMode = DriveMode.Sport;

        public IGearCalculator Choose()
        {
            return driveMode switch
            {
                DriveMode.Eco => new EcoCalculator(characteristics.OptimalEcoRpmRange(), new GearRange(gearBox.GetFirstGear(), gearBox.GetMaxDrive())),
                DriveMode.Comfort => new ComfortCalculator(characteristics.OptimalComfortRpmRange(), new GearRange(gearBox.GetFirstGear(), gearBox.GetMaxDrive())),
                DriveMode.Sport => new SportCalculator(characteristics.OptimalSportRpmRange(), new GearRange(gearBox.GetFirstGear(), gearBox.GetMaxDrive())),
                _ => new ComfortCalculator(characteristics.OptimalComfortRpmRange(), new GearRange(gearBox.GetFirstGear(), gearBox.GetMaxDrive()))
            };
        }
    }
}