using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biosensor_GUI
{
    internal static class CommandSet
    {
        public static readonly byte START_MEAS_CONST = 1;
        public static readonly byte START_MEAS_CV    = 2;
        public static readonly byte STOP_MEAS        = 0;
        public static readonly byte START_CONFIG     = 5;   /*!< Enter parameter configuration */
        public static readonly byte STOP_CONFIG      = 6;

        /* Parameters for configuration */
        public static readonly byte SET_VOLTAGE_STEP = 100;  /*!< Set voltage level for const excitation */
        public static readonly byte SET_VOLTAGE1_CV  = 101;  /*!< Set voltage level 1 for CV excitation */
        public static readonly byte SET_VOLTAGE2_CV  = 102;  /*!< Set voltage level 2 for CV excitation */
        public static readonly byte SET_SLOPE_TIME_CV  = 103; /*!< Set slope duration for CV excitation */

    }
}
