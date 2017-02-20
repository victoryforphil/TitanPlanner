
package org.firstinspires.ftc.teamcode;

import android.content.res.AssetManager;
import android.util.Log;
import android.util.Xml;

import com.qualcomm.robotcore.eventloop.opmode.Autonomous;
import com.qualcomm.robotcore.eventloop.opmode.LinearOpMode;
import com.qualcomm.robotcore.hardware.DcMotor;
import com.qualcomm.robotcore.hardware.HardwareDevice;
import com.qualcomm.robotcore.hardware.HardwareMap;
import com.qualcomm.robotcore.hardware.UltrasonicSensor;
import com.qualcomm.robotcore.util.ElapsedTime;
import com.qualcomm.robotcore.util.Hardware;

import org.firstinspires.ftc.robotcore.external.Telemetry;
import org.firstinspires.ftc.robotcore.external.matrices.VectorF;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Array;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;
import java.util.logging.Logger;

import org.firstinspires.ftc.teamcode.TitanPosition.*;

/**
 * Created by VictoryForPhil on 2/11/2017.
 */
@Autonomous(name="Titan", group="Concept")


public class TitanInterpreter extends LinearOpMode{
    private String TitanFileName = "Test.titan";
    private ElapsedTime Runtime = new ElapsedTime();
    private TitanLogger Logger = new TitanLogger();

    private ArrayList<Step> Steps = new ArrayList<Step>();


    private HashMap<String, HardwareDevice> Hardware = new HashMap<String, HardwareDevice>();
    private HashMap<String, ArrayList<MotorSetting>> DriveConfig = new HashMap<String, ArrayList<MotorSetting>>();

    private float TrimX;
    private float TrimY;

    private boolean isWorking = true;

    private class MotorSetting{
        public String Name;
        public int Value;
    }


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

    public class UltrasonicSetting{
        public String Name;
        public String Direction;
        public double Offset;
        public UltrasonicSensor Sensor;
    }

    public class PositionSetting{
        public boolean UltraEnabled;
        public ArrayList<UltrasonicSetting> UltraSettings = new ArrayList<UltrasonicSetting>();
    }

    private float TicksPerUnit;

    public PositionSetting PositionSettings;

    private Timer PosTimer = new Timer();
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
                JSONArray _stepArray = _titanObject.getJSONArray("Steps");





                TrimX = (float)_titanObject.getDouble("TrimX");
                TrimY = (float)_titanObject.getDouble("TrimY");
                TicksPerUnit = (float)_titanObject.getDouble("TicksPerUnit");

                Logger.AddData("TrimX", TrimX + "");
                Logger.AddData("TrimY", TrimY + "");
                Logger.AddData("STEPS", _stepArray.length() + "");


                // -- STEP LOADING -- //
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
                            _newStep.Type   = type;
                            break;
                    }

                    Steps.add(_newStep);
                }

                JSONArray _hardwareArray = _titanObject.getJSONArray("Hardware");
                // -- HARDWARE LOADING -- //
                for (int i=0;i<_hardwareArray.length();i++){

                    JSONObject _obj = (JSONObject) _hardwareArray.get(i);

                    String type = _obj.getString("Type");
                    String name = _obj.getString("Name");
                    switch (type){
                        case "Ultrasonic":
                            Hardware.put(name, hardwareMap.ultrasonicSensor.get(name));
                            break;
                        case "Motor":
                            Hardware.put(name, hardwareMap.dcMotor.get(name));
                            break;
                        case "Servo":
                            Hardware.put(name, hardwareMap.servo.get(name));
                            break;
                    }
                }

                JSONArray _driveArray = _titanObject.getJSONArray("Drive");
                // -- DRIVE LOADING -- //
                for (int i=0;i<_driveArray.length();i++){

                    JSONObject _obj = (JSONObject) _driveArray.get(i);

                    String Direction = _obj.getString("Direction");

                    ArrayList<MotorSetting> MotorSettings = new ArrayList<MotorSetting>();
                    JSONArray _motorArray = _obj.getJSONArray("Settings");


                    for(int x=0;x<_motorArray.length();x++) {

                        JSONObject _motorObj = (JSONObject) _motorArray.get(x);
                        MotorSetting _motor = new MotorSetting();
                        _motor.Name  = _motorObj.getString("MotorName");
                        _motor.Value = _motorObj.getInt("Setting");
                        MotorSettings.add(_motor);
                        Log.e("JSON", "Loading Motor: " + _motor.Name + " for Direction: " + Direction);
                    }

                    DriveConfig.put(Direction,MotorSettings);


                }


                // -- POSITION -- //
                JSONObject _positionObject = _titanObject.getJSONObject("Position");

                JSONArray _ultrasonicSettings = _positionObject.getJSONArray("UltrasonicSettings");

                for (int i=0;i<_ultrasonicSettings.length();i++){

                    JSONObject _obj = (JSONObject) _hardwareArray.get(i);

                    if(_obj.getBoolean("Enabled") == false){
                        Logger.AddData(_obj.getString("Name"), "Disabled!");
                        return;
                    }

                    UltrasonicSetting _ultra = new UltrasonicSetting();

                    _ultra.Name = _obj.getString("Name");
                    _ultra.Direction = _obj.getString("Direction");
                    _ultra.Offset = _obj.getDouble("Offset");

                    PositionSettings.UltraSettings.add(_ultra);
                    if(Hardware.get( _ultra.Name ) == null){
                        Logger.AddData(_obj.getString("Name"), "No Hardware!");
                        return;
                    }
                    Logger.AddData(_obj.getString("Name"), "Added!");
                    _ultra.Sensor = (UltrasonicSensor)Hardware.get( _ultra.Name );



                }

                Logger.AddData("STATUS", "Loaded: " + Steps.size());

            }catch (JSONException ex){
                Log.e("JSON", ex.getMessage());
            }


        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    public void StartProgram(){


        PosTimer.scheduleAtFixedRate(new TimerTask() {
            @Override
            public void run() {
                GetCoord();
            }
        }, 0, 10);//put here time 1000 milliseconds=1 second


        Logger.AddData("STATUS", "Start Program");
        Runtime.startTime();

        float LastTime;


        for(int i=0;i<Steps.size();i++){
            Step CurrentStep = Steps.get(i);

            Logger.AddData("CURRENT STEP", CurrentStep.Name + " - " + CurrentStep.Type);

            switch (CurrentStep.Type){
                case 1: // Waypoint
                    Blocking_MoveMotor(CurrentStep.CoordX, CurrentStep.CoordY , CurrentStep.Speed);
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

    double LastX = -1;
    double LastY = -1;



    public TitanVector GetCoord(){
        TitanVector pos = new TitanVector();
        if(PositionSettings.UltraEnabled){
            UltrasonicPosition _pos = new UltrasonicPosition(PositionSettings, Logger);
            _pos.GetPosition();

            pos =  _pos.GetPosition();
        }
        Logger.AddData("Position", pos.X + "/" + pos.Y);
        return pos;
    }

    public void Blocking_MoveMotor(double CoordX, double CoordY, double Speed){

       if(LastX == -1){
           LastX = Steps.get(0).CoordX;
           LastY = Steps.get(0).CoordY;
       }
        double DeltaX = CoordX-LastX;
        double DeltaY = CoordY-LastY;

        double DirMultiplyerX = DeltaX/DeltaY;
        double DirMulitplyerY = DeltaY/DeltaX;

        DirMultiplyerX -= Math.abs(DirMultiplyerX - DirMulitplyerY);
        DirMulitplyerY -= Math.abs(DirMultiplyerX - DirMulitplyerY);

        double EncoderX = (DeltaX * DirMultiplyerX)* TicksPerUnit;
        double EncoderY = (DeltaY *  DirMulitplyerY) * TicksPerUnit;

        Logger.AddData("MULTIPLIER",  DirMultiplyerX + "/" + DirMulitplyerY );
        Logger.AddData("DELTA",  DeltaX + "/" + DeltaY );
        Logger.AddData("ENCODER",  EncoderX + "/" + EncoderY );

        Map<String, Integer> MotorDirections = new HashMap<String, Integer>();
        ArrayList<String> MotorsTrack = new ArrayList<String>();
        Logger.AddData("MoveMotor",  EncoderX + "/" + EncoderY );
        if(EncoderX > 0){
            for(int i=0; i<DriveConfig.get("Forward").size();i++){
                MotorSetting _motor = DriveConfig.get("Forward").get(0);

                if(_motor.Value == 0){
                    return;
                }

                if(Hardware.get(_motor.Name) != null){
                    DcMotor _dcMotor = (DcMotor)Hardware.get(_motor.Name);
                    _dcMotor.setMode(DcMotor.RunMode.RUN_USING_ENCODER);
                    _dcMotor.setPower(Speed * DirMultiplyerX * _motor.Value);
                    _dcMotor.setTargetPosition(_dcMotor.getCurrentPosition() + (int)EncoderX);
                    MotorsTrack.add(_motor.Name);

                }


            }
        }

        if(EncoderY > 0){
            for(int i=0; i<DriveConfig.get("Right").size();i++){
                MotorSetting _motor = DriveConfig.get("Right").get(0);

                if(_motor.Value == 0){
                    return;
                }

                if(Hardware.get(_motor.Name) != null){
                    DcMotor _dcMotor = (DcMotor)Hardware.get(_motor.Name);
                    _dcMotor.setMode(DcMotor.RunMode.RUN_USING_ENCODER);
                    _dcMotor.setPower(Speed * DirMulitplyerY * _motor.Value);
                    _dcMotor.setTargetPosition(_dcMotor.getCurrentPosition() + (int)EncoderY);
                    MotorsTrack.add(_motor.Name);

                }



            }
        }
        LastX = CoordX;
        LastY = CoordY;

        while(MotorsBusy(MotorsTrack, false)){

        }

    }


    public boolean MotorsBusy(ArrayList<String> Motors, boolean first){
        boolean isBusy = false;

        if(first){
            for(int i=0;i<Motors.size();i++){
                if(Hardware.get(Motors.get(i)) != null){
                    DcMotor _motor = (DcMotor)Hardware.get((Motors.get(i)));
                    if(_motor.isBusy() == false){
                        isBusy = false;
                    }

                }

            }
        }else{
            for(int i=0;i<Motors.size();i++){
                if(Hardware.get(Motors.get(i)) != null){
                    DcMotor _motor = (DcMotor)Hardware.get((Motors.get(i)));
                    if(_motor.isBusy()){
                        isBusy = true;
                    }

                }

            }
        }
        return  isBusy;
    }
    public void Blocking_WaitTilTime(double time){
        while(opModeIsActive() && time > Runtime.seconds()){
            Logger.AddData("RUNTIME", Runtime.seconds() + "");
        }
    }



}
