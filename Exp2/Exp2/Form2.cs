using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Exp2
{
    public partial class Form2 : Form
    {
        //icons
        System.Drawing.Bitmap hvticon = Exp2.Properties.Resources.hvticon;
        System.Drawing.Bitmap hvticon2 = new Bitmap(Exp2.Properties.Resources.hvticon, 25, 25);
        List<System.Drawing.Image> plticons = new List<System.Drawing.Image>() { Exp2.Properties.Resources.plt01, Exp2.Properties.Resources.plt02, Exp2.Properties.Resources.plt03, Exp2.Properties.Resources.plt04 };

        int nrows = 14;
        int nhvts = 5;
        int intTime = 0;
        string shared = " ";
        int reliabilityInfo = -99;
        int whichAccurate = -99;

        List<string> rowNames = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" };
        List<string> colNames = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14" };
        Point[,] pointArray = new Point[14, 14];
        List<unit> unitList = new List<unit>();

        PictureBox highlightedpb = null;
        RTFScrolledBottom intelRichTB2 = new RTFScrolledBottom();
        bool scrolling = false;
        string savedtext = "";
        Random randomizer = new Random();
        string role = Form1.role;
        Socket m_socClient = Form1.m_socClient;

        public Form2()
        {
            InitializeComponent();
            SetupMap();
            this.Text = role;
            timer1.Start();
        }

        private void SetupMap()
        {
            
            //make intel text box
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

            //remove movement buttons if Intel
            if (role == "Intel")
            {
                stopButton1.Visible = false;
                stopButton2.Visible = false;
                stopButton3.Visible = false;
                stopButton4.Visible = false;
            }

            //set up units
            for (int i = 0; i < 4; i++)
            {
                unit plt = new unit();
                plt.pStatus = "At Base";
                plt.pLastMoveTime = -99;
                plt.xfirst = -99;
                unitList.Add(plt);
            }

            //set up map grid
            mapPanel.BackgroundImage = Exp2.Properties.Resources.map11;

            for (int i = 0; i < nrows; i++)
                for (int j = 0; j < nrows; j++)
                    pointArray[i, j] = new Point(i * mapPanel.Width / nrows, j * mapPanel.Height / nrows);

            for (int i = nrows / 2 - 1; i < nrows / 2 + 1; i++)
                for (int j = nrows / 2 - 1; j < nrows / 2 + 1; j++)
                {
                    insertPictureBox(i, j, 2 * i - nrows + 2 + j - nrows / 2 + 2);
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].pRowCurrent = i;
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].pColCurrent = j;
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
            mapPanel.Paint += new PaintEventHandler(table_Paint);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                this.AcceptButton = chatSendButton;
        }

        private void chatSendButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                sendData("##c" + textBox1.Text);

                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.SelectionLength = 0;

                if (role == "Intel")
                {
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.AppendText("\r\n" + role + ": " + textBox1.Text);
                    richTextBox1.SelectionColor = Color.Black;
                }
                else
                {
                    richTextBox1.SelectionColor = Color.Green;
                    richTextBox1.AppendText("\r\n" + role + ": " + textBox1.Text);
                    richTextBox1.SelectionColor = Color.Black;
                }
                textBox1.Clear();
                this.AcceptButton = null;
            }
        }

        private void sendData(string dataToSend)
        {
            try
            {
                Object objData = dataToSend;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                m_socClient.Send(byData);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_socClient.Available > 0)
            {
                string szData = GetIncoming();
                string[] msgs = Regex.Split(szData, "##");

                for (int i = 0; i < msgs.Length; i++)
                {
                    if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "p"))
                    {
                        nhvts = int.Parse(msgs[i].Substring(1));
                        hvtpbPlus.Max = nhvts;
                        for (int j = 1; j <= nhvts; j++)
                        {
                            CheckBox cb = new CheckBox();
                            cb.Font = new Font("Arial", 8);
                            cb.Text = "HVT" + j;
                            checkPanel.Controls.Add(cb, (j - 1) / 5, (j - 1) % 5);
                            cb.Dock = DockStyle.Fill;
                            var m = cb.Margin;
                            m.All = 0;
                            cb.Margin = m;
                            cb.CheckedChanged += checkboxAction;
                        }
                        if (role == "Intel") { panel5.Visible = true; }
                        mapPanel.Visible = true;
                        panel1.Visible = true;
                    }

                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "l"))
                    {
                        shared = msgs[i].Substring(1);
                    }

                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "z"))
                    {
                        reliabilityInfo = int.Parse(msgs[i].Substring(1, 1));
                        whichAccurate = int.Parse(msgs[i].Substring(2, 1));
                        if (reliabilityInfo == 1)
                        {
                            if ((role == "Intel") || (shared == "shared"))
                            {
                                panel8.Visible = true;
                                if (whichAccurate == 0)
                                {
                                    richTextBox2.AppendText("\r\nSource A:  90% accurate\r\n");
                                    richTextBox2.SelectionColor = Color.DarkBlue;
                                    richTextBox2.AppendText("Source B:  10% accurate");
                                }
                                if (whichAccurate == 1)
                                {
                                    richTextBox2.AppendText("\r\nSource A:  10% accurate\r\n");
                                    richTextBox2.SelectionColor = Color.DarkBlue;
                                    richTextBox2.AppendText("Source B:  90% accurate");
                                }
                            }
                        }
                        if (reliabilityInfo == 2)
                        {
                            if ((role == "Intel") || (shared == "shared"))
                            {
                                panel8.Visible = true;
                                if (whichAccurate == 1)
                                {
                                    richTextBox2.AppendText("\r\nSource A:   90% accurate\r\n");
                                    richTextBox2.SelectionColor = Color.DarkBlue;
                                    richTextBox2.AppendText("Source B:   10% accurate");
                                }
                                if (whichAccurate == 0)
                                {
                                    richTextBox2.AppendText("\r\nSource A:   10% accurate\r\n");
                                    richTextBox2.SelectionColor = Color.DarkBlue;
                                    richTextBox2.AppendText("Source B:   90% accurate");
                                }
                            }
                        }
                    }


                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "x"))
                    {
                        unitList[int.Parse(msgs[i].Substring(1, 1))].xfirst = int.Parse(msgs[i].Substring(2, 1));
                    }

                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "g"))
                    {
                        if ((shared == "shared") || (role == "Intel"))
                        {
                            int whichUnit = int.Parse(msgs[i].Substring(2, 1));
                            unitList[whichUnit].xfirst = int.Parse(msgs[i].Substring(1, 1));
                            unitList[whichUnit].pRowGoal = rowNames.IndexOf(msgs[i].Substring(3, 1).ToUpper());
                            unitList[whichUnit].pColGoal = colNames.IndexOf(msgs[i].Substring(4));
                            unitList[whichUnit].pRowInitial = unitList[whichUnit].pRowCurrent;
                            unitList[whichUnit].pColInitial = unitList[whichUnit].pColCurrent;
                            unitList[whichUnit].pStatus = "Moving";
                            changeStatusLabel(whichUnit);
                            startUnitMovement(whichUnit, unitList[whichUnit].pRowGoal, unitList[whichUnit].pColGoal);
                        }
                    }
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "r"))
                    {
                        int whichUnit = int.Parse(msgs[i].Substring(2, 1));
                        unitList[whichUnit].xfirst = int.Parse(msgs[i].Substring(1, 1));
                        unitList[whichUnit].pRowInitial = rowNames.IndexOf(msgs[i].Substring(3, 1).ToUpper());
                        unitList[whichUnit].pColInitial = int.Parse(msgs[i].Substring(4));
                        unitList[whichUnit].pRowGoal = (whichUnit + nrows) / 2 - 1;
                        unitList[whichUnit].pColGoal = whichUnit % 2 + nrows / 2 - 1;
                        unitList[whichUnit].pStatus = "Returning";
                        changeStatusLabel(whichUnit);
                        startUnitMovement(whichUnit, unitList[whichUnit].pRowGoal, unitList[whichUnit].pColGoal);

                    }
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "c"))
                        richTextBox1.AppendText("\r\n" + msgs[i].Substring(1));
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "s"))
                    {
                        string stopType = msgs[i].Substring(1, 1);
                        int whichUnit = int.Parse(msgs[i].Substring(2, 1));
                        if (stopType == "s")
                            unitList[whichUnit].pStatus = "Stopped";
                        else
                            unitList[whichUnit].pStatus = "At Base";
                        changeStatusLabel(whichUnit);
                        unitList[whichUnit].pRowCurrent = rowNames.IndexOf(msgs[i].Substring(3, 1));
                        unitList[whichUnit].pColCurrent = int.Parse(msgs[i].Substring(4));
                        insertPictureBox(unitList[whichUnit].pRowCurrent, unitList[whichUnit].pColCurrent, whichUnit + 1);
                        mapPanel.Invalidate();
                    }
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "i"))
                    {
                        if (!scrolling)
                        {
                            intelRichTB2.SelectionBackColor = Color.FromArgb(255, 255, 128);
                            if (msgs[i].Substring(10, 1) == "A")
                            {
                                intelRichTB2.SelectionColor = Color.DarkBlue;
                            }
                            else
                            {
                                intelRichTB2.SelectionColor = Color.Black;
                            }
                            intelRichTB2.AppendText(msgs[i].Substring(1));
                        }
                        else
                            savedtext = savedtext + msgs[i].Substring(1);
                        intTime = 0;
                        timer2.Start();
                    }
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "h"))
                    {
                        int temprow = rowNames.IndexOf(msgs[i].Substring(2, 1));
                        int tempcol = int.Parse(msgs[i].Substring(3));
                        if (msgs[i].Substring(1, 1) == "1") { insertLabel(temprow, tempcol); }
                        else
                        {
                            Point loc = pointArray[tempcol, temprow];
                            foreach (Control p in mapPanel.Controls)
                                if ((p is Label) && (p.Location == new Point(loc.X + 23, loc.Y + 23)))
                                    mapPanel.Controls.Remove(p);
                        }
                    }
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "t"))
                    {
                        unitRichTB.AppendText(msgs[i].Substring(1));
                    }
                    else if ((msgs[i].Length > 1) && (msgs[i].Substring(0, 1) == "b"))
                    {
                        hvtpbPlus.Value = hvtpbPlus.Value + 1;
                        nhvtLabel.Text = msgs[i].Substring(1);
                    }
                    else if ((msgs[i].Length > 0) && (msgs[i].Substring(0, 1) == "d"))
                    {
                        timer1.Stop();
                        MessageBox.Show(msgs[i].Substring(1));
                        this.Close();
                    }
                }
            }
        }

        private string GetIncoming()
        {
            byte[] buffer = new byte[1024];
            int iRx = m_socClient.Receive(buffer);
            char[] chars = new char[iRx];
            System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
            int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
            System.String szData = new System.String(chars);
            return (szData);
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
                if ((p is Label) && (p.Location == new Point(loc.X + 23, loc.Y + 23)))
                {
                    nlab++;
                    break;
                }

            if (nlab == 0)
            {
                Label newlabel = MakeNewLabel();
                newlabel.Location = new Point(loc.X + 23, loc.Y + 23);
                mapPanel.Controls.Add(newlabel);
            }
        }

        private Label MakeNewLabel()
        {
            Label newLabel = new Label();
            newLabel.AutoSize = false;
            newLabel.Height = 25;
            newLabel.Width = 25;
            newLabel.Image = hvticon2;
            //newLabel.Location = new Point(23, 23);
            if (role == "Intel")
                newLabel.MouseDown += label_MouseDown;
            else
                newLabel.MouseClick += label_MouseClick;
            return (newLabel);
        }

        private PictureBox MakeNewPB(int whichUnit)
        {
            PictureBox pb = new PictureBox();
            pb.BackColor = Color.Transparent;
            pb.Height = mapPanel.Size.Height / nrows / 2;
            pb.Width = mapPanel.Size.Height / nrows / 2;
            if (role == "OPS")
                pb.Click += unitpb_Click;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Name = "pb" + whichUnit.ToString();
            pb.Image = plticons[whichUnit - 1];
            if (role == "OPS")
                pb.Cursor = Cursors.Hand;
            return (pb);
        }

        //user clicks on unit:
        private void unitpb_Click(object sender, EventArgs e)
        {

            PictureBox clickedpb = sender as PictureBox;
            if (clickedpb.Image != null)
            {
                //if user clicks on currently highlighted unit, unhighlight it
                if (clickedpb == highlightedpb)
                    unhighlightUnit();
                //if user clicks on new unit, unhighlight old one, highlight new one, and make assignment panel visible
                else
                {
                    if (highlightedpb != null)
                        unhighlightUnit();
                    clickedpb.BackColor = Color.Yellow;
                    panel2.Visible = true;

                    Point loc = clickedpb.Location;
                    int tempcol = 0;
                    int temprow = 0;
                    for (int i = 0; i < nrows; i++)
                    {
                        if (pointArray[i, 0].X == loc.X) { tempcol = i; }
                        if (pointArray[i, 0].X == loc.Y) { temprow = i; }
                    }
                    string gridSquare = rowNames[temprow] + colNames[tempcol];
                    assignUnitLbl1.Text = "Platoon " + clickedpb.Name.Substring(2, 1) + ": " + gridSquare + " to";
                    assignUnitTB.Focus();
                    highlightedpb = clickedpb;
                }
            }
        }

        private void unhighlightUnit()
        {
            highlightedpb.BackColor = Color.Transparent;
            highlightedpb = null;
            panel2.Visible = false;
            assignUnitTB.Text = null;
        }

        private void assignUnitTB_TextChanged(object sender, EventArgs e)
        {
            assignUnitButton.Enabled = false;
            if ((assignUnitTB.Text.Length > 1)
                && (rowNames.Contains(assignUnitTB.Text.Substring(0, 1).ToUpper()))
                && (colNames.Contains(assignUnitTB.Text.Substring(1, assignUnitTB.Text.Length - 1))))
            {
                assignUnitButton.Enabled = true;
                this.AcceptButton = assignUnitButton;
            }
        }

        private void assignUnitButton_Click(object sender, EventArgs e)
        {
            int whichUnit = int.Parse(highlightedpb.Name.Substring(2, 1)) - 1;

            unitList[whichUnit].pRowGoal = rowNames.IndexOf(assignUnitTB.Text.Substring(0, 1).ToUpper());
            unitList[whichUnit].pColGoal = colNames.IndexOf(assignUnitTB.Text.Substring(1));

            unitList[whichUnit].pStatus = "Moving";
            changeStatusLabel(whichUnit);
            unitList[whichUnit].pRowInitial = unitList[whichUnit].pRowCurrent;
            unitList[whichUnit].pColInitial = unitList[whichUnit].pColCurrent;

            unitList[whichUnit].xfirst = randomizer.Next(2);

            startUnitMovement(whichUnit, unitList[whichUnit].pRowGoal, unitList[whichUnit].pColGoal);
            sendData("##g" + unitList[whichUnit].xfirst + whichUnit.ToString() + assignUnitTB.Text);
            unhighlightUnit();
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
            mapPanel.Invalidate();
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

        private void StopUnitMovementButton(object sender, EventArgs e)
        {
            Button stoppedButton = sender as Button;
            int stoppedUnit = int.Parse(stoppedButton.Tag.ToString());
            sendData("##s" + (stoppedUnit - 1).ToString());
        }
        private void changeStatusLabel(int whichUnit)
        {
            foreach (Control statuscontrol in panel3.Controls)
            {
                if ((statuscontrol is Label) && (statuscontrol.Name.Substring(1, 1) == Convert.ToString(whichUnit + 1)))
                {
                    statuscontrol.Text = unitList[whichUnit].pStatus;
                    if ((unitList[whichUnit].pStatus == "Stopped") || (unitList[whichUnit].pStatus == "Returning"))
                        statuscontrol.ForeColor = Color.Red;
                    else if (unitList[whichUnit].pStatus == "Moving")
                        statuscontrol.ForeColor = Color.Yellow;
                    else
                        statuscontrol.ForeColor = Color.Black;
                }

                if ((statuscontrol is Button) && (statuscontrol.Name.Substring(10, 1) == (whichUnit + 1).ToString()))
                {
                    if (unitList[whichUnit].pStatus == "Moving")
                        statuscontrol.Enabled = true;
                    else
                        statuscontrol.Enabled = false;
                }
            }
        }

        //make the textboxes highlight and scroll appropriately
        private void timer2_Tick(object sender, EventArgs e)
        {
            intTime++;
            if (intTime > 5)
            {
                if (!scrolling)
                {
                    int firstcharindex = intelRichTB2.GetFirstCharIndexOfCurrentLine();
                    int lineNumber = intelRichTB2.GetLineFromCharIndex(firstcharindex);
                    string currentlinetext = intelRichTB2.Lines[lineNumber];
                    intelRichTB2.Select(firstcharindex, currentlinetext.Length);
                    intelRichTB2.SelectionBackColor = Color.White;
                    intelRichTB2.SelectionStart = intelRichTB2.Text.Length;
                }
                
                timer2.Stop();
                
            }
        }
        private void scrolltoBottom(object sender, EventArgs e)
        {
            RichTextBox scrolledTB = sender as RichTextBox;
            scrolledTB.ScrollToCaret();
        }
        private void intelRichTB2_thumbUp(object sender, EventArgs e)
        {
            if ((savedtext.Length > 0))
            {
                intelRichTB2.SelectAll();
                intelRichTB2.SelectionBackColor = Color.White;
                intelRichTB2.AppendText(savedtext);
                savedtext = "";
                scrolling = false;
            }
        }
        private void intelRichTB2_thumbDown(object sender, EventArgs e)
        {
            scrolling = true;
        }

        //drag and drop hvt icons to/from map
        private void hvtpb_MouseDown(object sender, MouseEventArgs e)
        {
            hvtpb.DoDragDrop(hvtpb.Image, DragDropEffects.Move);
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            Label draggedLabel = sender as Label;
            draggedLabel.DoDragDrop(draggedLabel.Image, DragDropEffects.Move);
            Point loc = draggedLabel.Location;
            int tempcol = 0;
            int temprow = 0;
            for (int i = 0; i < nrows; i++)
            {
                if (pointArray[i, 0].X == loc.X - 23) { tempcol = i; }
                if (pointArray[i, 0].X == loc.Y - 23) { temprow = i; }
            }

            mapPanel.Controls.Remove(draggedLabel);
            sendData("##h" + "0" + rowNames[temprow] + tempcol.ToString());
        }

        //highlight hvt icon
        private void hvtpb_MouseEnter(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }
        private void hvtpb_MouseLeave(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        //quit button
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult quitResult = MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (quitResult == DialogResult.Yes)
                sendData("##q");
        }

        private void label_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel2.Visible == true)
            {
                Label whichLabel = sender as Label;
                Point loc = whichLabel.Location;
                int tempcol = 0;
                int temprow = 0;
                for (int i = 0; i < nrows; i++)
                {
                    if (pointArray[i, 0].X == loc.X - 23) { tempcol = i; }
                    if (pointArray[i, 0].X == loc.Y - 23) { temprow = i; }
                }
                string temprowname = rowNames[temprow];
                string tempcolname = colNames[tempcol];
                assignUnitTB.Text = temprowname + tempcolname;
            }
        }

        private void checkboxAction(object sender, EventArgs e)
        {
            CheckBox whichcb = sender as CheckBox;
            if (whichcb.Checked)
                sendData("##k1" + whichcb.Text.Substring(3));
            else
                sendData("##k0" + whichcb.Text.Substring(3));
        }

        //click to assign unit movements
        private void mapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel2.Visible == true)
            {
                string tempcolname = "";
                string temprowname = "";
                for (int i = 0; i < nrows; i++)
                {
                    int min = mapPanel.Size.Width / nrows * i;
                    int max = mapPanel.Size.Width / nrows * (i + 1);
                    if ((e.X >= min) && (e.X < max))
                    {
                        tempcolname = colNames[i];
                        break;
                    }
                }
                for (int i = 0; i < nrows; i++)
                {
                    int min = mapPanel.Size.Width / nrows * i;
                    int max = mapPanel.Size.Width / nrows * (i + 1);
                    if ((e.Y >= min) && (e.Y < max))
                    {
                        temprowname = rowNames[i];
                        break;
                    }
                }

                assignUnitTB.Text = temprowname + tempcolname;
            }
        }

        private void mapPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void mapPanel_DragDrop(object sender, DragEventArgs e)
        {
            int tempcol = 0;
            int temprow = 0;
            Point local = mapPanel.PointToClient(new Point(e.X, e.Y));
            for (int i = 0; i < nrows; i++)
            {
                int min = mapPanel.Size.Width / nrows * i;
                int max = mapPanel.Size.Width / nrows * (i + 1);
                if ((local.X >= min) && (local.X < max))
                {
                    tempcol = i;
                    break;
                }
            }
            for (int i = 0; i < nrows; i++)
            {
                int min = mapPanel.Size.Width / nrows * i;
                int max = mapPanel.Size.Width / nrows * (i + 1);
                if ((local.Y >= min) && (local.Y < max))
                {
                    temprow = i;
                    break;
                }
            }
            insertLabel(temprow, tempcol);
            sendData("##h" + "1" + rowNames[temprow] + tempcol.ToString());
        }
    }

}
