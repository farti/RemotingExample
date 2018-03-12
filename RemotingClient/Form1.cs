using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using RemotingExample;

namespace RemotingClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string address = textBox1.Text;
            if (!address.StartsWith("http://"))
            {
                address = "http://" + textBox1.Text;
            }
            int port = (int)numericUpDown1.Value;
            HttpClientChannel channel = null;
            try
            {
                channel = new HttpClientChannel();
                ChannelServices.RegisterChannel(channel, false);
                RemotingObject remotingObject = (RemotingObject)Activator.GetObject(typeof(RemotingObject), address + ":" + port.ToString()+"/Remoting");
                listBox1.Items.Add("Połączenie: " + address + ":" + port.ToString() + "/Remoting");
                listBox1.Items.Add(remotingObject.Test());
                ChannelServices.UnregisterChannel(channel);
                listBox1.Items.Add("Połączenie zakończone");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Błąd");
                listBox1.Items.Add("Połączenie przerwane");
                ChannelServices.UnregisterChannel(channel);
            }
        }
    }
}
