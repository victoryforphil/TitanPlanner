using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TitanPlanner
{
    public enum StepType { Default, Waypoint, Choice, Action, Rotation };
    public class Step
    {
        public StepType Type = StepType.Default;
        public int ID = -1;
        public string Name = "";
        public float Delay = 0.0F;
        public List<Step> ChildSteps = new List<Step>();
        public bool isChild;
        public Step(int ID)
        {
            this.ID = ID;
            
        }

        public void AddChildStep(Step _step)
        {
            _step.Name = _step.Type + " " + ID + "-" + _step.ID;
            isChild = true;
            ChildSteps.Add(_step);
        }

        public TreeNode ConvertToTreeNode()
        {
            TreeNode _node;
            _node = new TreeNode(Name);
            _node.Name = Name;
            foreach(Step _child in ChildSteps)
            {
                _node.Nodes.Add(_child.ConvertToTreeNode());
            }
            return _node;
        }
    }

    public class WaypointStep : Step
    {
        public Vector2 Coord;
        public float Speed = 1.0f;
       

        public WaypointStep(int ID) : base(ID)
        {
            this.Coord = new Vector2(250,250);
            this.Type = StepType.Waypoint;
            this.Name = Type + " " + ID;
        }

        public void UpdateCoord(Vector2 _new)
        {
            Coord = _new;
        }
    }

    public class RotationStep : Step
    {
        public bool useGyro;
        public float Angel;
        public float Encoder;
        public RotationStep(int ID) : base(ID)
        {
            this.Type = StepType.Rotation;
            this.Name = Type + " " + ID;
        }
    }

    public class DecisionStep : Step
    {
       
        public string ValueName;
        public enum MeasureType { Bool, Lessthan, Greaterthan, Range };
        public MeasureType Measure;
        public string Data;

        public DecisionStep(int ID) : base(ID)
        {
            this.Type = StepType.Choice;
            this.Name = Type + " " + ID;
        }
    }
}
