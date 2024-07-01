using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biosensor_GUI
{
    internal static class CommandSet
    {
        public static readonly byte START_MEAS   = 1;
        public static readonly byte STOP_MEAS    = 0;
        public static readonly byte START_CONFIG = 5;
        public static readonly byte STOP_CONFIG  = 6;

        /* Pameters for configuration */
        public static readonly byte SET_VOLTAGE = 100;  /*!< Set voltage level */
        public static readonly byte SET_DUR     = 101;  /*!< Set duration of voltage level */

    }
}
