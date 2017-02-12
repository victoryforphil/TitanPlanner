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
    public partial class WaypointSettings : Form
    {
        private WaypointStep Step;
        private MainApp Main;
        public WaypointSettings(WaypointStep _step, MainApp _main)
        {
            Step = _step;
            Main = _main;
            InitializeComponent();
        }

        private void WaypointSettings_Load(object sender, EventArgs e)
        {
            Text = Step.Name + " Settings";
            
            nup_Speed.Value =  (decimal)Step.Speed;
            nup_coordY.Value = (decimal)Step.Coord.Y;
            nup_CoordX.Value = (decimal)Step.Coord.X;
            nup_Length.Value = (decimal)Step.Delay;

        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void nup_Speed_ValueChanged(object sender, EventArgs e)
        {
            Step.Speed = (float)nup_Speed.Value;
        }

        private void nup_Length_ValueChanged(object sender, EventArgs e)
        {
            Step.Delay = (float)nup_Length.Value;
        }

        private void nup_CoordX_ValueChanged(object sender, EventArgs e)
        {
            Step.Coord.X = (float)nup_CoordX.Value;
            Main.DrawWaypoints();
        }

        private void nup_coordY_ValueChanged(object sender, EventArgs e)
        {
            Step.Coord.Y = (float)nup_coordY.Value;
            Main.DrawWaypoints();
        }
    }
}
