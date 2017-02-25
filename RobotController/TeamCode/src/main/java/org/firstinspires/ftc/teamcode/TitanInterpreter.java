
package org.firstinspires.ftc.teamcode;

import android.content.res.AssetManager;
import android.util.Log;

import com.qualcomm.robotcore.eventloop.opmode.Autonomous;
import com.qualcomm.robotcore.eventloop.opmode.LinearOpMode;
import com.qualcomm.robotcore.hardware.DcMotor;
import com.qualcomm.robotcore.hardware.HardwareDevice;
import com.qualcomm.robotcore.hardware.UltrasonicSensor;
import com.qualcomm.robotcore.util.ElapsedTime;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;

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
        public TitanDenoiser Denoiser = new TitanDenoiser(3,10);
    }

    public class PositionSetting{
        public boolean UltraEnabled;
        public ArrayList<UltrasonicSetting> UltraSettings = new ArrayList<UltrasonicSetting>();
        public double FieldSize;
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
                        case "Gyro":
                            Hardware.put(name, hardwareMap.gyroSensor.get(name));
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
                PositionSettings.FieldSize = 365.7;
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

            pos =  GetUltrasonicPosition();
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

        DcMotor frontLeft = (DcMotor)Hardware.get("FrontLeft");
        DcMotor frontRight =  (DcMotor)Hardware.get("FrontRight");
        DcMotor rearLeft = (DcMotor)Hardware.get("ReartLeft");
        DcMotor rearRight =  (DcMotor)Hardware.get("RearRight");

        double X = DirMultiplyerX;
        double Y = DirMulitplyerY;
        double Z = 0;

        //frontLeft.setPower  (Y-X+Z);
        //frontRight.setPower (Y+X-Z);
       /// rearRight.setPower  (Y-X-Z);
        //rearLeft.setPower   (Y+X+Z);



        LastX = CoordX;
        LastY = CoordY;

        while(AtCoord(new TitanVector(CoordX, CoordY), 5)){

        }

    }

    public boolean AtCoord(TitanVector Target, double error){
        TitanVector _pos = GetCoord();

        boolean atTarget = true;

        if(Math.abs(_pos.X - Target.X) > error){
            atTarget = false;
        }

        if(Math.abs(_pos.Y - Target.Y) > error){
            atTarget = false;
        }

        return atTarget;
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


    public TitanVector GetUltrasonicPosition(){

        double FinalX = 0;
        double FinalY = 0;

        TitanVector Pos = new TitanVector();

        ArrayList<UltrasonicSetting> XAxisUltras = new ArrayList<>();
        ArrayList<UltrasonicSetting> YAxisUltras = new ArrayList<>();
        for(int i=0; i<PositionSettings.UltraSettings.size();i++){
            UltrasonicSetting _cur = PositionSettings.UltraSettings.get(i);

            if(_cur.Direction == "Left"){
                _cur.Offset = _cur.Offset * - 1;
                XAxisUltras.add(_cur);
            }

            if(_cur.Direction == "Right"){

                XAxisUltras.add(_cur);
            }

            if(_cur.Direction == "Backward"){
                _cur.Offset = _cur.Offset * -1 ;
                YAxisUltras.add(_cur);
            }

            if(_cur.Direction == "Forward"){
                YAxisUltras.add(_cur);
            }
        }



        TitanInterpreter.UltrasonicSetting ChoosenX = ChooseUltra(XAxisUltras);
        TitanInterpreter.UltrasonicSetting ChoosenY = ChooseUltra(YAxisUltras);

        ChoosenX.Denoiser.Update(ChoosenX.Sensor.getUltrasonicLevel());
        ChoosenY.Denoiser.Update(ChoosenY.Sensor.getUltrasonicLevel());

        FinalX = ( ChoosenX.Denoiser.GetValueDouble() + ChoosenX.Offset) * (PositionSettings.FieldSize / 1000);
        FinalY = ( ChoosenY.Denoiser.GetValueDouble() + ChoosenY.Offset)  * (PositionSettings.FieldSize / 1000);



        Pos.X = FinalX;
        Pos.Y = FinalY;
        Pos.isOverride = false;
        Logger.AddData("ULTRA POS", FinalX + "/" + FinalY);
        return Pos;
    }

    public TitanInterpreter.UltrasonicSetting ChooseUltra(ArrayList<TitanInterpreter.UltrasonicSetting> AxisUltra){
        Logger.AddData("Choosing", AxisUltra.get(0).Name);
        return AxisUltra.get(0);
    }


}
