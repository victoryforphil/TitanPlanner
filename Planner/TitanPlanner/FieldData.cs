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

    public class MotorSetting
    {
        public string MotorName;
        public bool Reversed;
        public string Position;
    }

    public class DriveMotorConfig
    {
        public string Type;
        
        public List<MotorSetting> Settings = new List<MotorSetting>();
    }

    public class UltraSetting
    {
        public string Name;
        public float Offset;
        public string Direction;
        public bool Enabled;
    }

    public class PostitionConfig
    {
        public List<UltraSetting> UltrasonicSettings = new List<UltraSetting>();
        public bool UltrasonicEnabled;
        public float FieldSizeCM;
    }

    static class FieldData
    {
        public static List<Step> Steps = new List<Step>();
        public static Step CurrentStep;

        public static List<Hardware> hardware = new List<Hardware>();
        public static DriveMotorConfig DriveConfig = new DriveMotorConfig();

        public static PostitionConfig PositionConfig = new PostitionConfig();

        public static float TicksPerMeter = 3000;
        public static float TicksPerUnit = 10;
        public static float TrimX = 100;
        public static float TrimY = 100;
        public static float FieldSizeMeters = 3.6F;
        
    }
}
