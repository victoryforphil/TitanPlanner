using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitanPlanner
{
    public partial class MainApp : Form
    {
        private Bitmap OrignalMapImage = null;
        public MainApp()
        {
            Console.WriteLine("[MainApp] Window Starting.");
            InitializeComponent();

            Console.WriteLine("[MainApp] Window Loaded!");
        }

       
        List<WaypointStep> AllWaypoints = new List<WaypointStep>();

        private void ClearMap()
        {
            if (OrignalMapImage == null)
            {
                OrignalMapImage = new Bitmap(pictureBox_Map.Image);
            }

            pictureBox_Map.Image = OrignalMapImage;
        }
        /*
       private void UpdateCurrentWaypoint()
       {

           

       }
       */


        public void UpdateTree()
        {
            treeView_steps.BeginUpdate();
            treeView_steps.Nodes.Clear();
            
        

            for(int i = 0; i < FieldData.Steps.Count; i++)
            {
            
                TreeNode _stepNode = FieldData.Steps[i].ConvertToTreeNode();
                Console.WriteLine(_stepNode.Nodes.Count);
                treeView_steps.Nodes.Add(_stepNode);


            }
            treeView_steps.EndUpdate();
          
            
            
        }

        
    
       public void DrawWaypoints()
       {
           ClearMap();
            

            //treeView_steps.Nodes.Clear();

            Vector2 prev = null;
            AllWaypoints.Clear();

            AllWaypoints = FieldFunctions.GetAllWaypoints(FieldData.Steps);
           

           foreach (WaypointStep _waypoint in AllWaypoints)
           {
                    
                    Pen pen = null;

                    if (_waypoint.ID == FieldData.CurrentStep.ID)
                    {
                        pen = new Pen(Color.Yellow);
                    }
                    else
                    {
                        pen = new Pen(Color.Black);
                    }
                    Bitmap bmp = new Bitmap(pictureBox_Map.Image);
                    Graphics g = Graphics.FromImage(bmp);

                    Vector2 pos = FieldMath.ConvertCoordToScreen(_waypoint.Coord);
                    g.DrawEllipse(pen, new Rectangle((int)pos.X - 5, (int)pos.Y - 5, 10, 10));
                    g.DrawString(_waypoint.Name, Font, Brushes.White, pos.GetPoint());
                    if(prev != null)
                    {
                        g.DrawLine(Pens.YellowGreen, prev.GetPoint(), pos.GetPoint());


                    }
                    else
                    {
                        
                    }

                    prev = FieldMath.ConvertCoordToScreen(_waypoint.Coord);
                    pictureBox_Map.Image = bmp;
         



           }
       }
       
        private void MainApp_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox_Map_Enter(object sender, EventArgs e)
        {

        }


        private void treeView_steps_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
           if(e.Node.Parent != null)
            {
                DecisionStep _parentStep = (DecisionStep)FieldData.Steps[e.Node.Parent.Index];
                FieldData.CurrentStep = _parentStep.ChildSteps[e.Node.Index];
            }
            else
            {
                FieldData.CurrentStep = FieldData.Steps[e.Node.Index];
            }
            
          
           Console.WriteLine("[Main] Tree Selected: " + FieldData.Steps[e.Node.Index].Name);
           DrawWaypoints();
        }

        public void CreateNewStep(object sender, EventArgs e)
        {
            
            switch (comboBox_StepType.Text)
            {
                case "Waypoint":
                    FieldFunctions.NewWaypoint(0, 0);
                    WaypointSettings _waypointSettings = new WaypointSettings((WaypointStep)FieldData.CurrentStep, this);
                    _waypointSettings.Show();
                    DrawWaypoints();

                    break;
                case "Rotation":
                    FieldFunctions.NewRotation();    
                    RotationSettings _rotationSettings = new RotationSettings((RotationStep)FieldData.CurrentStep, this);
                    _rotationSettings.Show();
                    DrawWaypoints();

                break;

                case "Choice":
                    FieldFunctions.NewDecision();
                    DecisionSettings _settings = new DecisionSettings((DecisionStep)FieldData.CurrentStep, this);
                    _settings.Show();
                    DrawWaypoints();

                    break;
            }
            UpdateTree();

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            UpdateTree();
            if (FieldData.CurrentStep == null)
            {
                return;
            }
            switch (FieldData.CurrentStep.Type)
            {
                case StepType.Waypoint:
                    WaypointSettings _waypointSettings = new WaypointSettings((WaypointStep)FieldData.CurrentStep, this);
                    _waypointSettings.Show();
                break;

                case StepType.Rotation:
                    RotationSettings _rotationSettings = new RotationSettings((RotationStep)FieldData.CurrentStep, this);
                    _rotationSettings.Show();
                    break;


                case StepType.Choice:
                    DecisionSettings decisionSettings = new DecisionSettings((DecisionStep)FieldData.CurrentStep, this);
                    decisionSettings.Show();
                    break;
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {

            saveFileDialog1.ShowDialog();

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FieldFunctions.Export(saveFileDialog1.FileName);
        }

        private void pictureBox_Map_Click(object sender, EventArgs e)
        {

        }

        private void nud_TicksPerMeter_ValueChanged(object sender, EventArgs e)
        {
            FieldData.TicksPerMeter = (float)nud_TicksPerMeter.Value;
            FieldFunctions.UpdateTickPerUnit();
            label_ticksPerUnit.Text = "Ticks/Unit = " + FieldData.TicksPerUnit;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            FieldData.FieldSizeMeters = (float)numericUpDown1.Value;
            FieldFunctions.UpdateTickPerUnit();
            label_ticksPerUnit.Text = "Ticks/Unit = " + FieldData.TicksPerUnit;
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();   
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                   
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    TitanObject m = JsonConvert.DeserializeObject<TitanObject>(line, settings);
                    FieldData.Steps = m.Steps;
                    FieldData.FieldSizeMeters = m.FieldSizeMeters;
                    FieldData.TicksPerMeter = m.TicksPerMeter;
                    FieldData.TicksPerUnit = m.TicksPerUnit;
                    FieldData.hardware = m.Hardware;
                    FieldData.DriveConfig = m.Drive;

                    nud_TicksPerMeter.Value = (decimal)FieldData.TicksPerMeter;
                    numericUpDown1.Value = (decimal)FieldData.FieldSizeMeters;
                    label_ticksPerUnit.Text = "Ticks/Unit = " + FieldData.TicksPerUnit;

                    UpdateTree();
                    DrawWaypoints();
                }
            }
            catch (Exception e2)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e2.Message);
            }
           
        }

        private void button_logger_Click(object sender, EventArgs e)
        {
            TitanLogger logger = new TitanLogger();
            logger.Show();
        }
        private void Launch()
        {
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DriveConfig _driveConfig = new DriveConfig();
            _driveConfig.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HardwareMap _window = new HardwareMap();
            _window.ShowDialog();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            FieldData.Steps.Remove(FieldData.CurrentStep);
            UpdateTree();
            DrawWaypoints();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            PositionConfig _window = new PositionConfig();
            _window.ShowDialog();
        }
    }
}
