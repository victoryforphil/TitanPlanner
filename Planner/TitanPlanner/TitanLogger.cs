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
        TcpListener listener;
        TcpClient client;
        NetworkStream ns;
        Thread t = null;

        public TitanLogger()
        {

            InitializeComponent();

            
            
        }

        public void DoWork()
        {
            listener = new TcpListener(7777);
            listener.Start();
            client = listener.AcceptTcpClient();
            Console.WriteLine("Client Connectedd");
            
            ns = client.GetStream();
            
            byte[] bytes = new byte[1024];
            int i;
            while (true)
            {
                client.Client.Receive(bytes);
                this.SetText(Encoding.ASCII.GetString(bytes));

                bytes = new byte[256];
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
            t.Start();
        }

        private void listBox_logs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
