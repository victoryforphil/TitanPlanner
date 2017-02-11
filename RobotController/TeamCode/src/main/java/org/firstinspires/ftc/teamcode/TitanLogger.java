package org.firstinspires.ftc.teamcode;

import android.os.AsyncTask;

/**
 * Created by VictoryForPhil on 2/10/2017.
 */

public class TitanLogger {
    TCPClient mTcpClient;

    public void ConnectToServer(){
        new ConnectTask().execute("");
        if (mTcpClient != null) {
            mTcpClient.sendMessage("{'type':'CONNECTED','message':'Robot Connected!'");
        }else{

        }
    }
    public void SendData(String type, String data){
        if (mTcpClient != null) {
            mTcpClient.sendMessage("{'type':'"+type+"','message':'"+data+"'");
        }else{

        }

    }
    public class ConnectTask extends AsyncTask<String, String, TCPClient> {

        @Override
        protected TCPClient doInBackground(String... message) {

            //we create a TCPClient object
            mTcpClient = new TCPClient(new TCPClient.OnMessageReceived() {
                @Override
                //here the messageReceived method is implemented
                public void messageReceived(String message) {
                    //this method calls the onProgressUpdate
                    publishProgress(message);
                }
            });
            mTcpClient.run();

            return null;
        }

        @Override
        protected void onProgressUpdate(String... values) {
            super.onProgressUpdate(values);
            //response received from server

            //process server response here....

        }
    }
}
