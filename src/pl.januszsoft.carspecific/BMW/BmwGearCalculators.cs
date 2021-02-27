using System;
using PL.Januszsoft.CarSpecific.BMW.ExternalSystems;
using PL.Januszsoft.CarSpecific.BMW.GearCalculators;
using PL.Januszsoft.CarSpecific.CommonCar.GearCalculators;
using PL.Januszsoft.Driver.GearCalculators;
using PL.Januszsoft.Driver.Shifter;
using PL.Januszsoft.Driver.ValueObjects;

namespace PL.Januszsoft.CarSpecific.BMW
{
    public class BmwGearCalculators : IGearCalculators
    {
        enum DriveMode
        {
            Eco, Comfort, Sport
        };

        private DriveMode driveMode = DriveMode.Comfort;
        private readonly Characteristics characteristics;
        private readonly IShifter shifter;
        private readonly IBmwExternalSystems bmwExternalSystems;
        private bool mDynamics;
        private bool kickedDown;
        private AggresiveLevel aggresiveLevel = BMW.AggresiveLevel.First;
        
        public BmwGearCalculators(
            Characteristics characteristics, 
            IShifter shifter, 
            IBmwExternalSystems bmwExternalSystems)
        {
            this.characteristics = characteristics;
            this.shifter = shifter;
            this.bmwExternalSystems = bmwExternalSystems;
        }
        public IGearCalculator Suggest()
        {
            if (IsDrifting())
            {
                return new MaintainGear();
            }

            if (driveMode == DriveMode.Eco)
                return new OptimalRange(characteristics.OptimalEcoRpmRange(), getGearRange());

            if (driveMode == DriveMode.Comfort)
            {
                if (kickedDown)
                    return new Kickdown(this.aggresiveLevel.Modify(characteristics.OptimalComfortRpmRange()), getGearRange());
                else
                    return new OptimalRange(this.aggresiveLevel.Modify(characteristics.OptimalComfortRpmRange()), getGearRange());
            }

            if (driveMode == DriveMode.Sport)
            {
                if (kickedDown)
                    return new DoubleKickdown(this.aggresiveLevel.Modify(characteristics.OptimalSportRpmRange()), getGearRange());
                else
                    return new OptimalRange(this.aggresiveLevel.Modify(characteristics.OptimalSportRpmRange()), getGearRange());
            }

            return new OptimalRange(this.aggresiveLevel.Modify(characteristics.OptimalComfortRpmRange()), getGearRange());

            GearRange getGearRange()
                => new GearRange(this.shifter.GetFirstGear(), this.shifter.GetMaxDrive());
        }

        private bool IsDrifting()
        {
            return mDynamics && this.bmwExternalSystems.GetAngularSpeed() > this.characteristics.AngularSpeedForDrifting();
        }

        public void EnableEco()
            => driveMode = DriveMode.Eco;

        public void EnableComfort()
            => driveMode = DriveMode.Comfort;

        public void EnableSport() 
            => driveMode = DriveMode.Sport;

        void EnableMDynamics()
            => this.mDynamics = true;

        void DisableMDynamics()
            => this.mDynamics = false;

        void AggresiveLevel(AggresiveLevel level)
            => this.aggresiveLevel = level;

        void KickdownEnabled()
            => this.kickedDown = true;

        void KickdownDisabled()
            => this.kickedDown = false;
    }
}