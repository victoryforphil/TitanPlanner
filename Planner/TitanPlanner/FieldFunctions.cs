using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace TitanPlanner
    {
    public class TitanObject
    {
        public float TicksPerUnit;
        public float FieldSizeMeters;
        public float TicksPerMeter;
        public float TrimX;
        public float TrimY;
        public List<Step> Steps = new List<Step>();
    }
    static class FieldFunctions
    {
        
        

        public static void NewWaypoint(int MouseX, int MouseY)
        { 
            WaypointStep _new = new WaypointStep(GetStepID());
        
            FieldData.Steps.Add(_new);
            FieldData.CurrentStep = _new;
            Console.WriteLine("[FieldFunctions] Adding new Step: " + _new.ID);
        }

        public static void NewRotation()
        {
            RotationStep _new = new RotationStep(GetStepID());

            FieldData.Steps.Add(_new);
            FieldData.CurrentStep = _new;
            Console.WriteLine("[FieldFunctions] Adding new Step: " + _new.ID);
        }

        public static void NewDecision()
        {
            DecisionStep _new = new DecisionStep(GetStepID());

            FieldData.Steps.Add(_new);
            FieldData.CurrentStep = _new;
            Console.WriteLine("[FieldFunctions] Adding new Step: " + _new.ID);
        }

        public static int GetStepID()
        {
            return FieldData.Steps.Count;
        }


        public static List<WaypointStep> GetAllWaypoints(List<Step> Steps)
        {
            List<WaypointStep> _waypoints = new List<WaypointStep>();  
            foreach(Step _step in Steps)
            {
                SearchForWaypoint(_step, ref _waypoints);
            }
            return _waypoints;
        }

        private static void SearchForWaypoint(Step _step, ref List<WaypointStep> _final)
        {
            foreach (Step _child in _step.ChildSteps)
            {
       
                SearchForWaypoint(_child, ref _final);
            }
            if (_step.Type == StepType.Waypoint)
            {
                _final.Add((WaypointStep)_step);

            }
        }



        public static void UpdateTickPerUnit()
        {
            FieldData.TicksPerUnit = (FieldData.TicksPerMeter * FieldData.FieldSizeMeters) / 1000;
        }

        public static void Export(string path)
        {

            Console.WriteLine("Saving to: " + path);
            UpdateTickPerUnit();
            TitanObject exportobj = new TitanObject();
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            exportobj.TicksPerMeter   = FieldData.TicksPerMeter;
            exportobj.TicksPerUnit    = FieldData.TicksPerUnit;
            exportobj.TrimX           = FieldData.TrimX;
            exportobj.TrimY           = FieldData.TrimY;
            exportobj.FieldSizeMeters = FieldData.FieldSizeMeters;
            exportobj.Steps           = FieldData.Steps;

            string json = JsonConvert.SerializeObject(exportobj, settings);
            System.IO.File.WriteAllText(path, json);
        }
    }
}
