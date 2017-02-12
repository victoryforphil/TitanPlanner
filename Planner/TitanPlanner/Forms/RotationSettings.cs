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
    public partial class RotationSettings : Form
    {
        RotationStep Step;
        MainApp Main;
        public RotationSettings(RotationStep _step, MainApp _main)
        {
            Main = _main;
            Step = _step;

            InitializeComponent();
        }


        private void checkBox_Gyro_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown_Gyro.Enabled = checkBox_Gyro.Checked;
        }

        private void RotationSettings_Load(object sender, EventArgs e)
        {
            Text = Step.Name + " Settings";
        }

        private void numericUpDown_Gyro_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
