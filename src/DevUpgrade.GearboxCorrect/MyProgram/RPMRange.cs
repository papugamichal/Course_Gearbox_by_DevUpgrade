﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MyProgram
{
    public class RPMRange
    {
        private readonly RPM min;
        private readonly RPM max;

        public RPMRange(RPM min, RPM max)
        {
            this.min = min;
            this.max = max;
        }

        public bool IsAbove(RPM rpm)
        {
            return rpm.GreaterThan(max);
        }

        public bool IsBelow(RPM rpm)
        {
            return rpm.LowerThan(min);
        }

        internal bool StartGreaterThan(RPM rPM)
        {
            return min.IsAbove(rPM);
        }

        internal bool EndSmallerThan(RPM rPM)
        {
            return max.LowerThan(rPM);
        }
    }
}
