using System;
using Moq;
using MyProgram;
using NUnit.Framework;

namespace Gearbox.Tests
{
    public class RPMTests
    {
        [Test]
        public void CanNotHaveNegativeRPMs()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => RPM.rpm(-2));
        }

        [Test]
        public void KilosShouldBeEqualToUnits()
        {
            Assert.Multiple(() =>
            {
                Assert.That(RPM.k(2), Is.EqualTo(new RPM(2000)));
                Assert.That(RPM.k(2.5), Is.EqualTo(new RPM(2500)));
                Assert.That(RPM.k(1.7), Is.EqualTo(new RPM(1700)));
                Assert.That(RPM.k(0.5), Is.EqualTo(new RPM(500)));
            });
        }
    }
}