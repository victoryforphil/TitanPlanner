package org.firstinspires.ftc.teamcode;

import android.media.MediaPlayer;

import com.qualcomm.robotcore.eventloop.opmode.Autonomous;
import com.qualcomm.robotcore.hardware.DcMotor;
import com.qualcomm.robotcore.hardware.GyroSensor;
import com.qualcomm.robotcore.util.ElapsedTime;

import org.lasarobotics.vision.android.Cameras;
import org.lasarobotics.vision.ftc.resq.Beacon;
import org.lasarobotics.vision.opmode.LinearVisionOpMode;
import org.lasarobotics.vision.opmode.extensions.CameraControlExtension;
import org.lasarobotics.vision.util.ScreenOrientation;
import org.opencv.core.Size;

/**
 * Created by Titan Apex on 2/20/2017.
 */
@Autonomous(name="Titan Backup | Blue Corner", group="Backup")
public class TitanAuto_Blue_Corner extends LinearVisionOpMode {
    private ElapsedTime runtime = new ElapsedTime();
    private DcMotor frontLeft = null;
    private DcMotor frontRight = null;
    private DcMotor rearLeft = null;
    private DcMotor rearRight = null;

    private GyroSensor gyro = null;
    MediaPlayer media_pacmac_start = null;
    MediaPlayer media_backup = null;
    @Override
    public void runOpMode() throws InterruptedException {

        telemetry.addData("Status", "Waiting for Vision");
        telemetry.update();



        waitForVisionStart();
        this.setCamera(Cameras.PRIMARY);

        this.setFrameSize(new Size(500, 500));


        enableExtension(Extensions.BEACON);         //Beacon detection
        enableExtension(Extensions.ROTATION);       //Automatic screen rotation correction
        enableExtension(Extensions.CAMERA_CONTROL); //Manual camera control

        beacon.setAnalysisMethod(Beacon.AnalysisMethod.FAST);

        beacon.setColorToleranceRed(0);
        beacon.setColorToleranceBlue(0);

        rotation.setIsUsingSecondaryCamera(false);
        rotation.disableAutoRotate();
        rotation.setActivityOrientationFixed(ScreenOrientation.PORTRAIT);

        cameraControl.setColorTemperature(CameraControlExtension.ColorTemperature.AUTO);
        cameraControl.setAutoExposureCompensation();


        telemetry.addData("Status", "Init Motors");
        telemetry.update();


        media_pacmac_start = MediaPlayer.create(hardwareMap.appContext, R.raw.pacman_start);
        media_backup = MediaPlayer.create(hardwareMap.appContext, R.raw.backing_up);

        gyro = hardwareMap.gyroSensor.get("Gyro");
        gyro.calibrate();

        while(gyro.isCalibrating()){
            telemetry.addData("Status", "Calibrating...");
            telemetry.update();
        }

        frontLeft  = hardwareMap.dcMotor.get("FrontLeft");
        frontRight = hardwareMap.dcMotor.get("FrontRight");

        rearLeft   = hardwareMap.dcMotor.get("RearLeft");
        rearRight  = hardwareMap.dcMotor.get("RearRight");


        frontLeft.setMode(DcMotor.RunMode.STOP_AND_RESET_ENCODER);
        frontRight.setMode(DcMotor.RunMode.STOP_AND_RESET_ENCODER);
        rearLeft.setMode(DcMotor.RunMode.STOP_AND_RESET_ENCODER);
        rearRight.setMode(DcMotor.RunMode.STOP_AND_RESET_ENCODER);

        frontLeft.setPower(0);
        frontRight.setPower(0);
        rearLeft.setPower(0);
        rearRight.setPower(0);


        telemetry.addData("Status", "Wait for start");
        telemetry.update();
        waitForStart();

        telemetry.addData("Status", "Playing..");
        telemetry.update();
        if(opModeIsActive()){
            media_pacmac_start.start();
            frontLeft.setMode(DcMotor.RunMode.RUN_TO_POSITION);
            frontRight.setMode(DcMotor.RunMode.RUN_TO_POSITION);
            rearLeft.setMode(DcMotor.RunMode.RUN_TO_POSITION);
            rearRight.setMode(DcMotor.RunMode.RUN_TO_POSITION);

            Turn(45, 0.5);

            RunMotor(frontLeft, -6000, 1);
            RunMotor(rearRight, 6000,1);

            while(opModeIsActive() && (frontLeft.isBusy() && rearRight.isBusy())){
                telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                telemetry.update();
            }

            Turn(90, 0.4);


            WaitTilTime(1);
            boolean rightBlue = false;
            rightBlue = beacon.getAnalysis().isRightBlue();

            if(rightBlue){
                RunMotor(frontLeft,  -1000, 0.3);
                RunMotor(frontRight, -1000, 0.3);
                RunMotor(rearRight, 1000,0.3);
                RunMotor(rearLeft, 1000,0.3);
                while(opModeIsActive() && (rearRight.isBusy() && rearLeft.isBusy() && frontRight.isBusy() && rearRight.isBusy())){
                    telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                    telemetry.update();
                }
                Turn(90, 0.5);
            }

            media_pacmac_start.stop();
            media_backup.start();
            RunMotor(frontLeft, -2300, 0.4);
            RunMotor(frontRight, 2300, 0.4);
            RunMotor(rearRight, 2300,0.4);
            RunMotor(rearLeft, -2300,0.4);

            while(opModeIsActive() && (rearRight.isBusy() && rearLeft.isBusy() && frontRight.isBusy() && rearRight.isBusy())){
                telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                telemetry.update();
            }


            RunMotor(frontLeft, 2300, 0.7);
            RunMotor(frontRight, -2300, 0.7);
            RunMotor(rearRight, -2300,0.7);
            RunMotor(rearLeft, 2300,0.7);

            while(opModeIsActive() && (rearRight.isBusy() && rearLeft.isBusy() && frontRight.isBusy() && rearRight.isBusy())){
                telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                telemetry.update();
            }
            media_backup.stop();



            if(rightBlue){
                RunMotor(frontLeft,  1000, 0.3);
                RunMotor(frontRight, 1000, 0.3);
                RunMotor(rearRight, -1000,0.3);
                RunMotor(rearLeft, -1000,0.3);
                while(opModeIsActive() &&(rearRight.isBusy() && rearLeft.isBusy() && frontRight.isBusy() && rearRight.isBusy())){
                    telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                    telemetry.update();
                }

            }

            Turn(50, 0.3);



            RunMotor(frontRight, 5350, 1);
            RunMotor(rearLeft,-5350,1);
            while(opModeIsActive() && ( rearLeft.isBusy() && frontRight.isBusy())){
                telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                telemetry.update();
            };

            Turn(90, 0.4);

            WaitTilTime(1);

            rightBlue = beacon.getAnalysis().isRightBlue();


            if(rightBlue){
                RunMotor(frontLeft,  -1200,  0.5);
                RunMotor(frontRight, -1200,  0.5);
                RunMotor(rearRight, 1200, 0.5);
                RunMotor(rearLeft, 1200,0.3);
                while(opModeIsActive() &&(rearRight.isBusy() && rearLeft.isBusy() && frontRight.isBusy() && rearRight.isBusy())){
                    telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                    telemetry.update();
                }

                Turn(90, 0.4);

            }

            RunMotor(frontLeft, -3100,  0.5);
            RunMotor(frontRight, 3100,  0.5);
            RunMotor(rearRight, 3100, 0.5);
            RunMotor(rearLeft, -3100, 0.5);

            while(opModeIsActive() &&(rearRight.isBusy() && rearLeft.isBusy() && frontRight.isBusy() && rearRight.isBusy())){
                telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                telemetry.update();
            }

            media_backup.start();
            RunMotor(frontLeft, 3400,  0.5);
            RunMotor(frontRight, -3400,  0.5);
            RunMotor(rearRight, -3400, 0.5);
            RunMotor(rearLeft, 3400, 0.5);

            while(opModeIsActive() && (rearRight.isBusy() && rearLeft.isBusy() && frontRight.isBusy() && rearRight.isBusy())){
                telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                telemetry.update();
            }
            media_backup.stop();


            if(rightBlue){
                RunMotor(frontLeft,  1200,  0.5);
                RunMotor(frontRight, 1200,  0.5);
                RunMotor(rearRight, -1200, 0.5);
                RunMotor(rearLeft, -1200, 0.5);
                while(opModeIsActive() &&(rearRight.isBusy() && rearLeft.isBusy() && frontRight.isBusy() && rearRight.isBusy())){
                    telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                    telemetry.update();
                }

            }

            Turn(150, 0.5);


            RunMotor(frontLeft, -6800, 1);
            RunMotor(rearRight, 6800,1);

            while(opModeIsActive() && (frontLeft.isBusy() && rearRight.isBusy())){
                telemetry.addData("Encoder: ",frontLeft.getCurrentPosition() + "/"+rearRight.getCurrentPosition());
                telemetry.update();
            }


        }

    }

    private void WaitTilTime(double time)
    {
        runtime.reset();
        while (runtime.seconds() < time){}
    }
    private void RunMotor(DcMotor _motor, int tickCount, double _speed){
        int targetPos = tickCount + _motor.getCurrentPosition();
        _motor.setTargetPosition(targetPos);
        _motor.setPower(_speed);
    }


    private void Turn(int angle, double speed)
    {
        frontLeft.setMode(DcMotor.RunMode.RUN_USING_ENCODER);
        frontRight.setMode(DcMotor.RunMode.RUN_USING_ENCODER);
        rearLeft.setMode(DcMotor.RunMode.RUN_USING_ENCODER);
        rearRight.setMode(DcMotor.RunMode.RUN_USING_ENCODER);


        double CurrentHeading = gyro.getHeading();

        if(CurrentHeading > 180){
            CurrentHeading = CurrentHeading - 360;
        }

        while(opModeIsActive() && CurrentHeading != angle )
        {
            CurrentHeading = gyro.getHeading();
            if(CurrentHeading > 180){
                CurrentHeading = CurrentHeading - 360;
            }

            telemetry.addData("Gyro", gyro.getHeading());
            telemetry.update();
            double MotorPower = speed;

            if(CurrentHeading > angle) {
                MotorPower = MotorPower * -1;
            }


            if(Math.abs(angle -CurrentHeading) <= 15){
                MotorPower = MotorPower * 0.25;
                telemetry.addData("Gyro Speed", "REDUCE SPEED");
                telemetry.update();
            }


            frontLeft.setPower(MotorPower);
            frontRight.setPower(MotorPower);
            rearRight.setPower(MotorPower);
            rearLeft.setPower(MotorPower);

        }



        frontLeft.setPower(0);
        frontRight.setPower(0);
        rearRight.setPower(0);
        rearLeft.setPower(0);

        frontLeft.setMode(DcMotor.RunMode.RUN_TO_POSITION);
        frontRight.setMode(DcMotor.RunMode.RUN_TO_POSITION);
        rearLeft.setMode(DcMotor.RunMode.RUN_TO_POSITION);
        rearRight.setMode(DcMotor.RunMode.RUN_TO_POSITION);

    }



    private boolean MotorBusy()
    {
        boolean isBusy = false;

        if(frontLeft.isBusy()){
            isBusy = true;
        }

        if(frontRight.isBusy()){
            isBusy = true;
        }

        if(rearRight.isBusy()){
            isBusy = true;
        }

        if(rearLeft.isBusy()){
            isBusy = true;
        }

        return isBusy;
    }
}
