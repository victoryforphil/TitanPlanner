using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanPlanner
{
 

    static class FieldData
    {
        public static List<Step> Steps = new List<Step>();
        public static Step CurrentStep;

        public static float TicksPerMeter = 3000;
        public static float TicksPerUnit = 10;
        public static float TrimX = 100;
        public static float TrimY = 100;
        public static float FieldSizeMeters = 3.6F;
    }
}
