using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanPlanner
{
 
    public class Hardware
    {
        public string Name;
        public string Type;
    }

    public struct MotorSetting
    {
        public string MotorName;
        public int Setting;
    }
    public class DriveMotorConfig
    {
        public string Direction;
        public List<MotorSetting> Settings = new List<MotorSetting>();
    }
    static class FieldData
    {
        public static List<Step> Steps = new List<Step>();
        public static Step CurrentStep;

        public static List<Hardware> hardware = new List<Hardware>();
        public static List<DriveMotorConfig> DriveConfigs = new List<DriveMotorConfig>();

        public static float TicksPerMeter = 3000;
        public static float TicksPerUnit = 10;
        public static float TrimX = 100;
        public static float TrimY = 100;
        public static float FieldSizeMeters = 3.6F;
    }
}
