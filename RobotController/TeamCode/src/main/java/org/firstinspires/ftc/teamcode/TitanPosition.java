package org.firstinspires.ftc.teamcode;

import com.qualcomm.robotcore.hardware.UltrasonicSensor;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;


/**
 * Created by Titan Apex on 2/18/2017.
 */
import org.firstinspires.ftc.teamcode.TitanInterpreter.*;
public class TitanPosition {
    private PositionSetting Settings;
    public TitanLogger Logger;
    public TitanPosition(PositionSetting _setting,  TitanLogger _logger){

        Settings = _setting;
        Logger   = _logger;

    }

    public TitanVector GetPosition(){
        TitanVector pos = new TitanVector();

        return pos;
    }


}


