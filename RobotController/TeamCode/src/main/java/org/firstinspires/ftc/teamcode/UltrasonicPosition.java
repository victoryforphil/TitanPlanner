package org.firstinspires.ftc.teamcode;

import java.util.ArrayList;

public class UltrasonicPosition extends TitanPosition{
    public UltrasonicPosition(TitanInterpreter.PositionSetting _setting , TitanLogger _logger) {
        super(_setting, _logger);
    }

    @Override
    public TitanVector GetPosition() {

        double FinalX = 0;
        double FinalY = 0;

        TitanVector Pos = new TitanVector();

        ArrayList<TitanInterpreter.UltrasonicSetting> XAxisUltras = new ArrayList<TitanInterpreter.UltrasonicSetting>();

        for(int i=0; i<XAxisUltras.size();i++){
            TitanInterpreter.UltrasonicSetting _cur = XAxisUltras.get(i);

            if(_cur.Direction == "Left"){
                _cur.Offset = _cur.Offset * - 1;
                XAxisUltras.add(_cur);
            }

            if(_cur.Direction == "Right"){

                XAxisUltras.add(_cur);
            }
        }

        ArrayList<TitanInterpreter.UltrasonicSetting> YAxisUltras = new ArrayList<TitanInterpreter.UltrasonicSetting>();

        for(int i=0; i<YAxisUltras.size();i++){
            TitanInterpreter.UltrasonicSetting _cur = YAxisUltras.get(i);

            if(_cur.Direction == "Backward"){
                _cur.Offset = _cur.Offset * -1 ;
                XAxisUltras.add(_cur);
            }

            if(_cur.Direction == "Forward"){
                XAxisUltras.add(_cur);
            }
        }

        TitanInterpreter.UltrasonicSetting ChoosenX = ChooseUltra(XAxisUltras);
        TitanInterpreter.UltrasonicSetting ChoosenY = ChooseUltra(YAxisUltras);



        FinalX = ChoosenX.Sensor.getUltrasonicLevel() + ChoosenX.Offset;
        FinalY = ChoosenY.Sensor.getUltrasonicLevel() + ChoosenY.Offset;



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
