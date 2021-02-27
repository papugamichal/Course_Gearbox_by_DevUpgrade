using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProgram;
using NUnit.Framework;

namespace GearboxCorrect.Tests
{
    class GearCalculatorTests
    {
        private readonly ComfortCalculator sut;

        public GearCalculatorTests()
        {
            this.sut = new GearCalculator(RPM.k(2), RPM.k(3), 8);
        }

        public void shouldShiftUpWhenAboveMaxRpm()
        {
            int nextGear = this.sut.Calculate(RPM.rpm(3300), 6);

            Assert.That(nextGear, Is.EqualTo(7));
        }
    }
}
