package org.firstinspires.ftc.teamcode;

import android.os.AsyncTask;
import android.util.Log;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.HashMap;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;

/**
 * Created by VictoryForPhil on 2/10/2017.
 */



public class TitanLogger {
    Map<String,String> CurrentData =  new HashMap<String,String>();


    CClient mClient = new CClient();
    Thread myThready = new Thread(mClient);
    Timer sendTimer = new Timer();
    int CurrentIndex;
    public void ConnectToServer() {
        myThready.start();
        sendTimer.scheduleAtFixedRate(new TimerTask() {
            @Override
            public void run() {
                SendData();
            }
        }, 1000, 500);//put here time 1000 milliseconds=1 second
    }

    public void SendData(){

        JSONArray finalData = new JSONArray();
        for (Map.Entry<String, String> entry : CurrentData.entrySet()){
            JSONObject newObj = new JSONObject();

            try {
                newObj.put("data",entry.getValue());
                newObj.put("key",entry.getKey());
                finalData.put(newObj);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }

        if(finalData.length() != 0){
            mClient.Send(finalData.toString());
        }
    }

    public void Stop(){
        sendTimer.cancel();

        mClient.Close();
    }
    public void AddData(String key, String data) {
        CurrentData.put(key, data);

    }


    public class CClient
            implements Runnable {
        private Socket socket;
        private String ServerIP = "192.168.1.82";


        public void run() {
            try {
                socket = new Socket(ServerIP, 7777);

            } catch (Exception e) {
                System.out.print("Whoops! It didn't work!:");
                System.out.print(e.getLocalizedMessage());
                System.out.print("\n");
            }
        }

        public void Send(String s) {
            try {
                PrintWriter outToServer = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()));
                Log.d("NETWORK", s);
                outToServer.print(s);
                outToServer.flush();


            } catch (UnknownHostException e) {
                System.out.print(e.toString());
            } catch (IOException e) {
                System.out.print(e.toString());
            } catch (Exception e) {
                System.out.print(e.toString());
            }

        }

        public void Close(){
            try {
                socket.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
