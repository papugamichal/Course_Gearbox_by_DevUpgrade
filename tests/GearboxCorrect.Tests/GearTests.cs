using System;
using Moq;
using MyProgram;
using NUnit.Framework;

namespace Gearbox.Tests
{
    public class GearTests
    {
        [Test]
        public void CanNotHaveNegativeRPMs()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Gear(-2));
        }

        [Test]
        public void shouldCreateNextGear()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Gear(3), Is.EqualTo(new Gear(2).Next()));
                Assert.That(new Gear(23), Is.EqualTo(new Gear(22).Next()));
            });
        }

        [Test]
        public void shouldCreatePreviousGear()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Gear(1), Is.EqualTo(new Gear(2).Previous()));
                Assert.That(new Gear(4), Is.EqualTo(new Gear(5).Previous()));
            });
        }
    }
}