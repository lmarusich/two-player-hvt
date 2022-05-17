using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.IO;

namespace Exp2Server
{
    public partial class Form1 : Form
    {
        //output files
        List<string> filePaths = new List<string>();
        string savePath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

        //icons
        List<System.Drawing.Image> plticons = new List<System.Drawing.Image>() { Exp2Server.Properties.Resources.plt01, Exp2Server.Properties.Resources.plt02, Exp2Server.Properties.Resources.plt03, Exp2Server.Properties.Resources.plt04 };
        System.Drawing.Bitmap hvticon = new Bitmap(Exp2Server.Properties.Resources.hvticon, 25, 25);

        //source accuracy
        bool sourceReliability = true;
        double source1 = 1;
        double source2 = 1;
        int whichSource = 1;
        int whichSourceCount = -1;
        int reliabilityInfo = 0;
        List<string> reliabilityList = new List<string>() { "none", "congruent", "incongruent" };
        int whichAccurate = -99;

        int condition = 3;
        string shared = "limited";
        int nrows = 14;
        int nhvts = 12;
        int lastNotification = -10;
        int intelNotifications = 0;
        int btwHvtTime = -99;
        int btwMsgTime = -99;
        int nMsgs = -99;
        bool scrolling = false;
        string savedtext = "";
        Random randomizer = new Random();

        List<string> rowNames = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" };
        List<string> colNames = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14" };

        Point[,] pointArray = new Point[14, 14];

        List<unit> unitList = new List<unit>();
        List<target> hvtList = new List<target>();

        RTFScrolledBottom intelRichTB2 = new RTFScrolledBottom();

        public Socket m_socListener;

        client client1;
        client client2;

        int nconnect = 0;
        int intTime = 0;
        int nsecs = 0;
        int nmins = 0;
        int nhours = 0;

        List<Label> statusLabels = new List<Label>();

        public Form1()
        {
            InitializeComponent();
            listenForConnections();
            SetupMap();
            textBox1.Text = savePath;
        }

        private void listenForConnections()
        {
            try
            {
                int ipnum = 8221;
                m_socListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, ipnum);
                m_socListener.Bind(ipLocal);
                m_socListener.Listen(4);
                m_socListener.BeginAccept(new AsyncCallback(OnClientConnect), null);
                timer1.Start();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                if (nconnect == 0)
                {
                    Socket m_socWorker = m_socListener.EndAccept(asyn);
                    Object objData = "successful connect";
                    byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                    m_socWorker.Send(byData);
                    client1 = new client();
                    client2 = new client();
                    client1.socket = m_socWorker;
                    nconnect++;
                    m_socListener.Close();
                    listenForConnections();
                }
                else
                {
                    Socket m_socWorker2 = m_socListener.EndAccept(asyn);
                    client2.socket = m_socWorker2;
                    nconnect++;
                    if (client1.role != null)
                        ReserveRole(client1, client2);
                }
            }
            catch (ObjectDisposedException)
            {
                m_socListener.Close();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
                m_socListener.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((s2statusLabel.Text == "Ready") && (s3statusLabel.Text == "Ready") && (timer2.Enabled == false))
                startButton.Enabled = true;

            if (client1 != null)
            {
                if (client1.socket.Available > 0)
                {
                    string szData = GetIncoming(client1.socket);
                    ProcessIncoming(client1, client2, szData);
                }
            }

            if ((client2 != null) && (client2.socket != null))
            {
                if (client2.socket.Available > 0)
                {
                    string szData = GetIncoming(client2.socket);
                    ProcessIncoming(client2, client1, szData);
                }
            }
        }

        private string GetIncoming(Socket whichWorker)
        {
            byte[] buffer = new byte[1024];
            int iRx = whichWorker.Receive(buffer);

            char[] chars = new char[iRx];
            System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
            int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
            System.String szData = new System.String(chars);
            return (szData);
        }

        private void ProcessIncoming(client whichClient, client otherClient, string incoming)
        {
            if ((incoming.Length > 3) && (incoming.Substring(0, 4) == "role"))
            {
                if (otherClient.role == null)
                {
                    whichClient.role = incoming.Substring(4);

                    if (whichClient.role == "Intel")
                    {
                        otherClient.role = "OPS";
                        whichClient.whichLabel = s2statusLabel;
                        otherClient.whichLabel = s3statusLabel;
                    }
                    else
                    {
                        otherClient.role = "Intel";
                        whichClient.whichLabel = s3statusLabel;
                        otherClient.whichLabel = s2statusLabel;
                    }

                    if (otherClient.socket != null)
                        ReserveRole(whichClient, otherClient);
                }
                txtDataRx.AppendText(whichClient.role + ": Connected" + "\r\n");
                whichClient.whichLabel.Text = "Connected";
                whichClient.whichLabel.BackColor = Color.LightYellow;
            }
            else if ((incoming.Length > 4) && (incoming.Substring(0, 5) == "start"))
            {
                txtDataRx.AppendText(whichClient.role + ": Start" + "\r\n");
                whichClient.whichLabel.Text = "Ready";
                whichClient.whichLabel.BackColor = Color.LightGreen;
                whichClient.id = incoming.Substring(5);
            }
            else
            {
                string[] msgs = Regex.Split(incoming, "##");
                for (int i = 0; i < msgs.Length; i++)
                {

                    if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "c"))//chat message
                    {
                        txtDataRx.AppendText(whichClient.role + ": " + msgs[i].Substring(1) + "\r\n");
                        Object objData = "##c" + whichClient.role + ": " + msgs[i].Substring(1);
                        byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                        if (otherClient.socket != null)
                            otherClient.socket.Send(byData);
                        using (StreamWriter sw = File.AppendText(filePaths[4]))
                        {sw.WriteLine(whichClient.role + "," + intTime + "," + msgs[i].Substring(1));}
                    }
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "g"))//new goal
                    {
                        int whichUnit = int.Parse(msgs[i].Substring(2, 1));
                        unitList[whichUnit].xfirst = int.Parse(msgs[i].Substring(1, 1));
                        unitList[whichUnit].pRowGoal = rowNames.IndexOf(msgs[i].Substring(3, 1).ToUpper());
                        unitList[whichUnit].pColGoal = colNames.IndexOf(msgs[i].Substring(4));
                        unitList[whichUnit].pStatus = "Moving";
                        startUnitMovement(whichUnit, unitList[whichUnit].pRowGoal, unitList[whichUnit].pColGoal);
                        using (StreamWriter sw = File.AppendText(filePaths[2]))
                        {sw.WriteLine("OPS,Assign Unit, " + intTime + "," + rowNames[unitList[whichUnit].pRowCurrent] + colNames[unitList[whichUnit].pColCurrent] + "," + rowNames[unitList[whichUnit].pRowGoal] + colNames[unitList[whichUnit].pColGoal] + "," + whichUnit);}
                        //send back out to other client
                        Object objData = "##" + msgs[i];
                        byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                        otherClient.socket.Send(byData);
                    }
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "s"))//unit stopped
                    {
                        int whichUnit = int.Parse(msgs[i].Substring(1));
                        unitList[whichUnit].pStatus = "stopped";
                        StopUnitMovement(whichUnit);
                        using (StreamWriter sw = File.AppendText(filePaths[2]))
                        {sw.WriteLine("OPS,Stop Unit, " + intTime + "," + rowNames[unitList[whichUnit].pRowCurrent] + colNames[unitList[whichUnit].pColCurrent] + ", ," + whichUnit);}
                    }
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "h"))//hvt icon changed
                    {
                        int temprow = rowNames.IndexOf(msgs[i].Substring(2, 1));
                        int tempcol = int.Parse(msgs[i].Substring(3));
                        if (msgs[i].Substring(1, 1) == "1")
                        {
                            insertLabel(temprow, tempcol);
                            using (StreamWriter sw = File.AppendText(filePaths[2]))
                            { sw.WriteLine("Intel,Add Icon, " + intTime + "," + rowNames[temprow] + colNames[tempcol] + ", "); }
                        }
                        else
                        {
                            Point loc = pointArray[tempcol, temprow];
                            foreach (Control p in mapPanel.Controls)
                                if ((p is Label) && (p.Location == new Point(23 + loc.X, 23 + loc.Y)))
                                    mapPanel.Controls.Remove(p);

                            using (StreamWriter sw = File.AppendText(filePaths[2]))
                            { sw.WriteLine("Intel,Remove Icon, " + intTime + "," + rowNames[temprow] + colNames[tempcol] + ", "); }

                        }
                        //send icon info to S3
                        Object objData = "##" + msgs[i];
                        byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                        if (client1.role == "OPS") { client1.socket.Send(byData); }
                        else { client2.socket.Send(byData); }
                    }
                    else if ((msgs[i].Length > 0) && (msgs[i].Substring(0, 1) == "k")) //user checks/unchecks a checkbox
                    {
                        using (StreamWriter sw = File.AppendText(filePaths[2]))
                        {
                            if (msgs[i].Substring(1, 1) == "1")
                            {
                                if (whichClient.role == "Intel")
                                {
                                    CheckBox cb = s2checkPanel.Controls[int.Parse(msgs[i].Substring(2)) - 1] as CheckBox;
                                    cb.Checked = true;
                                }
                                else
                                {
                                    CheckBox cb = s3checkPanel.Controls[int.Parse(msgs[i].Substring(2)) - 1] as CheckBox;
                                    cb.Checked = true;
                                }
                                sw.WriteLine(whichClient.role + ",Checked Box, " + intTime + "," + msgs[i].Substring(2) + ", , , , ");
                            }
                            else
                            {
                                if (whichClient.role == "Intel")
                                {
                                    CheckBox cb = s2checkPanel.Controls[int.Parse(msgs[i].Substring(2)) - 1] as CheckBox;
                                    cb.Checked = false;
                                }
                                else
                                {
                                    CheckBox cb = s3checkPanel.Controls[int.Parse(msgs[i].Substring(2)) - 1] as CheckBox;
                                    cb.Checked = false;
                                }
                                sw.WriteLine(whichClient.role + ",Unchecked Box, " + intTime + "," + msgs[i].Substring(2) + ", , , , ");
                            }
                        }
                    }
                    else if ((msgs[i].Length > 0) && (msgs[i].Substring(0, 1) == "q")) //user hits the quit button
                        endExperiment("Session Terminated");
                }
            }
        }
        private void ReserveRole(client whichClient, client otherClient)
        {
            Object objData = "taken" + whichClient.role;
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
            otherClient.socket.Send(byData);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //how many HVTs
            nhvts = int.Parse(comboBox1.Text);

            //is limited or shared selected
            if (radioButton2.Checked == true) { shared = "limited"; }
            if (radioButton3.Checked == true) { shared = "shared"; } 

            //are we doing source reliability
            if (sourceReliability == false)
            {
                if (c1radioButton.Checked == true) { condition = 1; }
                if (c2radioButton.Checked == true) { condition = 2; }
                if (c3radioButton.Checked == true) { condition = 3; }
            }
            if (sourceReliability == true)
            {
                condition = 0;
                if (radioButton4.Checked == true) { reliabilityInfo = 0; }
                if (radioButton5.Checked == true) { reliabilityInfo = 1; }
                if (radioButton1.Checked == true) { reliabilityInfo = 2; }

                //pick which source will be more accurate
                whichAccurate = randomizer.Next(2);
                if (whichAccurate == 0)
                {
                    source1 = 0.9;
                    source2 = 0.1;
                }
                if (whichAccurate == 1)
                {
                    source1 = 0.1;
                    source2 = 0.9;
                }
            }
            
            //make hvt variables the right size
            for (int l = 0; l < nhvts; l++)
            {
                target hvt = new target();
                hvt.hvtRowIndex = -99;
                hvt.hvtColIndex = -99;
                hvt.hvtOptDists = -99;
                hvt.hvtStartTime = -99;
                hvt.hvtLastMsgTime = -99;
                hvt.hvtnumMsgs = 0;
                hvt.hvtStatus = "inactive";
                hvtList.Add(hvt);
            }
            //progress bar
            hvtpbPlus.Max = nhvts;
            //checkboxes
            for (int j = 1; j <= nhvts; j++)
            {
                for (int k = 1; k <= 2; k++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Font = new Font("Arial", 8);
                    cb.Text = j.ToString();
                    if (k == 1)
                    {
                        //cb.Name = "s2cb" + j.ToString();
                        s2checkPanel.Controls.Add(cb, (j - 1) / 5, (j - 1) % 5);
                    }
                    else
                    {
                        //cb.Name = "s3cb" + j.ToString();
                        s3checkPanel.Controls.Add(cb, (j - 1) / 5, (j - 1) % 5);
                    }
                    cb.Dock = DockStyle.Fill;
                    var m = cb.Margin;
                    m.All = 0;
                    cb.Margin = m;
                }

            }

            //assign HVT positions
            assignHVTs();
            //set notification timing
            btwHvtTime = 18;
            if (condition == 0)
            {
                nMsgs = 4;
                btwMsgTime = 4;
            }
            else if (condition == 1)
            {
                nMsgs = 1;
                btwMsgTime = 16;
            }
            else if (condition == 2)
            {
                nMsgs = 5;
                btwMsgTime = 16 / (nMsgs - 1);
            }
            else
            {
                nMsgs = 9;
                btwMsgTime = 16 / (nMsgs - 1);
            }
            //make output files
            string practice = "";
            if (nhvts < 10)
                practice = ".PRACTICE";
            string filename = client1.id + "." + client2.id + "." + shared + "." + reliabilityList[reliabilityInfo] + ".RoundInfo" + practice + ".txt";
            filePaths.Add(Path.Combine(savePath, filename));

            filename = client1.id + "." + client2.id + "." + shared + "." + reliabilityList[reliabilityInfo] + ".Notifications" + practice + ".txt";
            filePaths.Add(Path.Combine(savePath, filename));
            using (StreamWriter sw = File.CreateText(filePaths[1])) { sw.WriteLine("Intel Notifications"); }
            filename = client1.id + "." + client2.id + "." + shared + "." + reliabilityList[reliabilityInfo] + ".DataMat" + practice + ".txt";
            filePaths.Add(Path.Combine(savePath, filename));
            using (StreamWriter sw = File.CreateText(filePaths[2])) { sw.WriteLine("ROLE,ACTION,TIME,LOCATION,GOAL LOCATION,UNIT"); }
            filename = client1.id + "." + client2.id + "." + shared + "." + reliabilityList[reliabilityInfo] + ".Data" + practice + ".txt";
            filePaths.Add(Path.Combine(savePath, filename));
            using (StreamWriter sw = File.CreateText(filePaths[3])) { sw.WriteLine("TARGET,TIME,DISTANCE,LOCATION"); }
            filename = client1.id + "." + client2.id + "." + shared + "." + reliabilityList[reliabilityInfo] + ".Chat" + practice + ".txt";
            filePaths.Add(Path.Combine(savePath, filename));
            using (StreamWriter sw = File.CreateText(filePaths[4])) { sw.WriteLine("SENDER,TIME,TEXT"); }

            timer2.Start();
            startButton.Enabled = false;
            startGame();
            foreach (Control x in panel1.Controls)
                x.Visible = false;

            panel2.Visible = true;
            s2checkPanel.Visible = true;
            s3checkPanel.Visible = true;
            
        }

        private void SetupMap()
        {


            //set up intel text box
            panel6.Controls.Add(intelRichTB2);
            intelRichTB2.thumbUp += intelRichTB2_thumbUp;
            intelRichTB2.thumbDown += intelRichTB2_thumbDown;
            intelRichTB2.BackColor = System.Drawing.Color.White;
            intelRichTB2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            intelRichTB2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            intelRichTB2.HideSelection = false;
            intelRichTB2.Location = new System.Drawing.Point(13, 35);
            intelRichTB2.Name = "intelRichTB2";
            intelRichTB2.ReadOnly = true;
            intelRichTB2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            intelRichTB2.ShowSelectionMargin = true;
            intelRichTB2.Size = new System.Drawing.Size(245, 321);
            intelRichTB2.TabIndex = 10;
            intelRichTB2.TabStop = false;
            intelRichTB2.Text = "";

            //set up units
            for (int i = 0; i < 4; i++)
            {
                unit plt = new unit();
                plt.pStatus = "At Base";
                plt.pLastMoveTime = -99;
                plt.xfirst = -99;
                unitList.Add(plt);
            }

            //set up grid
            mapPanel.BackgroundImage = Exp2Server.Properties.Resources.map11;

            for (int i = 0; i < nrows; i++)
                for (int j = 0; j < nrows; j++)
                    pointArray[i, j] = new Point(i * mapPanel.Width / nrows, j * mapPanel.Height / nrows);


            for (int i = nrows / 2 - 1; i < nrows / 2 + 1; i++)
            {
                for (int j = nrows / 2 - 1; j < nrows / 2 + 1; j++)
                {
                    insertPictureBox(i, j, 2 * i - nrows + 2 + j - nrows / 2 + 2);
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].pRowCurrent = i;
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].baseRow = i;
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].pColCurrent = j;
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].baseCol = j;
                }
            }

            for (int i = 1; i < nrows + 1; i++)
            {
                Label rowLabel = new Label();
                rowLabel.Location = new System.Drawing.Point(25, mapPanel.Size.Height / nrows * (i - 1) + mapPanel.Location.Y + mapPanel.Size.Height / nrows / 2 - 12);
                rowLabel.Font = new Font("Arial", 14);
                rowLabel.Text = rowNames[i - 1];
                Controls.Add(rowLabel);
                Label colLabel = new Label();
                colLabel.Location = new System.Drawing.Point(mapPanel.Size.Width / nrows * (i - 1) + mapPanel.Location.X + mapPanel.Size.Width / nrows / 2 - 10, 130);
                colLabel.Font = new Font("Arial", 14);
                colLabel.Text = colNames[i - 1];
                colLabel.AutoSize = true;
                Controls.Add(colLabel);
            }

            mapPanel.Visible = true;
            mapPanel.Paint += new PaintEventHandler(table_Paint);
        }

        private Label MakeNewLabel()
        {
            Label newLabel = new Label();
            newLabel.AutoSize = false;
            newLabel.Height = 25;
            newLabel.Width = 25;
            newLabel.Image = hvticon;
            //newLabel.Location = new Point(23, 23);
            return (newLabel);
        }

        private PictureBox MakeNewPB(int whichUnit)
        {
            PictureBox pb = new PictureBox();
            pb.BackColor = Color.Transparent;
            pb.Height = mapPanel.Size.Height / nrows / 2;
            pb.Width = mapPanel.Size.Height / nrows / 2;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Name = "pb" + whichUnit.ToString();
            pb.Image = plticons[whichUnit - 1];
            return (pb);
        }

        private void insertPictureBox(int rowindex, int colindex, int whichUnit)
        {
            Point loc = pointArray[colindex, rowindex];
            int npb = 0;
            foreach (Control p in mapPanel.Controls)
            {
                if ((p is PictureBox) && (p.Location == loc))
                {
                    PictureBox whichpb = p as PictureBox;
                    npb++;
                    whichpb.Image = plticons[whichUnit - 1];
                    whichpb.Name = "pb" + whichUnit.ToString();
                    break;
                }
            }
            if (npb == 0)
            {
                PictureBox newpb = MakeNewPB(whichUnit);
                newpb.Location = loc;
                mapPanel.Controls.Add(newpb);
            }
        }

        private void insertLabel(int temprow, int tempcol)
        {
            Point loc = pointArray[tempcol, temprow];
            int nlab = 0;
            foreach (Control p in mapPanel.Controls)
            {
                if ((p is Label) && (p.Location == new Point(loc.X + 23, loc.Y + 23)))
                {
                    nlab++;
                    break;
                }
            }
            if (nlab == 0)
            {
                Label newlabel = MakeNewLabel();
                newlabel.Location = new Point(loc.X + 23, loc.Y + 23);
                mapPanel.Controls.Add(newlabel);
            }
        }

        private void assignHVTs()
        {
            //random assignment of HVT locations
            List<int> offLimits = new List<int> { nrows / 2 - 2, nrows / 2 - 1, nrows / 2, nrows / 2 + 1 };

            for (int i = 0; i < nhvts; i++)
            {
                int inbase = 1;
                int randomCol = -99;
                int randomRow = -99;
                while (inbase == 1)
                {
                    randomCol = randomizer.Next(nrows);
                    randomRow = randomizer.Next(nrows);
                    inbase = 0;
                    if ((offLimits.Contains(randomCol)) && (offLimits.Contains(randomRow)))
                        inbase = 1;
                }
                hvtList[i].hvtColIndex = randomCol;
                hvtList[i].hvtRowIndex = randomRow;
                //compute time to capture
                int temptotdist = 0;
                for (int j = 0; j < 4; j++)
                {
                    int tempxdist = Math.Abs(hvtList[i].hvtRowIndex - unitList[j].baseRow);
                    int tempydist = Math.Abs(hvtList[i].hvtColIndex - unitList[j].baseCol);
                    temptotdist = temptotdist + tempxdist + tempydist;
                }
                temptotdist = temptotdist / 4;
                hvtList[i].hvtOptDists = temptotdist;
            }
        }

        private void startUnitMovement(int unitIndex, int rowGoal, int colGoal)
        {
            Point loc = pointArray[unitList[unitIndex].pColCurrent, unitList[unitIndex].pRowCurrent];
            //remove the picture box
            foreach (Control p in mapPanel.Controls)
            {
                if ((p is PictureBox) && (p.Location == loc))
                {
                    mapPanel.Controls.Remove(p);
                    //put it back if there was another unit there
                    for (int i = 0; i < 4; i++)
                        if ((unitList[i].pRowCurrent == unitList[unitIndex].pRowCurrent) && (unitList[i].pColCurrent == unitList[unitIndex].pColCurrent) && (i != unitIndex))
                            insertPictureBox(unitList[i].pRowCurrent, unitList[i].pColCurrent, i + 1);
                }
            }

            //send xfirst info
            Object objData = "##x" + unitIndex + unitList[unitIndex].xfirst;
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
            client1.socket.Send(byData);
            client2.socket.Send(byData);

            //update starting index
            unitList[unitIndex].pRowInitial = unitList[unitIndex].pRowCurrent;
            unitList[unitIndex].pColInitial = unitList[unitIndex].pColCurrent;

            mapPanel.Invalidate();

            //give spot report of initial movement
            string gridSquare = rowNames[unitList[unitIndex].pRowCurrent] + colNames[unitList[unitIndex].pColCurrent].ToString();
            unitRichTB.AppendText("PLT " + (unitIndex + 1) + ":  At " + gridSquare + " , Moving to " + rowNames[rowGoal] + colNames[colGoal].ToString() + "\r\n");
            objData = "##t" + "PLT " + (unitIndex + 1) + ":  At " + gridSquare + " , Moving to " + rowNames[rowGoal] + colNames[colGoal].ToString() + "\r\n";
            byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
            if (shared == "shared")
            {
                client1.socket.Send(byData);
                client2.socket.Send(byData);
            }
            else
            {
                if (client1.role == "OPS") { client1.socket.Send(byData); }
                else { client2.socket.Send(byData); }
            }
            unitList[unitIndex].pLastMoveTime = intTime;
        }
        private void table_Paint(object sender, PaintEventArgs e)
        {
            //Draw Grid
            Pen grayPen = new Pen(SystemColors.Control, 2);
            for (int i = 1; i < (nrows); i++)
            {
                e.Graphics.DrawLine(grayPen, pointArray[i, 0].X, 0, pointArray[i, 0].X, mapPanel.Height);
                e.Graphics.DrawLine(grayPen, 0, pointArray[0, i].Y, mapPanel.Width, pointArray[0, i].Y);
            }
            grayPen.Dispose();

            //figure out which units are moving (index of 0,1,2, or 3)
            for (int i = 0; i < 4; i++)
            {
                if ((unitList[i].pStatus == "Moving") || (unitList[i].pStatus == "Returning"))
                {
                    int unitIndex = i;
                    //Calculate arrow coordinates
                    Pen colorPen = new Pen(Color.Black, 6);
                    if (unitList[i].pStatus == "Moving")
                        colorPen.Color = Color.FromArgb(255, 255, 100);
                    else
                        colorPen.Color = Color.FromArgb(255, 50, 50);
                    colorPen.StartCap = LineCap.RoundAnchor;
                    colorPen.EndCap = LineCap.ArrowAnchor;

                    int x1 = unitList[unitIndex].pColInitial * mapPanel.Height / nrows + mapPanel.Height / nrows / 2;
                    int y1 = unitList[unitIndex].pRowInitial * mapPanel.Height / nrows + mapPanel.Height / nrows / 2;
                    int x2 = unitList[unitIndex].pColGoal * mapPanel.Width / nrows + mapPanel.Width / nrows / 2;
                    int y2 = unitList[unitIndex].pRowGoal * mapPanel.Height / nrows + mapPanel.Height / nrows / 2;

                    if (unitList[unitIndex].xfirst == 1)
                    {
                        e.Graphics.DrawLine(colorPen, x1, y1, x2, y1);
                        e.Graphics.DrawLine(colorPen, x2, y1, x2, y2);
                    }
                    else
                    {
                        e.Graphics.DrawLine(colorPen, x1, y1, x1, y2);
                        e.Graphics.DrawLine(colorPen, x1, y2, x2, y2);
                    }
                    colorPen.Dispose();
                }
            }
        }

        private void startGame()
        {
            Object objData = "##p" + nhvts.ToString() + "##l" + shared;
            if (sourceReliability == true)
            {
                objData = "##p" + nhvts.ToString() + "##l" + shared + "##z" + reliabilityInfo.ToString() + whichAccurate.ToString();
            }
            
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
            client1.socket.Send(byData);
            client2.socket.Send(byData);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            intTime++;
            ////update onscreen timer
            if (nsecs < 59) { nsecs++; }
            else
            {
                nsecs = 0;
                if (nmins < 59) { nmins++; }
                else
                {
                    nmins = 0;
                    nhours++;
                }
            }
            timeLabel.Text = "0" + nhours + ":";
            if (nmins < 10) { timeLabel.Text = timeLabel.Text + "0" + nmins + ":"; }
            else { timeLabel.Text = timeLabel.Text + nmins + ":"; }
            if (nsecs < 10) { timeLabel.Text = timeLabel.Text + "0" + nsecs; }
            else { timeLabel.Text = timeLabel.Text + nsecs; }

            //intel updating
            if ((intTime - lastNotification == btwHvtTime) && (intelNotifications < nhvts))
            {
                hvtList[intelNotifications].hvtStatus = "active";
                hvtList[intelNotifications].hvtStartTime = intTime;
                hvtNotify(intelNotifications);
                

                intelNotifications++;
                lastNotification = intTime;
            }

            for (int i = 0; i < nhvts; i++)
                if ((intTime - hvtList[i].hvtLastMsgTime == btwMsgTime) && (hvtList[i].hvtnumMsgs < nMsgs))
                    hvtNotify(i);
                    

            for (int i = 0; i < 4; i++)
            {
                if ((unitList[i].pStatus == "Moving") || (unitList[i].pStatus == "Returning"))
                    if ((intTime - unitList[i].pLastMoveTime == 3) && (unitList[i].pLastMoveTime >= 0))
                    {
                        updateUnitPosition(i);
                        if ((unitList[i].pRowCurrent == unitList[i].pRowGoal) && (unitList[i].pColCurrent == unitList[i].pColGoal))
                        {
                            if ((unitList[i].pRowCurrent == unitList[i].baseRow) && (unitList[i].pColCurrent == unitList[i].baseCol))
                                unitList[i].pStatus = "At Base";
                            else
                                unitList[i].pStatus = "Stopped";
                            unitRichTB.AppendText("PLT " + (i + 1) + ":  At " + rowNames[unitList[i].pRowGoal] + colNames[unitList[i].pColGoal].ToString() + "\r\n");
                            Object objData = "##t" + "PLT " + (i + 1) + ":  At " + rowNames[unitList[i].pRowGoal] + colNames[unitList[i].pColGoal].ToString() + "\r\n";
                            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                            if (shared == "shared")
                            {
                                client1.socket.Send(byData);
                                client2.socket.Send(byData);
                            }
                            else
                            {
                                if (client1.role == "OPS") { client1.socket.Send(byData); }
                                else { client2.socket.Send(byData); }
                            }
                            StopUnitMovement(i);
                        }
                        else
                            unitList[i].pLastMoveTime = intTime;
                        //if unit is on an hvt square and is not already returning, capture hvt
                        if (unitList[i].pStatus != "Returning")
                            for (int j = 0; j < hvtList.Count; j++)
                            {
                                if ((hvtList[j].hvtStatus == "active") && (unitList[i].pRowCurrent == hvtList[j].hvtRowIndex) && (unitList[i].pColCurrent == hvtList[j].hvtColIndex))
                                {
                                    hvtList[j].hvtStatus = "captured";
                                    int actualTime = intTime - hvtList[j].hvtStartTime;
                                    List<target> newList = hvtList.FindAll(delegate(target h) { return h.hvtStatus == "captured"; });
                                    unitRichTB.AppendText("PLT " + (i + 1) + ":  Captured HVT" + (j + 1) + " at " + rowNames[unitList[i].pRowCurrent] + colNames[unitList[i].pColCurrent].ToString() + "\r\n");

                                    hvtpbPlus.Value = hvtpbPlus.Value + 1;
                                    nhvtLabel.Text = newList.Count.ToString();
                                    
                                    Object objData = "##b" + newList.Count.ToString();
                                    byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                                    client1.socket.Send(byData);
                                    client2.socket.Send(byData);

                                    objData = "##t" + "PLT " + (i + 1) + ":  Captured HVT" + (j + 1) + " at " + rowNames[unitList[i].pRowCurrent] + colNames[unitList[i].pColCurrent].ToString() + "\r\n";
                                    byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                                    if (client1.role == "OPS") { client1.socket.Send(byData); }
                                    else { client2.socket.Send(byData); }
                                    returnUnit(i);
                                    using (StreamWriter sw = File.AppendText(filePaths[3]))
                                    { sw.WriteLine("HVT" + (j + 1).ToString() + "," + actualTime.ToString() + "," + hvtList[j].hvtOptDists + "," + rowNames[hvtList[j].hvtRowIndex] + colNames[hvtList[j].hvtColIndex]); }
                                    using (StreamWriter sw = File.AppendText(filePaths[2]))
                                    { sw.WriteLine(",,HVT" + (j + 1) + " Captured," + intTime + "," + rowNames[unitList[i].pRowCurrent] + colNames[unitList[i].pColCurrent] + ",," + i); }
                                }
                            }
                    }
            }
            //if all at base and all hvts captured, stop experiment
            if ((unitList.TrueForAll(s => s.pStatus == "At Base")) && (hvtList.TrueForAll(s => s.hvtStatus == "captured")))
                endExperiment("Finished");
        }

        private void endExperiment(string endType)
        {
            timer1.Stop();
            timer2.Stop();
            Object objData = "##d" + endType;
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
            client1.socket.Send(byData);
            client2.socket.Send(byData);
            using (StreamWriter sw = File.AppendText(filePaths[1]))
            {
                sw.Write(intelRichTB2.Text);
                sw.WriteLine("\r\n\r\nUnit Notifications\r\n");
                sw.Write(unitRichTB.Text);
            }
            using (StreamWriter sw = File.AppendText(filePaths[0]))
            {
                sw.WriteLine(client1.role + " Player ID: " + client1.id);
                sw.WriteLine(client2.role + " Player ID: " + client2.id);

                //shared/limited
                sw.WriteLine("Shared/Limited: " + shared.ToUpper());

                if (sourceReliability == true)
                {
                    sw.WriteLine("Sources Included");
                    
                    //actual source reliability
                    if (whichAccurate == 0)
                    {
                        sw.WriteLine("Source A: 0.9");
                        sw.WriteLine("Source B: 0.1");
                    }
                    if (whichAccurate == 1)
                    {
                        sw.WriteLine("Source A: 0.1");
                        sw.WriteLine("Source B: 0.9");
                    }
                    
                    //reliability info display
                    if (reliabilityInfo == 0)
                        sw.WriteLine("Reliability Info: NONE");
                    if (reliabilityInfo == 1)
                        sw.WriteLine("Reliability Info: CONGRUENT");
                    if (reliabilityInfo == 2)
                        sw.WriteLine("Reliability Info: INCONGRUENT");
                }
                //notification frequency
                sw.WriteLine("Time between targets: " + btwHvtTime.ToString());
                sw.WriteLine("Number of target updates: " + nMsgs.ToString());
                sw.WriteLine("Time between updates: " + btwMsgTime.ToString());

                //total time
                sw.WriteLine("Total Time: " + intTime.ToString());
                //actual locations
                sw.WriteLine("HVT Locations:");
                for (int i = 0; i < nhvts; i++)
                    sw.WriteLine(rowNames[hvtList[i].hvtRowIndex] + colNames[hvtList[i].hvtColIndex]);
            }
            MessageBox.Show(endType);
            this.Close();
        }
        private void updateUnitPosition(int whichUnit)
        {
            if (unitList[whichUnit].xfirst == 1)
            {
                if (unitList[whichUnit].pColCurrent > unitList[whichUnit].pColGoal) { unitList[whichUnit].pColCurrent--; }
                else if (unitList[whichUnit].pColCurrent < unitList[whichUnit].pColGoal) { unitList[whichUnit].pColCurrent++; }
                else
                {
                    if (unitList[whichUnit].pRowCurrent > unitList[whichUnit].pRowGoal) { unitList[whichUnit].pRowCurrent--; }
                    else if (unitList[whichUnit].pRowCurrent < unitList[whichUnit].pRowGoal) { unitList[whichUnit].pRowCurrent++; }
                }
            }
            if (unitList[whichUnit].xfirst == 0)
            {
                if (unitList[whichUnit].pRowCurrent > unitList[whichUnit].pRowGoal) { unitList[whichUnit].pRowCurrent--; }
                else if (unitList[whichUnit].pRowCurrent < unitList[whichUnit].pRowGoal) { unitList[whichUnit].pRowCurrent++; }
                else
                {
                    if (unitList[whichUnit].pColCurrent > unitList[whichUnit].pColGoal) { unitList[whichUnit].pColCurrent--; }
                    else if (unitList[whichUnit].pColCurrent < unitList[whichUnit].pColGoal) { unitList[whichUnit].pColCurrent++; }
                }
            }
        }
        private void StopUnitMovement(int whichUnit)
        {
            insertPictureBox(unitList[whichUnit].pRowCurrent, unitList[whichUnit].pColCurrent, whichUnit + 1);
            mapPanel.Invalidate();
            string stopType = "s";
            if (unitList[whichUnit].pStatus == "At Base") { stopType = "a"; }
            //send stopped info
            Object objData = "##s" + stopType + whichUnit.ToString() + rowNames[unitList[whichUnit].pRowCurrent] + unitList[whichUnit].pColCurrent.ToString();
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
            client1.socket.Send(byData);
            client2.socket.Send(byData);
        }
        private void returnUnit(int whichUnit)
        {
            unitList[whichUnit].pStatus = "Returning";
            unitList[whichUnit].pRowGoal = (whichUnit + nrows) / 2 - 1;
            unitList[whichUnit].pColGoal = whichUnit % 2 + nrows / 2 - 1;

            unitList[whichUnit].xfirst = randomizer.Next(2);

            Object objData = "##r" + unitList[whichUnit].xfirst + whichUnit.ToString() + rowNames[unitList[whichUnit].pRowCurrent] + unitList[whichUnit].pColCurrent.ToString();
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
            client1.socket.Send(byData);
            client2.socket.Send(byData);

            startUnitMovement(whichUnit, unitList[whichUnit].pRowGoal, unitList[whichUnit].pColGoal);
        }
        private void intelRichTB2_thumbUp(object sender, EventArgs e)
        {
            intelRichTB2.SelectAll();
            intelRichTB2.SelectionBackColor = Color.White;
            intelRichTB2.AppendText(savedtext);
            savedtext = "";
            scrolling = false;
        }
        private void intelRichTB2_thumbDown(object sender, EventArgs e)
        {
            scrolling = true;
        }
        //make sure new updates in textboxes are visible
        private void scrolltoBottom(object sender, EventArgs e)
        {
            RichTextBox scrolledTB = sender as RichTextBox;
            scrolledTB.ScrollToCaret();
        }

        //generate intel reports of sighted HVTs
        private void hvtNotify(int whichHvt)
        {
            
            hvtList[whichHvt].hvtnumMsgs++;
            hvtList[whichHvt].hvtLastMsgTime = intTime;
            if (hvtList[whichHvt].hvtStatus == "active")
            {
                int correct = 1; //if correct = 0, give accurate information.  if correct = 1, give inaccurate information.

                if (sourceReliability == true) //if we're doing source reliability, figure out sources
                {

                    whichSourceCount++;
                    if ((whichSourceCount % 2 == 0) && (whichSourceCount % 4 != 0))
                        whichSource = -1 * whichSource;
                    int correctIndex = randomizer.Next(10);

                    if (whichSource == 1)
                    {
                        double threshold = source1 * 10;
                        if (correctIndex < threshold)
                            correct = 0;
                    }
                    if (whichSource == -1)
                    {
                        double threshold = source2 * 10;
                        if (correctIndex < threshold)
                            correct = 0;
                    }
                }
                else
                {
                    correct = randomizer.Next(2);
                }

                int reportedRow = hvtList[whichHvt].hvtRowIndex;
                int reportedCol = hvtList[whichHvt].hvtColIndex;

                if (correct == 1)
                {
                    int incorrectType = randomizer.Next(4);

                    if ((incorrectType == 0))
                    {
                        if (hvtList[whichHvt].hvtRowIndex > 0)
                            reportedRow = hvtList[whichHvt].hvtRowIndex - 1;
                        else
                            reportedRow = hvtList[whichHvt].hvtRowIndex + 1;
                    }

                    if ((incorrectType == 1))
                    {
                        if (hvtList[whichHvt].hvtRowIndex < nrows - 1)
                            reportedRow = hvtList[whichHvt].hvtRowIndex + 1;
                        else
                            reportedRow = hvtList[whichHvt].hvtRowIndex - 1;
                    }
                    if ((incorrectType == 2))
                    {
                        if (hvtList[whichHvt].hvtColIndex > 0)
                            reportedCol = hvtList[whichHvt].hvtColIndex - 1;
                        else
                            reportedCol = hvtList[whichHvt].hvtColIndex + 1;
                    }
                    if ((incorrectType == 3))
                    {
                        if (hvtList[whichHvt].hvtColIndex < nrows - 1)
                            reportedCol = hvtList[whichHvt].hvtColIndex + 1;
                        else
                            reportedCol = hvtList[whichHvt].hvtColIndex - 1;
                    }
                }

                string update = "";
                if (sourceReliability == true)
                {
                    if (whichSource == 1)
                    {
                        update = "\r\nSource A: HVT " + (whichHvt + 1).ToString() + " sighted at " + rowNames[reportedRow] + colNames[reportedCol].ToString();
                    }
                    else
                    {
                        update = "\r\nSource B: HVT " + (whichHvt + 1).ToString() + " sighted at " + rowNames[reportedRow] + colNames[reportedCol].ToString();
                    }
                }
                else
                {
                    update = "\r\nHVT " + (whichHvt + 1).ToString() + " sighted at " + rowNames[reportedRow] + colNames[reportedCol].ToString();
                }
 
                if (!scrolling)
                    intelRichTB2.AppendText(update);
                else
                    savedtext = savedtext + update;

                //send intel info to Intel
                Object objData = "##i" + update;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                if (shared == "shared")
                {
                    client1.socket.Send(byData);
                    client2.socket.Send(byData);
                }
                else
                {
                    if (client1.role == "Intel") { client1.socket.Send(byData); }
                    else { client2.socket.Send(byData); }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            savePath = folderBrowserDialog1.SelectedPath;
            textBox1.Text = savePath;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
                sourceReliability = false;
            }
            else
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
                sourceReliability = true;
            }

        }



    }


}

