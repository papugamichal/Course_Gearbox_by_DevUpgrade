﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gearbox
{
    public class Lights
    {
        private int position;

        internal int GetLightPositions()
        {
            // null - brak opcji
            // 1-3 - w dol
            // 7-10 - w gore
            return position;
        }
    }
}
