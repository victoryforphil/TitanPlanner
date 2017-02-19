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
        bool blockUpdate = false;
        public struct MotorSettingUI
        {
            public Label MotorName;
            public NumericUpDown Setting;
            public CheckBox Revrsed; 
        }

        public struct DriveUI
        {
            public string Direction;
            public List<MotorSettingUI> Settings;
        }

        public List<DriveUI> UIElements = new List<DriveUI>();

        public String[] Directions = { "Forward", "Backward", "Left", "Right", "Turn Left", "Turn Right" };

        public DriveConfig()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                blockUpdate = true;
                foreach (DriveMotorConfig driveConfig in FieldData.DriveConfigs)
                {
                    foreach (MotorSetting motor in driveConfig.Settings)
                    {
                        NumericUpDown val = GetMotorValue(driveConfig.Direction, motor.MotorName).Setting;
                        CheckBox check = GetMotorValue(driveConfig.Direction, motor.MotorName).Revrsed;
                        if (val != null)
                        {
                            
                            val.Value = motor.Setting;
                            check.Checked = motor.Reversed;
                            
                        }
                        else
                        {
                            Console.WriteLine("No Motor value for: " + motor.MotorName + " in: " + driveConfig.Direction);
                        }
                    }
                }
                blockUpdate = false;
            }
            catch(Exception e)
            {
               
            }
        }

        private MotorSettingUI GetMotorValue(string Direction, string MotorValue)
        {
            MotorSettingUI found = new MotorSettingUI();
            foreach (DriveUI _ui in UIElements)
            {
                if(_ui.Direction == Direction)
                {
                    foreach (MotorSettingUI _motor in _ui.Settings)
                    {
                        if(_motor.MotorName.Text == MotorValue)
                        {
                            found.Setting = _motor.Setting;
                            found.Revrsed = _motor.Revrsed;
                        }
                    }
                }
                

                
            }
            return found;
        }

        private void DriveConfig_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            UIElements.Clear();
            foreach(String _direction in Directions)
            {
                TabPage page = new TabPage(_direction);
                page.Width = tabControl1.Width;
                page.Height = tabControl1.Height - 10;
                DriveUI _ui = new DriveUI();
                _ui.Direction = _direction;

                _ui.Settings = new List<MotorSettingUI>();
                int CurrentMotor = 0;
                Panel _panel = new Panel();
                _panel.Width = page.Width - 5;
                _panel.Height = page.Height - 10;
                _panel.AutoScroll = true;
                _panel.Margin = new Padding(0);
                _panel.Location = new Point(0, 0);

                foreach (String _motor in GetMotors())
                {
                    

                    Label _label = new Label();
                    _label.Text = _motor;
                    _label.Width = 50;
                    _label.Margin = new Padding(5);
                    _label.Location = new Point(5, 10 + (CurrentMotor * 30));
                    _panel.Controls.Add(_label);

                    NumericUpDown _num = new NumericUpDown();
                    _num.Maximum = 1;
                    _num.Minimum = -1;
                    _num.Increment = 1;
                    _num.Width = 50;
                    _num.Location = new Point(5 + _label.Width, 7 + (CurrentMotor * 30));
                    _num.ValueChanged += Update;
                    _panel.Controls.Add(_num);

                    CheckBox _check = new CheckBox();
                    _check.Text = "Reseved";
                    _check.CheckedChanged += Update;
                    _check.Location = new Point(5 + _num.Width + _num.Location.X, 7 + (CurrentMotor * 30));
                    _panel.Controls.Add(_check);


                    page.Controls.Add(_panel);

                    CurrentMotor++;
                    MotorSettingUI _motorUI = new MotorSettingUI();
                    _motorUI.MotorName = _label;
                    _motorUI.Setting = _num;
                    _motorUI.Revrsed = _check;
                    
                    _ui.Settings.Add(_motorUI);
                    
                }


                UIElements.Add(_ui);
                tabControl1.TabPages.Add(page);
            }
            LoadData();
        }

        private List<String> GetMotors()
        {
            List<String> final = new List<String>();
            foreach(Hardware _hardware in FieldData.hardware)
            {
                if(_hardware.Type == "Motor")
                {
                    final.Add(_hardware.Name);
                }
            }
            return final;
        }


        private void Update(object sender, EventArgs e)
        {
            if (blockUpdate) { return; }
            FieldData.DriveConfigs.Clear();
            foreach (DriveUI _ui in UIElements)
            {
                DriveMotorConfig _config = new DriveMotorConfig();
                _config.Direction = _ui.Direction;
                foreach(MotorSettingUI _motor in _ui.Settings)
                {
                    MotorSetting _motorSetting = new MotorSetting();
                    _motorSetting.MotorName = _motor.MotorName.Text;
                    _motorSetting.Setting = (int)_motor.Setting.Value;
                    _motorSetting.Reversed = _motor.Revrsed.Checked;
                    _config.Settings.Add(_motorSetting);
                }

                FieldData.DriveConfigs.Add(_config);
            }
        }
        
    }
}
