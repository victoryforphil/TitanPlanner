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
    public partial class DecisionSettings : Form
    {
        DecisionStep Step;
        MainApp Main;

        public DecisionSettings(DecisionStep _step, MainApp _main)
        {
            Step = _step;
            Main = _main;
            InitializeComponent();
        }

        private void button_newStep_Click(object sender, EventArgs e)
        {
            switch (comboBox_Type.Text)
            {
                case "Waypoint":
                    WaypointStep _newWay = new WaypointStep(FieldFunctions.GetStepID());
                    Step.AddChildStep(_newWay);
                    FieldData.CurrentStep = _newWay;
                    WaypointSettings _waypointSettings = new WaypointSettings((WaypointStep)FieldData.CurrentStep, Main);
                    _waypointSettings.Show();
                    Main.DrawWaypoints();
                    Main.UpdateTree();
                    Console.WriteLine(_newWay.Type);
                    break;
                case "Rotation":
                    RotationStep _newRot = new RotationStep(FieldFunctions.GetStepID());
                    Step.AddChildStep(_newRot);
             
                    FieldData.CurrentStep = _newRot;
                    RotationSettings _rotationSettings = new RotationSettings((RotationStep)FieldData.CurrentStep, Main);
                    _rotationSettings.Show();
                    Main.DrawWaypoints();
                    Main.UpdateTree();
                    break;
            }
        }
    }
}
