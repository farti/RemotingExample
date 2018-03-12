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

namespace RemotingGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HttpChannel channel = new HttpChannel(25000);
                ChannelServices.RegisterChannel(channel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingObject), "Remoting", WellKnownObjectMode.SingleCall);
                textBox1.Text = "Serwer oczekuje ...";
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd");
            }
        }
    }

}
