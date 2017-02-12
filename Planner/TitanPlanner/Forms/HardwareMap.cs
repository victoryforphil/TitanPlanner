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
    public partial class HardwareMap : Form
    {
        public struct HardwareMapUI
        {
            public TextBox NameField;
            public ComboBox TypeField;
        }

        public List<HardwareMapUI> Selections = new List<HardwareMapUI>();

        public String[] DropdownOptions = { "Ultrasonic", "Motor", "Image", "Servo" };
        
        public int Current;
        public HardwareMap()
        {
            InitializeComponent();
        }

        private void HardwareMap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            foreach(Hardware _hardware in FieldData.hardware)
            {
                TextBox txt = new TextBox();
                txt.Name = "textBox_" + Current;
                txt.Text = _hardware.Name;
                txt.Location = new Point(0, 25 * Current);
                txt.TextChanged += OnUpdate;

                ComboBox combo = new ComboBox();
                combo.Name = "combo_" + Current;
                combo.Location = new Point(txt.Width + 10, 25 * Current);
                combo.Items.AddRange(DropdownOptions);
                combo.SelectedItem = _hardware.Type;
                combo.TextChanged += OnUpdate;

                panel1.Controls.Add(txt);
                panel1.Controls.Add(combo);

                HardwareMapUI _ui = new HardwareMapUI();
                _ui.NameField = txt;
                _ui.TypeField = combo;
                Selections.Add(_ui);

                Current++;
            }
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            txt.Name = "textBox_"+ Current;
            txt.Location = new Point(0, 25 * Current);
            txt.TextChanged += OnUpdate;

            ComboBox combo = new ComboBox();
            combo.Name = "combo_" + Current;
            combo.Location = new Point(txt.Width + 10, 25 * Current);
            combo.Items.AddRange(DropdownOptions);
            combo.SelectedItem = "Motor";
            combo.TextChanged += OnUpdate;

            panel1.Controls.Add(txt);
            panel1.Controls.Add(combo);

            HardwareMapUI _ui = new HardwareMapUI();
            _ui.NameField = txt;
            _ui.TypeField = combo;
            Selections.Add(_ui);

            Current++;


            
        }

   

        private void OnUpdate(object sender, EventArgs e)
        {
            FieldData.hardware.Clear();
            foreach(HardwareMapUI ui in Selections)
            {
                if(ui.NameField.Text != "")
                {
                    Hardware _new = new Hardware();
                    _new.Name = ui.NameField.Text;
                    _new.Type = ui.TypeField.Text;
                    FieldData.hardware.Add(_new);

                }
            }


        }
    }
}
