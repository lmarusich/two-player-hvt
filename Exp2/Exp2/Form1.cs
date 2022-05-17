using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp2
{
    public partial class Form1 : Form
    {
        public static Socket m_socClient;
        public static string role;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void cmdConnect_Click(object sender, System.EventArgs e)
        {
            try
            {
                //create a new client socket ...
                m_socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                String szIPSelected = txtIPAddress.Text;
                String szPort = "8221";
                int alPort = System.Convert.ToInt16(szPort, 10);

                System.Net.IPAddress remoteIPAddress = System.Net.IPAddress.Parse(szIPSelected);
                System.Net.IPEndPoint remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);
                m_socClient.Connect(remoteEndPoint);
                String szData = "Connected";
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(szData);
                m_socClient.Send(byData);
                Thread.Sleep(1000);
                if (m_socClient.Available > 0)
                {
                    byte[] buffer = new byte[1024];
                    int iRx = m_socClient.Receive(buffer, m_socClient.Available, SocketFlags.None);
                    string incoming = Encoding.UTF8.GetString(buffer);
                    if ((incoming.Length > 3) && (incoming.Substring(0, 3) == "tak"))
                    {
                        if (incoming.Substring(5, 5) == "Intel") { s2Button.Enabled = false; }
                        if (incoming.Substring(5, 3) == "OPS") { s3Button.Enabled = false; }
                    }
                }
                timer1.Start();
                panel1.Enabled = false;
                panel3.Visible = true;
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void roleButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == s3Button)
            {
                role = "OPS";
                this.BackColor = Color.Green;
            }
            else
            {
                role = "Intel";
                this.BackColor = Color.Blue;
            }
            panel3.Enabled = false;
            try
            {
                Object objData = "role" + role;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                m_socClient.Send(byData);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
            panel2.Visible = true;
            idTextBox.Focus();
            timer1.Stop();
            
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            if (idTextBox.Text.Length > 0)
                startButton.Enabled = true;
            else
                startButton.Enabled = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                Object objData = "start" + idTextBox.Text;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                m_socClient.Send(byData);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

            Form2 newForm2 = new Form2();
            this.Text = "Running";
            this.Height = 100;
            panel1.Visible = false;
            newForm2.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_socClient.Available > 0)
            {
                byte[] buffer = new byte[1024];
                int iRx = m_socClient.Receive(buffer, m_socClient.Available, SocketFlags.None);
                string incoming = Encoding.UTF8.GetString(buffer);
                if ((incoming.Length > 3) && (incoming.Substring(0, 3) == "tak"))
                {
                    if (incoming.Substring(5, 5) == "Intel") { s2Button.Enabled = false; }
                    if (incoming.Substring(5, 3) == "OPS") { s3Button.Enabled = false; }
                }
            }
        }

    }
}
