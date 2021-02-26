using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gearbox;

namespace MyProgram.Providers
{
    public class RPMProvider
    {
        private readonly IExternalSystems externalSystems;

        public RPMProvider(IExternalSystems externalSystems)
        {
            this.externalSystems = externalSystems;
        }

        public RPM Current()
        {
            return RPM.k(this.externalSystems.GetCurrentRpm());
        }
    }
}
