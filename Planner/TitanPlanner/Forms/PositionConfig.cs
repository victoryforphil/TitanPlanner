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

                _ui.Enabled.Location = new Point(170, 25 * i);
                _ui.Enabled.Size = new Size(70, 20);

                panel_ultra.Controls.Add(_ui.Name);
                panel_ultra.Controls.Add(_ui.Direction);
                panel_ultra.Controls.Add(_ui.Enabled);
            }
        }
    }
}
