/*
Copyright (c) 2016 Robert Atkinson

All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted (subject to the limitations in the disclaimer below) provided that
the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list
of conditions and the following disclaimer.

Redistributions in binary form must reproduce the above copyright notice, this
list of conditions and the following disclaimer in the documentation and/or
other materials provided with the distribution.

Neither the name of Robert Atkinson nor the names of his contributors may be used to
endorse or promote products derived from this software without specific prior
written permission.

NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY THIS
LICENSE. THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESSFOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR
TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
package org.firstinspires.ftc.teamcode;

import android.media.MediaPlayer;

import com.qualcomm.robotcore.eventloop.opmode.Disabled;
import com.qualcomm.robotcore.eventloop.opmode.LinearOpMode;
import com.qualcomm.robotcore.eventloop.opmode.OpMode;
import com.qualcomm.robotcore.eventloop.opmode.TeleOp;
import com.qualcomm.robotcore.hardware.DcMotor;
import com.qualcomm.robotcore.hardware.DcMotorSimple;
import com.qualcomm.robotcore.util.ElapsedTime;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Timer;
import java.util.TimerTask;


@TeleOp(name="Titan Drive", group="Iterative Opmode")  // @Autonomous(...) is the other common choice

public class TitanTeleOp extends OpMode
{
    /* Declare OpMode members. */
    private ElapsedTime runtime = new ElapsedTime();
    private DcMotor frontLeft = null;
    private DcMotor frontRight = null;
    private DcMotor rearLeft = null;
    private DcMotor rearRight = null;

    private DcMotor leftLift = null;
    private DcMotor rightLift = null;

    private DcMotor leftGrab = null;
    private DcMotor rightGrab = null;


    private boolean isGrabLocked = false;
    private boolean isQuickReleasing = false;

    boolean DPad_Up_Reset = true;
    boolean DPad_Down_Reset = true;

    Timer Grabtimer = new Timer();

    private double Sensitivity = 1;

    private boolean Reversed = false;
    private double ResetReverse;

    MediaPlayer media_Sneaky = null;

    MediaPlayer media_RiseUp = null;
    MediaPlayer media_Drop = null;
    /*
     * Code to run ONCE when the driver hits INIT
     */
    @Override
    public void init() {
        telemetry.addData("Status", "Initialized");


        frontLeft  = hardwareMap.dcMotor.get("FrontLeft");
        frontRight = hardwareMap.dcMotor.get("FrontRight");

        frontRight.setDirection(DcMotorSimple.Direction.REVERSE );

        rearLeft   = hardwareMap.dcMotor.get("RearLeft");
        rearRight  = hardwareMap.dcMotor.get("RearRight");

        rearRight.setDirection(DcMotorSimple.Direction.REVERSE);

        leftLift   = hardwareMap.dcMotor.get("LeftLift");
        rightLift  = hardwareMap.dcMotor.get("RightLift");
        rightLift.setDirection(DcMotorSimple.Direction.REVERSE);

        leftGrab   = hardwareMap.dcMotor.get("LeftGrab");
        rightGrab  = hardwareMap.dcMotor.get("RightGrab");
        rightGrab.setDirection(DcMotorSimple.Direction.REVERSE);

        media_Sneaky = MediaPlayer.create(hardwareMap.appContext, R.raw.sneaky);
        media_RiseUp = MediaPlayer.create(hardwareMap.appContext, R.raw.rise_up);
        media_Drop = MediaPlayer.create(hardwareMap.appContext, R.raw.drop_the_bass);

    }

    /*
     * Code to run REPEATEDLY after the driver hits INIT, but before they hit PLAY
     */
    @Override
    public void init_loop() {

    }

    /*
     * Code to run ONCE when the driver hits PL+AY
     */
    @Override
    public void start() {
        runtime.reset();
    }

    /*
     * Code to run REPEATEDLY after the driver hits PLAY but before they hit STOP
     */
    @Override
    public void loop() {
        telemetry.addData("Status", "Running: " + runtime.toString());
        double X = gamepad1.left_stick_x * Sensitivity;
        double Y = gamepad1.left_stick_y * Sensitivity;
        double Z = gamepad1.right_stick_x  * Sensitivity;

        if(Sensitivity <= 0.60){
            Z = Z / 2;
        }

        if(Reversed){
            X = X * -1;
            Y = Y * -1;

        }

        frontLeft.setPower  ((Y-X+Z) );
        frontRight.setPower ((Y+X-Z)  );
        rearRight.setPower  ((Y-X-Z)  );
        rearLeft.setPower   ((Y+X+Z) );



        //Lift Controls
        if(gamepad2.start){
            if(media_Sneaky.isPlaying()){
                media_Sneaky.stop();
            }

            if(media_RiseUp.isPlaying()){
                media_RiseUp.stop();
            }

            media_RiseUp.start();
            media_RiseUp.setLooping(true);


        }
        leftLift.setPower(gamepad2.left_stick_y);
        rightLift.setPower(gamepad2.left_stick_y);

        telemetry.addData("Sensitiity", Sensitivity);
        telemetry.addData("Reversed", Reversed);


        if(gamepad2.a){
            isGrabLocked = true;

            media_Sneaky.start();
        }

        if(gamepad2.b){
            isGrabLocked = false;
        }

        if(gamepad1.y && runtime.seconds() > ResetReverse ){
            ResetReverse = runtime.seconds() + 0.5;
            Reversed = !Reversed;
        }


        if(gamepad2.left_bumper ){
            leftGrab.setPower(-0.3);
        }else if(gamepad2.left_trigger > 0){
            leftGrab.setPower(0.3);
        }
        else if(isGrabLocked && !isQuickReleasing){
            leftGrab.setPower(0.4);
        }
        else if(isQuickReleasing && isGrabLocked){
            leftGrab.setPower(-0.2);
        }else{
            leftGrab.setPower(0);
        }

        if(gamepad2.right_bumper ){
            rightGrab.setPower(-0.3);
        }else if(gamepad2.right_trigger > 0) {
            rightGrab.setPower(0.3);
        }
        else if(isGrabLocked && !isQuickReleasing) {
            rightGrab.setPower(0.4);
        }else if(isQuickReleasing && isGrabLocked){

            rightGrab.setPower(-0.2);
        }else{
            rightGrab.setPower(0);
        }



        if(gamepad2.x && isGrabLocked){
            isQuickReleasing = true;
            if(media_RiseUp.isPlaying()){
                media_RiseUp.stop();
            }
            media_Drop.start();
            Grabtimer.schedule(new TimerTask() {
                @Override
                public void run() {
                    isQuickReleasing = false;
                    isGrabLocked = false;
                }
            }, 400);//put here time 1000 milliseconds=1 second
        }



        if(gamepad1.dpad_up && DPad_Up_Reset){ // DPAD-UP -> Up Sensitivity (10%)
            Sensitivity += 0.1;
            DPad_Up_Reset = false;
        }

        if(gamepad1.dpad_down && DPad_Down_Reset){ // DPAD-DOWN -> Up Sensitivity (10%)
            Sensitivity -= 0.1;
            DPad_Down_Reset = false;
        }

        if(!gamepad1.dpad_up && !DPad_Up_Reset){ // DPAD-UP Reset (Resets when DPAD is not pressed)
            DPad_Up_Reset = true;
        }

        if(!gamepad1.dpad_down && !DPad_Down_Reset){ // DPAD-DOWN Reset (Resets when DPAD is not pressed)
            DPad_Down_Reset = true;
        }




    }
    /*
     * Code to run ONCE after the driver hits STOP
     */
    @Override
    public void stop() {
        media_RiseUp.stop();
        media_Sneaky.stop();
        media_Drop.stop();
    }

}
