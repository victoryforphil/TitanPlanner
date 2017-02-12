using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;

namespace TitanPlanner
{
    public partial class TitanLogger : Form
    {
        public class LogArray
        {
            public LogItem[] Items;
        }
        public class LogItem
        {
            public string key = null;
            public string data = null;
        }

        delegate void SetTextCallback(string text);
        delegate void ServerConnectedLabel();
        delegate void PhoneConnectedLabel();
        TcpListener listener;
        TcpClient client;
        NetworkStream ns;
        Thread t = null;

        public TitanLogger()
        {

            InitializeComponent();
            label_phonestatus.Text = "Phone Disconnected!";
            label_phonestatus.ForeColor = Color.Red;
            label_serverstatus.Text = "Server Offline";
            label_serverstatus.ForeColor = Color.Red;

        }

        public void ServerStaredLabel()
        {
            if (this.label_serverstatus.InvokeRequired)
            {
                ServerConnectedLabel d = new ServerConnectedLabel(ServerStaredLabel);
                this.Invoke(d, new object[] {});
            }
            else
            {
                label_serverstatus.Text = "Server Started";
                label_serverstatus.ForeColor = Color.Green;

            }
        }

        public void PhoneConnected()
        {
            if (this.label_phonestatus.InvokeRequired)
            {
                PhoneConnectedLabel d = new PhoneConnectedLabel(PhoneConnected);
                this.Invoke(d, new object[] { });
            }
            else
            {
                label_phonestatus.Text = "Phone Connected!";
                label_phonestatus.ForeColor = Color.Green;

            }
        }

        public void DoWork()
        {
            listener = new TcpListener(7777);
            
          
            listener.Start();
            ServerStaredLabel();
            
            try
            {
                client = listener.AcceptTcpClient();
            }
            catch (Exception e)
            {
                return;
            }

            Console.WriteLine("Client Connected");
            PhoneConnected();
            if(client == null)
            {
                return;
            }
            ns = client.GetStream();
            
            byte[] bytes = new byte[1024];
            int i;
            while (client.Connected)
            {
                try
                {
                    client.Client.Receive(bytes);
                    this.SetText(Encoding.ASCII.GetString(bytes));

                    bytes = new byte[1024];
                }catch(Exception e)
                {

                }
            }
        }
        private void SetText(string text)
        {

            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.listBox_logs.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                
                LogItem[] Items = JsonConvert.DeserializeObject<LogItem[]>(text);
                if(Items == null)
                {
                    return;
                }
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i].key != null)
                    {
                        if (listBox_logs.Items.Count <= i)
                        {
                            listBox_logs.Items.Add(Items[i].key + " - " + Items[i].data);
                        }
                        else
                        {
                            listBox_logs.Items[i] = Items[i].key + " - " + Items[i].data;
                        }
                    }
                }



            }
        }

        private void label_phonestatus_Click(object sender, EventArgs e)
        {

        }

      

        private void label_serverstatus_Click(object sender, EventArgs e)
        {

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            t = new Thread(DoWork);
            if (button_start.Text == "Stop Server")
            {
                button_start.Text = "Start Server";
                label_phonestatus.Text = "Phone Disconnected!";
                label_phonestatus.ForeColor = Color.Red;
                label_serverstatus.Text = "Server Offline";
                label_serverstatus.ForeColor = Color.Red;
                listener.Stop();
                if (client != null)
                {
                    client.Close();
                }
                t.Abort();
            }
            else
            {
                button_start.Text = "Stop Server";
                t.Start();
               
            }
           
            
            
        }
        
        private void listBox_logs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TitanLogger_FormClosing(object sender, FormClosingEventArgs e)
        {
            button_start.Text = "Start Server";
            label_phonestatus.Text = "Phone Disconnected!";
            label_phonestatus.ForeColor = Color.Red;
            label_serverstatus.Text = "Server Offline";
            label_serverstatus.ForeColor = Color.Red;
            if (listener != null)
            {
                listener.Stop();
            }
            if (client != null)
            {
                client.Close();
            }

            if (t != null)
            {
                t.Abort();
            }
        }
    }
}
