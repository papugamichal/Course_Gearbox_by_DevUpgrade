using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PL.Januszsoft.Engine.ValueObjects
{
    public class RPM : IEqualityComparer<RPM>
    {
        private double value;

        public RPM(long rpm)
        {
            if (rpm < 0) { 
                throw new ArgumentOutOfRangeException("Negative RPM: " + rpm);
            };
            value = rpm;
        }

        public static RPM rpm(long rpm)
        {
            return new RPM(rpm);
        }

        public bool IsAbove(RPMRange optimalRange)
        {
            return optimalRange.StartGreaterThan(this);
        }

        public bool IsBelow(RPMRange optimalRange)
        {
            return optimalRange.EndSmallerThan(this);
        }

        public static RPM k(double k)
        {
            return RPM.rpm((long)(k * 1000));
        }

        public bool GreaterThan(RPM other)
        {
            return this.value > other.value;
        }

        public bool LowerThan(RPM other)
        {
            return this.value < other.value;
        }

        public bool Equals(RPM x, RPM y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] RPM obj)
        {
            throw new NotImplementedException();
        }

        // implement IEquatable<>
    }
}
