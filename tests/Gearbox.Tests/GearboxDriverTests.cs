using Moq;
using NUnit.Framework;

namespace Gearbox.Tests
{
    public class GearboxDriverTests
    {
        private GearboxDriver driver = new GearboxDriver();

        [Test]
        public void Test1()
        {
            var gearbox = new Mock<IGearbox>();
            gearbox.Setup(x => x.GetState()).Returns(Gearbox.State.S1);
            gearbox.Setup(x => x.GetCurrentGear()).Returns(1);
            
            driver.SetGearbox(gearbox.Object);
            driver.SetIfCaravan(true);

            var lights = new Mock<ILights>();
            lights.Setup(x => x.GetLightPositions()).Returns(2);

            var externalSystems = new Mock<IExternalSystems>();
            externalSystems.Setup(x => x.GetLights()).Returns(lights.Object);
            externalSystems.Setup(x => x.GetCurrentRpm()).Returns(3_000d);
            driver.SetExternalSystems(externalSystems.Object);

            driver.HandleGas(0.3d);

            Assert.That(true, Is.True);
        }
    }
}