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
    public partial class PositionConfig : Form
    {
        public class UltrasonicUI
        {
            public TextBox Name;
            public ComboBox Direction;
            public NumericUpDown Offset;
            public CheckBox Enabled;
        }

        public string[] Directions = { "Foward", "Back", "Left", "Right" };

        public List<UltrasonicUI> UltrasonicSettingsUI = new List<UltrasonicUI>();

        public PositionConfig()
        {
           
            InitializeComponent();
            
        }

        private void PositionConfig_Load(object sender, EventArgs e)
        {
            checkBox_unltraEnabled.CheckedChanged += Update;
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel_ultra_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadData()
        {
            foreach(Hardware _sensor in FieldData.hardware)
            {
                Console.WriteLine(_sensor.Type);
                if(_sensor.Type == "Ultrasonic")
                {
                    NewUltrasonicUI(_sensor.Name);
                }
            }
        }

        private void NewUltrasonicUI(string Name)
        {
            UltrasonicUI _new = new UltrasonicUI();
            _new.Direction = new ComboBox();
            _new.Direction.Items.AddRange(Directions);
            _new.Direction.SelectedItem = Directions[0];

            _new.Name = new TextBox();
            _new.Name.Text = Name;

            _new.Offset = new NumericUpDown();
            _new.Offset.DecimalPlaces = 3;
            

            _new.Enabled = new CheckBox();
            _new.Enabled.Checked = true;
            _new.Enabled.Text = "Enabled";

            UltrasonicSettingsUI.Add(_new);

            LoadUltrasonicUI();
        }

        private void LoadUltrasonicUI()
        {

            for(int i = 0; i < UltrasonicSettingsUI.Count; i++)
            {
                UltrasonicUI _ui = UltrasonicSettingsUI[i];
                _ui.Name.Size = new Size(80, 10);
                _ui.Name.Location = new Point(0, 25 * i);


                _ui.Direction.Location = new Point(90, 25 * i);
                _ui.Direction.Size = new Size(70, 10);
                _ui.Direction.SelectedValueChanged += Update;

                _ui.Offset.Location = new Point(170, 25 * i);
                _ui.Offset.Size = new Size(60, 20);
                _ui.Offset.ValueChanged += Update;

                _ui.Enabled.Location = new Point(240, 25 * i);
                _ui.Enabled.Size = new Size(70, 20);
                _ui.Enabled.CheckedChanged += Update;

                panel_ultra.Controls.Add(_ui.Name);
                panel_ultra.Controls.Add(_ui.Direction);
                panel_ultra.Controls.Add(_ui.Offset);
                panel_ultra.Controls.Add(_ui.Enabled);
                
            }
        }

        private void Update(object sender, EventArgs e)
        {
            FieldData.PositionConfig.UltrasonicSettings.Clear();
           foreach (UltrasonicUI _ui in UltrasonicSettingsUI)
            {
                UltraSetting _setting = new UltraSetting();
                _setting.Name         = _ui.Name.Text;
                _setting.Direction    = _ui.Direction.SelectedText;
                _setting.Enabled      = _ui.Enabled.Checked;
                FieldData.PositionConfig.UltrasonicSettings.Add(_setting);
            }

            FieldData.PositionConfig.UltrasonicEnabled = checkBox_unltraEnabled.Checked;
            FieldData.PositionConfig.FieldSizeCM = (float)numericUpDown_fieldsize.Value;
        }
    }
}
