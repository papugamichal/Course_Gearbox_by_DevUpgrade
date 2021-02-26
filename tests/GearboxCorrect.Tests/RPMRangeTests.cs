using System;
using Moq;
using MyProgram;
using NUnit.Framework;

namespace Gearbox.Tests
{
    public class RPMRangeTests
    {
        [Test]
        public void ShouldCreateInvalidrange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RPMRange(new RPM(6), new RPM(2)));
        }

        [Test]
        public void ShouldCreateValidrange()
        {
            Assert.DoesNotThrow(() => new RPMRange(new RPM(2), new RPM(3)));
        }
    }
}