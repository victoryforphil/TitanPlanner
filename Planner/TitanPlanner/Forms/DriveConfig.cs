using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitanPlanner
{
    public partial class DriveConfig : Form
    { 

        public DriveConfig()
        {
            InitializeComponent();
            LoadData();
        }

        private void DriveConfig_Load(object sender, EventArgs e)
        {

            textBox_FL.TextChanged += OnUpdate;
            textBox_FR.TextChanged += OnUpdate;
            textBox_RL.TextChanged += OnUpdate;
            textBox_RR.TextChanged += OnUpdate;


        }

        private void LoadData()
        {
            if (FieldData.DriveConfig.Type == "HOLONOMIC")
            {
                foreach(MotorSetting _setting in FieldData.DriveConfig.Settings)
                {
                    switch (_setting.Position)
                    {
                        case "FRONT_LEFT":
                            textBox_FL.Text = _setting.MotorName;
                            checkBox_FL_Reversed.Checked = _setting.Reversed;
                        break;

                        case "FRONT_RIGHT":
                            textBox_FR.Text = _setting.MotorName;
                            checkBox_FR_Reversed.Checked = _setting.Reversed;
                            break;
                        case "REAR_LEFT":
                            textBox_RL.Text = _setting.MotorName;
                            checkBox_RL_Reversed.Checked = _setting.Reversed;
                            break;
                        case "REAR_RIGHT":
                            textBox_RR.Text = _setting.MotorName;
                            checkBox_RR_Reversed.Checked = _setting.Reversed;
                            break;

                    }
                }
            }
        }

        public void OnUpdate(object sender, EventArgs e)
        {
            FieldData.DriveConfig.Settings.Clear();

            MotorSetting FLMotor = new MotorSetting();
            FLMotor.MotorName = textBox_FL.Text;
            FLMotor.Reversed = checkBox_FL_Reversed.Checked;
            FLMotor.Position = "FRONT_LEFT";

            MotorSetting FRMotor = new MotorSetting();
            FRMotor.MotorName = textBox_FR.Text;
            FRMotor.Reversed = checkBox_FR_Reversed.Checked;
            FRMotor.Position = "FRONT_RIGHT";

            MotorSetting RLMotor = new MotorSetting();
            RLMotor.MotorName = textBox_RL.Text;
            RLMotor.Reversed = checkBox_RL_Reversed.Checked;
            RLMotor.Position = "REAR_LEFT";

            MotorSetting RRMotor = new MotorSetting();
            RRMotor.MotorName = textBox_RR.Text;
            RRMotor.Reversed = checkBox_RR_Reversed.Checked;
            RRMotor.Position = "REAR_RIGHT";

            FieldData.DriveConfig.Settings.Add(FLMotor);
            FieldData.DriveConfig.Settings.Add(FRMotor);
            FieldData.DriveConfig.Settings.Add(RLMotor);
            FieldData.DriveConfig.Settings.Add(RRMotor);

            FieldData.DriveConfig.Type = "HOLONOMIC";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
