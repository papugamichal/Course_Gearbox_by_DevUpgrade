using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Januszsoft.CarSpecific.BMW.ExternalSystems
{
    public interface ILights
    {
        int GetLightsPosition();
    }

    public class Lights : ILights
    {
        int position;

        /**
         * null - brak opcji w samochodzie
         * 1-3 - w dół
         * 7-10 - w górę
         * @return
         */
        public int GetLightsPosition()
        {
            return position;
        }
    }
}
