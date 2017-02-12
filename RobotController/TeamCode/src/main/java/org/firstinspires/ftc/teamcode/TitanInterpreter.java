package org.firstinspires.ftc.teamcode;

import android.content.res.AssetManager;
import android.util.Log;
import android.util.Xml;

import com.qualcomm.robotcore.eventloop.opmode.Autonomous;
import com.qualcomm.robotcore.eventloop.opmode.LinearOpMode;
import com.qualcomm.robotcore.util.ElapsedTime;

import org.firstinspires.ftc.robotcore.external.Telemetry;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Logger;

/**
 * Created by VictoryForPhil on 2/11/2017.
 */
@Autonomous(name="Titan Planner 2", group="Linear Opmode")
public class TitanInterpreter extends LinearOpMode{
    private String TitanFileName = "Test.titan";
    private ElapsedTime Runtime = new ElapsedTime();
    private TitanLogger Logger = new TitanLogger();

    private ArrayList<Step> Steps = new ArrayList<Step>();
    private float TrimX;
    private float TrimY;

    private boolean isWorking = true;

    private class Step{
        public int Type;
        public String Name;
        public double CoordX;
        public double CoordY;
        public double Delay;
        public double Speed;
        public String ValueName;
        public String DecisionType;
        public String DeicsionValue;
    }


    private float TicksPerUnit;


    @Override
    public void runOpMode() throws InterruptedException {

        Logger.ConnectToServer();

        LoadTitanFile();
        //Logger.AddData("STATUS", "Waiting for Start");
        waitForStart();
        Logger.AddData("STATUS", "Playing..");
        StartProgram();
        while(isWorking){}
        Logger.Stop();
    }

    private void LoadTitanFile(){
        Logger.AddData("STATUS", "Loading Titan File...");
        AssetManager am = hardwareMap.appContext.getAssets();
        try {
            InputStream is = am.open(TitanFileName);
            byte[] TitanFileData = new byte[10000];
            is.read(TitanFileData);

            String ConvertedString = new String(TitanFileData);
            try {
                JSONObject _titanObject = new JSONObject(ConvertedString);
                JSONArray _stepArray = _titanObject.getJSONObject("Steps").getJSONArray("$values");
                TrimX = (float)_titanObject.getDouble("TrimX");
                TrimY = (float)_titanObject.getDouble("TrimY");
                Logger.AddData("TrimX", TrimX + "");
                Logger.AddData("TrimY", TrimY + "");
                Logger.AddData("STEPS", _stepArray.length() + "");


                for (int i=0;i<_stepArray.length();i++){

                    JSONObject _obj = (JSONObject) _stepArray.get(i);
                    Step _newStep = new Step();
                    int type = _obj.getInt("Type");
                    Logger.AddData("JSON PARSE - " + _obj.getString("Name"), "Adding Type:" + type);
                    switch (type){
                        case 1: // Waypoint
                            _newStep.Name   = _obj.getString("Name");
                            _newStep.Delay  = _obj.getDouble("Delay");
                            _newStep.CoordX = _obj.getJSONObject("Coord").getDouble("X");
                            _newStep.CoordY = _obj.getJSONObject("Coord").getDouble("Y");
                            _newStep.Speed  = _obj.getDouble("Speed");
                            break;
                    }

                    Steps.add(_newStep);
                }

                Logger.AddData("STATUS", "Loaded: " + Steps.size());

            }catch (JSONException ex){
                Logger.AddData("ERROR JSON",ex.toString());
            }



        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void StartProgram(){
        Logger.AddData("STATUS", "Start Program");
        Runtime.startTime();

        float LastTime;


        for(int i=0;i<Steps.size();i++){
            Step CurrentStep = Steps.get(i);

            Logger.AddData("CURRENT STEP", CurrentStep.Name + " - " + CurrentStep.Type);

            switch (CurrentStep.Type){
                case 1: // Waypoint
                    Blocking_MoveMotor(CurrentStep.CoordX * TicksPerUnit, CurrentStep.CoordY * TicksPerUnit);
                    break;
                case 2: // Rotation

                    break;
                case 3: // Choice?

                    break;
            }

            Blocking_WaitTilTime(CurrentStep.Delay + Runtime.seconds());

        }

        isWorking = false;

    }


    public void Blocking_MoveMotor(double EncoderX, double EncoderY){
        while(opModeIsActive() && EncoderX > Runtime.milliseconds() ){
            Logger.AddData("MOTOR", Runtime.milliseconds() + " / " + EncoderX);
        }
    }

    public void Blocking_WaitTilTime(double time){
        while(opModeIsActive() && time > Runtime.seconds()){
            Logger.AddData("RUNTIME", Runtime.seconds() + "");
        }
    }

    private class Denoiser{
        private ArrayList<Float> AllValues = new ArrayList<Float>();
        private float CurrentValue;

        private int UpdateRate;

        private int CurrentTick = 0;

        private int OutlierCount = 0;
        private int OutlierMaxCount = 5;
        private float OutlierMax;


        public Denoiser(int updateRate, float outlierMax){
            UpdateRate = updateRate;
            OutlierMax = outlierMax;
        }

        public void Update(float val){
            if(CurrentTick >= UpdateRate){
                AllValues.clear();
                CurrentTick = 0;
            }


            float lastVal = AllValues.get(AllValues.size() - 1);
            if(Math.abs(val - lastVal) > OutlierMax && OutlierMaxCount < OutlierCount){
                Log.d("Desnoiser!", "Outlier: " + val );
                OutlierCount++;
                return;

            }else if(OutlierMaxCount >= OutlierCount){
                AllValues.add(val);
                OutlierCount = 0;
            }

            CurrentValue = AllValues.get(AllValues.size());
            
            CurrentTick++;
        }

        public float GetValueFloat(){

        }

        public double GetValueDouble(){

        }
    }

}
