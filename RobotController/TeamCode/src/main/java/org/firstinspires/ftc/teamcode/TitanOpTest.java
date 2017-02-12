
package org.firstinspires.ftc.teamcode;

import android.os.AsyncTask;
import android.util.Log;

import com.qualcomm.robotcore.eventloop.opmode.Autonomous;
import com.qualcomm.robotcore.eventloop.opmode.Disabled;
import com.qualcomm.robotcore.eventloop.opmode.LinearOpMode;
import com.qualcomm.robotcore.eventloop.opmode.TeleOp;
import com.qualcomm.robotcore.hardware.DcMotor;
import com.qualcomm.robotcore.util.ElapsedTime;

import com.qualcomm.robotcore.eventloop.opmode.LinearOpMode;
import com.qualcomm.robotcore.eventloop.opmode.TeleOp;
import com.qualcomm.robotcore.eventloop.opmode.Disabled;
import com.qualcomm.robotcore.hardware.DcMotor;
import com.qualcomm.robotcore.hardware.DcMotorSimple;
import com.qualcomm.robotcore.util.ElapsedTime;

import org.firstinspires.ftc.robotcore.external.Telemetry;


@Autonomous(name="Titan Planner", group="Linear Opmode")  // @Autonomous(...) is the other common choice

public class TitanOpTest extends LinearOpMode {


    private ElapsedTime runtime = new ElapsedTime();

    private TitanLogger Logger = new TitanLogger();
    @Override
    public void runOpMode() {
        telemetry.addData("Status", "Initialized");
        telemetry.update();
        Logger.ConnectToServer();

        waitForStart();
        runtime.reset();

        while (opModeIsActive()) {
            telemetry.addData("Status", "Run Time: " + runtime.seconds());
            telemetry.update();
            Logger.AddData("RUNTIME", runtime.toString());
            Logger.AddData("RUNTIME 2", runtime.toString());
        }

        Logger.Stop();
    }

}

