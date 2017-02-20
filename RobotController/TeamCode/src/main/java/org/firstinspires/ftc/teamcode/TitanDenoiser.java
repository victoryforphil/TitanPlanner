package org.firstinspires.ftc.teamcode;

import android.util.Log;

import java.util.ArrayList;

public class TitanDenoiser{
    private ArrayList<Double> AllValues = new ArrayList<Double>();
    private double CurrentValue;

    private int UpdateRate;

    private int CurrentTick = 0;

    private int OutlierCount = 0;
    private int OutlierMaxCount = 5;
    private double OutlierMax;


    public TitanDenoiser(int updateRate, float outlierMax){
        UpdateRate = updateRate;
        OutlierMax = outlierMax;
    }

    public void Update(double val){
        if(CurrentTick >= UpdateRate){
            AllValues.clear();
            CurrentTick = 0;
        }


        double lastVal = AllValues.get(AllValues.size() - 1);
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
        return  (float)CurrentValue;
    }

    public double GetValueDouble(){
        return CurrentValue;
    }
}