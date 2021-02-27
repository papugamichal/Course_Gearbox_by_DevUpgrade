using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Januszsoft.Driver.GearCalculators
{
    public interface IGearCalculators
    {
        IGearCalculator Suggest();
    }
}
