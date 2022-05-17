using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Exp2TutorialNoSources
{
    public partial class Form2 : Form
    {
        System.Drawing.Bitmap hvticon = Exp2TutorialNoSources.Properties.Resources.hvticon;
        System.Drawing.Bitmap hvticon2 = new Bitmap(Exp2TutorialNoSources.Properties.Resources.hvticon, 25, 25);
        List<string> rowNames = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" };
        List<string> colNames = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14" };
        PictureBox highlightedpb = null;
        RTFScrolledBottom intelRichTB2 = new RTFScrolledBottom();
        public static string tbtext;
        public static bool arrow;
        public static bool blue = true;
        public static string direction = "right";
        int whichDrag = 0;
        int dragTime = -999;
        int clickTime = -999;

        int nrows = 14;
        int nhvts = 10;

        Random randomizer = new Random();

        Point[,] pointArray = new Point[14, 14];

        int intTime = 0;
        int firstNotify = 300;
        int hvtRow = 38;
        int hvtCol = 38;

        bool timetochat = false;
        int chattime = -99;

        List<unit> unitList = new List<unit>();
        List<System.Drawing.Image> plticons = new List<System.Drawing.Image>() { Exp2TutorialNoSources.Properties.Resources.plt01, Exp2TutorialNoSources.Properties.Resources.plt02, Exp2TutorialNoSources.Properties.Resources.plt03, Exp2TutorialNoSources.Properties.Resources.plt04 };

        public Form2()
        {
            InitializeComponent();
            SetupMap();
            timer1.Start();
        }
        private void firstMessage()
        {
            timer1.Stop();
            tbtext = "Let's focus on the Intelligence Officer responsibilities first.";
            arrow = false;
            Form3 newform3 = new Form3();
            newform3.StartPosition = FormStartPosition.Manual;
            newform3.Location = new Point(650, 300);
            newform3.ShowDialog();

            panel8.Visible = true;
            panel9.Visible = true;
            label2.Visible = false;

            System.Threading.Thread.Sleep(250);
            panel10.Visible = true;
            panel11.Visible = true;
            System.Threading.Thread.Sleep(250);
            panel10.Visible = false;
            panel11.Visible = false;
            System.Threading.Thread.Sleep(250);
            panel10.Visible = true;
            panel11.Visible = true;
            System.Threading.Thread.Sleep(250);
            panel10.Visible = false;
            panel11.Visible = false;
            System.Threading.Thread.Sleep(250);
            panel10.Visible = true;
            panel11.Visible = true;
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
            intelRichTB2.Size = new System.Drawing.Size(216, 321);
            intelRichTB2.TabIndex = 10;
            intelRichTB2.TabStop = false;
            intelRichTB2.Text = "";

            intelRichTB2.BringToFront();

            //set up units
            for (int i = 0; i < 4; i++)
            {
                unit plt = new unit();
                plt.status = "At Base";
                plt.lastMoveTime = -99;
                plt.xfirst = -99;
                unitList.Add(plt);
            }

            //set up map grid
            mapPanel.Paint += new PaintEventHandler(grid_Paint);
            mapPanel.BackgroundImage = Exp2TutorialNoSources.Properties.Resources.map1;
            for (int i = 1; i < nrows + 1; i++)
            {
                Label rowLabel = new Label();
                rowLabel.Name = "rowLabel" + i;
                Controls.Add(rowLabel);
                rowLabel.Location = new System.Drawing.Point(15, mapPanel.Size.Height / nrows * (i - 1) + mapPanel.Location.Y + mapPanel.Size.Height / nrows / 2 - 12);
                rowLabel.Font = new Font("Arial", 14);
                rowLabel.Text = rowNames[i - 1];

                Label colLabel = new Label();
                colLabel.Name = "colLabel" + i;
                Controls.Add(colLabel);
                colLabel.Location = new System.Drawing.Point(mapPanel.Size.Width / nrows * (i - 1) + mapPanel.Location.X + mapPanel.Size.Width / nrows / 2 - 10, 140);
                colLabel.Font = new Font("Arial", 14);
                colLabel.Text = colNames[i - 1];
                colLabel.AutoSize = true;
            }
            for (int i = 0; i < nrows; i++)
                for (int j = 0; j < nrows; j++)
                    pointArray[i, j] = new Point(i * mapPanel.Width / nrows, j * mapPanel.Height / nrows);

            for (int i = nrows / 2 - 1; i < nrows / 2 + 1; i++)
                for (int j = nrows / 2 - 1; j < nrows / 2 + 1; j++)
                {
                    insertPictureBox(i, j, 2 * i - nrows + 2 + j - nrows / 2 + 2);
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].rowCurrent = i;
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].baseRow = i;
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].colCurrent = j;
                    unitList[2 * i - nrows + 2 + j - nrows / 2 + 2 - 1].baseCol = j;
                }

            for (int i = 1; i <= nhvts; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Font = new Font("Arial", 8);
                cb.Text = "HVT" + i;
                cb.Dock = DockStyle.Fill;
                var m = cb.Margin;
                m.All = 0;
                cb.Margin = m;
                cb.CheckedChanged += CheckBox_Change;
                checkPanel.Controls.Add(cb, (i - 1) / 5, (i - 1) % 5);
            }

            hvtpbPlus.Max = nhvts;

        }

        private void CheckBox_Change(object sender, EventArgs e)
        {
            if (panel18.Visible == true)
            {
                CheckBox cb = sender as CheckBox;
                if (cb.Text == "HVT1")
                {
                    panel18.Visible = false;
                    MessageBox.Show("Good job!");

                    int form2x = this.Location.X;
                    int form2y = this.Location.Y;

                    tbtext = "Use chat to tell the Intelligence Officer that a target has been captured";
                    arrow = true;
                    //bring up a form3 to ask them to chat
                    Form3 newform3 = new Form3();
                    newform3.StartPosition = FormStartPosition.Manual;
                    newform3.Location = new Point(760 + form2x, 550 + form2y);
                    newform3.ShowDialog();
                    timetochat = true;

                }
            }
        }

        private void insertPictureBox(int rowindex, int colindex, int whichUnit)
        {
            Point loc = pointArray[colindex, rowindex];
            int npb = 0;
            foreach (Control p in mapPanel.Controls)
                if ((p is PictureBox) && (p.Location == loc))
                {
                    PictureBox whichpb = p as PictureBox;
                    npb++;
                    whichpb.Image = plticons[whichUnit - 1];
                    whichpb.Name = "pb" + whichUnit.ToString();
                }

            if (npb == 0)
            {
                PictureBox newpb = MakeNewPB(whichUnit);
                newpb.Location = loc;
                mapPanel.Controls.Add(newpb);
            }
        }

        private PictureBox MakeNewPB(int whichUnit)
        {
            PictureBox pb = new PictureBox();
            pb.BackColor = Color.Transparent;
            pb.Height = mapPanel.Size.Height / nrows / 2;
            pb.Width = mapPanel.Size.Height / nrows / 2;
            pb.Click += unitpb_Click;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Name = "pb" + whichUnit.ToString();
            pb.Image = plticons[whichUnit - 1];
            pb.Cursor = Cursors.Hand;
            return (pb);
        }

        private void unitpb_Click(object sender, EventArgs e)
        {
            if (panel18.Visible)
            {
                panel18.Visible = false;
                timer1.Start();
                clickTime = intTime;
            }
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

        private void grid_Paint(object sender, PaintEventArgs e)
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
                if ((unitList[i].status == "Moving") || (unitList[i].status == "Returning"))
                {
                    //Calculate arrow coordinates
                    Pen colorPen = new Pen(Color.Black, 6);
                    if (unitList[i].status == "Moving")
                        colorPen.Color = Color.FromArgb(255, 255, 100);
                    else
                        colorPen.Color = Color.FromArgb(255, 50, 50);
                    colorPen.StartCap = LineCap.RoundAnchor;
                    colorPen.EndCap = LineCap.ArrowAnchor;

                    int x1 = unitList[i].colInitial * mapPanel.Size.Height / nrows + mapPanel.Size.Height / nrows / 2;
                    int y1 = unitList[i].rowInitial * mapPanel.Size.Height / nrows + mapPanel.Size.Height / nrows / 2;
                    int x2 = unitList[i].colGoal * mapPanel.Size.Width / nrows + mapPanel.Size.Width / nrows / 2;
                    int y2 = unitList[i].rowGoal * mapPanel.Size.Height / nrows + mapPanel.Size.Height / nrows / 2;

                    if (unitList[i].xfirst == 1)
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

        private void intelRichTB2_thumbDown(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void intelRichTB2_thumbUp(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            intTime++;
            if (intTime == 3)
            {
                firstMessage();
            }

            if (intTime == 4)
            {
                intelRichTB2.SelectionBackColor = Color.FromArgb(255, 255, 128);
                intelRichTB2.AppendText("\r\nSource A: HVT 1 sighted at D4");
                hvtRow = 3;
                hvtCol = 3;
                firstNotify = intTime;
            }

            if ((intelRichTB2.Text != "") && (intTime - firstNotify == 1))
            {
                int firstcharindex = intelRichTB2.GetFirstCharIndexOfCurrentLine();
                int lineNumber = intelRichTB2.GetLineFromCharIndex(firstcharindex);
                string currentlinetext = intelRichTB2.Lines[lineNumber];
                intelRichTB2.Select(firstcharindex, currentlinetext.Length);
                intelRichTB2.SelectionBackColor = Color.White;
                intelRichTB2.SelectionStart = intelRichTB2.Text.Length;

                timer1.Stop();
                int form2x = this.Location.X;
                int form2y = this.Location.Y;

                tbtext = "Target location information appears here";
                arrow = true;
                Form3 newform3 = new Form3();
                newform3.StartPosition = FormStartPosition.Manual;
                newform3.Location = new Point(480 + form2x, 160 + form2y);
                newform3.ShowDialog();
                timer1.Start();
            }

            if (intTime - firstNotify == 2)
            {
                dragTime = intTime;
                timer1.Stop();
                panel12.Visible = true;
                whichDrag = 1;
            }

            if (intTime - dragTime == 2)
            {
                timer1.Stop();
                int form2x = this.Location.X;
                int form2y = this.Location.Y;

                tbtext = "Use the locations marked by the Intelligence Officer to decide where to send your units.";
                arrow = false;
                blue = false;
                Form3 newform3 = new Form3();
                newform3.StartPosition = FormStartPosition.Manual;
                newform3.Location = new Point(400 + form2x, 260 + form2y);
                newform3.ShowDialog();

                panel18.Location = new Point(442, 285);
                textBox4.Dock = DockStyle.Fill;
                textBox4.Text = "Click on a unit.";
                textBox4.ForeColor = Color.Green;
                panel19.BackColor = Color.Green;
                panel18.Visible = true;
            }

            if (intTime - clickTime == 1)
            {
                foreach (Control p in mapPanel.Controls)
                {
                    if (p is Label)
                    {
                        Label lab = p as Label;
                        lab.MouseDown -= label_MouseDown;
                        lab.MouseClick += label_MouseClick;
                    }
                }
                textBox3.ForeColor = Color.Green;
                panel16.BackColor = Color.Green;
                textBox3.Text = "Click on the map.";
                panel15.Visible = true;
            }

            for (int i = 0; i < 4; i++)
            {
                if ((unitList[i].status == "Moving") || (unitList[i].status == "Returning"))
                {
                    if ((intTime - unitList[i].lastMoveTime == 3) && (unitList[i].lastMoveTime >= 0))
                    {
                        updateUnitPosition(i);

                        if ((unitList[i].rowCurrent == unitList[i].rowGoal) && (unitList[i].colCurrent == unitList[i].colGoal))
                        {
                            if ((unitList[i].rowCurrent == unitList[i].baseRow) && (unitList[i].colCurrent == unitList[i].baseCol))
                            {
                                unitList[i].status = "At Base";
                                unitRichTB.AppendText("PLT " + (i + 1) + ":  At " + rowNames[unitList[i].rowGoal] + colNames[unitList[i].colGoal].ToString() + "\r\n");
                                StopUnitMovement(i);

                                panel12.Visible = false;
                                textBox4.Text = "Stay organized! Mark which targets you've captured here.";
                                mapPanel.Controls.Remove(panel18);
                                this.Controls.Add(panel18);

                                panel18.Location = new Point(1050, 5);
                                panel18.BringToFront();
                                panel18.Visible = true;
                                // panel18.Location = new Point(500,500);
                            }
                            else
                            {
                                unitList[i].status = "Stopped";
                                unitRichTB.AppendText("PLT " + (i + 1) + ":  At " + rowNames[unitList[i].rowGoal] + colNames[unitList[i].colGoal].ToString() + "\r\n");
                                StopUnitMovement(i);
                            }
                        }

                        else
                            unitList[i].lastMoveTime = intTime;

                        if (unitList[i].status != "Returning")
                        {
                            if ((unitList[i].rowCurrent == hvtRow) && (unitList[i].colCurrent == hvtCol))
                            {
                                panel18.Visible = false;
                                hvtpbPlus.Value = hvtpbPlus.Value + 1;
                                nhvtLabel.Text = (int.Parse(nhvtLabel.Text) + 1).ToString();
                                unitRichTB.AppendText("PLT " + (i + 1) + ":  Captured HVT 1 at D4\r\n");
                                returnUnit(i);
                                timer1.Stop();
                                int form2x = this.Location.X;
                                int form2y = this.Location.Y;
                                tbtext = "The red arrow means the platoon has captured an HVT and is returning to base";
                                Form3 newform3 = new Form3();
                                newform3.StartPosition = FormStartPosition.Manual;
                                newform3.Location = new Point(400 + form2x, 180 + form2y);
                                newform3.pictureBox1.Hide();
                                newform3.textBox1.Dock = DockStyle.Fill;
                                newform3.ShowDialog();
                                timer1.Start();

                                panel12.Location = new Point(550, 525);
                                textBox2.Text = "Unit movement and capture information appear here";
                                textBox2.Location = new Point(0, 47);
                                panel12.Visible = true;
                            }
                        }
                    }
                }
            }

            if (intTime - chattime == 1)
            {
                MessageBox.Show("Way to go!");
                this.Close();

            }
        }

        private void returnUnit(int whichUnit)
        {
            unitList[whichUnit].status = "Returning";
            unitList[whichUnit].rowGoal = (whichUnit + nrows) / 2 - 1;
            unitList[whichUnit].colGoal = whichUnit % 2 + nrows / 2 - 1;
            startUnitMovement(whichUnit, unitList[whichUnit].rowGoal, unitList[whichUnit].colGoal);
        }

        private void StopUnitMovement(int whichUnit)
        {
            changeStatusLabel(whichUnit);
            insertPictureBox(unitList[whichUnit].rowCurrent, unitList[whichUnit].colCurrent, whichUnit + 1);
            mapPanel.Invalidate();
        }

        private void updateUnitPosition(int whichUnit)
        {
            if (unitList[whichUnit].xfirst == 1)
            {
                if (unitList[whichUnit].colCurrent > unitList[whichUnit].colGoal) { unitList[whichUnit].colCurrent--; }
                else if (unitList[whichUnit].colCurrent < unitList[whichUnit].colGoal) { unitList[whichUnit].colCurrent++; }
                else
                {
                    if (unitList[whichUnit].rowCurrent > unitList[whichUnit].rowGoal)
                        unitList[whichUnit].rowCurrent--;
                    else if (unitList[whichUnit].rowCurrent < unitList[whichUnit].rowGoal)
                        unitList[whichUnit].rowCurrent++;
                }
            }
            if (unitList[whichUnit].xfirst == 0)
            {
                if (unitList[whichUnit].rowCurrent > unitList[whichUnit].rowGoal) { unitList[whichUnit].rowCurrent--; }
                else if (unitList[whichUnit].rowCurrent < unitList[whichUnit].rowGoal) { unitList[whichUnit].rowCurrent++; }
                else
                {
                    if (unitList[whichUnit].colCurrent > unitList[whichUnit].colGoal) { unitList[whichUnit].colCurrent--; }
                    else if (unitList[whichUnit].colCurrent < unitList[whichUnit].colGoal) { unitList[whichUnit].colCurrent++; }
                }
            }
        }

        //drag and drop hvt icons to/from map
        private void hvtpb_MouseDown(object sender, MouseEventArgs e)
        {
            if (whichDrag == 1)
            {
                panel12.Visible = false;
                panel15.Visible = true;
            }
            hvtpb.DoDragDrop(hvtpb.Image, DragDropEffects.Move);

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
            if (whichDrag == 1)
            {
                if ((temprow == 3) && (tempcol == 3))
                {
                    panel15.Visible = false;
                    MessageBox.Show("Good job!");
                    whichDrag = 2;
                    panel18.Visible = true;
                }
            }
            if (whichDrag == 2)
            {
                if ((temprow != 3) || (tempcol != 3))
                {
                    panel18.Visible = false;
                    MessageBox.Show("Nice!");
                    whichDrag = 3;
                    textBox4.Text = "Now try dragging the first icon off the map";
                    panel18.Visible = true;
                }
            }

            if (whichDrag == 5)
            {
                if ((temprow == 3) && (tempcol == 3))
                {
                    panel18.Visible = false;
                    MessageBox.Show("Great!");

                }
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
            newLabel.MouseDown += label_MouseDown;
            return (newLabel);
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
            if ((whichDrag == 3))
            {
                if ((temprow == 3) && (tempcol == 3))
                {
                    panel18.Visible = false;
                    MessageBox.Show("Way to go!");
                    whichDrag = 4;
                    textBox4.Text = "Now try moving the second icon to a new location";
                    panel18.Visible = true;

                }
            }

            else if (whichDrag == 4)
            {
                panel18.Visible = false;
                MessageBox.Show("Great!");
                whichDrag = 5;
                textBox4.Text = "Now put that icon back at D4";
                panel18.Visible = true;
            }

            else if (whichDrag == 5)
            {

                panel8.Visible = false;
                panel9.Visible = false;
                whichDrag = 6;
                intelRichTB2.Text = "";
                System.Threading.Thread.Sleep(500);
                tbtext = "Now let's focus on the Operations Officer responsibilities.";
                arrow = false;
                blue = false;
                System.Threading.Thread.Sleep(500);
                Form3 newform3 = new Form3();
                newform3.StartPosition = FormStartPosition.Manual;
                newform3.Location = new Point(650, 300);
                newform3.ShowDialog();

                System.Threading.Thread.Sleep(250);
                intelRichTB2.Size = new System.Drawing.Size(216, 310);
                panel21.Visible = true;
                panel24.Visible = true;
                panel25.Visible = true;
                panel26.Visible = true;
                panel27.Visible = true;
                System.Threading.Thread.Sleep(250);
                panel22.Visible = false;

                panel23.Visible = false;
                panel28.Visible = false;
                panel29.Visible = false;
                panel30.Visible = false;
                System.Threading.Thread.Sleep(250);
                panel22.Visible = true;
                panel23.Visible = true;
                panel28.Visible = true;
                panel29.Visible = true;
                panel30.Visible = true;
                System.Threading.Thread.Sleep(250);
                panel22.Visible = false;

                panel23.Visible = false;
                panel28.Visible = false;
                panel29.Visible = false;
                panel30.Visible = false;
                System.Threading.Thread.Sleep(250);
                panel22.Visible = true;
                panel23.Visible = true;
                panel28.Visible = true;
                panel29.Visible = true;
                panel30.Visible = true;
                System.Threading.Thread.Sleep(250);
                panel24.Visible = false;
                panel25.Visible = false;
                panel26.Visible = false;
                panel27.Visible = false;

                timer1.Start();
            }
        }

        private void mapPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void mapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel15.Visible == true)
            {
                panel15.Visible = false;
                pictureBox1.BackgroundImage = Exp2TutorialNoSources.Properties.Resources.Picture1;
                panel14.BackColor = Color.Green;
                textBox2.ForeColor = Color.Green;
                textBox2.Text = "Hit GO to deploy";
                panel12.Location = new Point(150, 55);
                panel12.Visible = true;
            }


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

        private void label_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel15.Visible == true)
            {
                panel15.Visible = false;
                pictureBox1.BackgroundImage = Exp2TutorialNoSources.Properties.Resources.Picture1;
                panel14.BackColor = Color.Green;
                textBox2.ForeColor = Color.Green;
                textBox2.Text = "Hit GO to deploy";
                panel12.Location = new Point(150, 55);
                panel12.Visible = true;
            }

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
            if (panel12.Visible)
            {
                panel12.Visible = false;
                textBox4.Text = "The yellow arrow tells you the platoon is on its way.  Be patient!";
                panel18.Visible = true;
            }
            panel2.Visible = false;
            int whichUnit = int.Parse(highlightedpb.Name.Substring(2, 1)) - 1;
            unitList[whichUnit].rowGoal = rowNames.IndexOf(assignUnitTB.Text.Substring(0, 1).ToUpper());
            unitList[whichUnit].colGoal = colNames.IndexOf(assignUnitTB.Text.Substring(1, assignUnitTB.Text.Length - 1));
            unhighlightUnit();
            unitList[whichUnit].status = "Moving";
            startUnitMovement(whichUnit, unitList[whichUnit].rowGoal, unitList[whichUnit].colGoal);
        }

        private void startUnitMovement(int unitIndex, int rowGoal, int colGoal)
        {
            //randomly choose whether arrows are drawn horizontally or vertically first for this movement
            unitList[unitIndex].xfirst = randomizer.Next(2);

            //update starting index          
            unitList[unitIndex].rowInitial = unitList[unitIndex].rowCurrent;
            unitList[unitIndex].colInitial = unitList[unitIndex].colCurrent;

            Point loc = pointArray[unitList[unitIndex].colCurrent, unitList[unitIndex].rowCurrent];
            //remove the picture box
            foreach (Control p in mapPanel.Controls)
                if ((p is PictureBox) && (p.Location == loc))
                {
                    mapPanel.Controls.Remove(p);
                    //put it back if there was another unit there
                    for (int i = 0; i < 4; i++)
                        if ((unitList[i].rowCurrent == unitList[unitIndex].rowCurrent) && (unitList[i].colCurrent == unitList[unitIndex].colCurrent) && (i != unitIndex))
                            if ((unitList[i].status == "At Base") || (unitList[i].status == "Stopped"))
                                insertPictureBox(unitList[i].rowCurrent, unitList[i].colCurrent, i + 1);
                }
            unitList[unitIndex].lastMoveTime = intTime;
            changeStatusLabel(unitIndex);
            //give spot report of initial movement
            string gridSquare = rowNames[unitList[unitIndex].rowCurrent] + colNames[unitList[unitIndex].colCurrent].ToString();
            unitRichTB.AppendText("PLT " + (unitIndex + 1) + ":  At " + gridSquare + " , Moving to " + rowNames[rowGoal] + colNames[colGoal].ToString() + "\r\n");
            mapPanel.Invalidate();
        }

        private void changeStatusLabel(int whichUnit)
        {
            foreach (Control statuscontrol in panel2.Controls)
            {
                if ((statuscontrol is Label) && (statuscontrol.Name.Substring(1, 1) == Convert.ToString(whichUnit + 1)))
                {
                    statuscontrol.Text = unitList[whichUnit].status;
                    if ((unitList[whichUnit].status == "Stopped") || (unitList[whichUnit].status == "Returning"))
                        statuscontrol.ForeColor = Color.Red;
                    else if (unitList[whichUnit].status == "Moving")
                        statuscontrol.ForeColor = Color.Yellow;
                    else
                        statuscontrol.ForeColor = Color.Black;
                }

                if ((statuscontrol is Button) && (statuscontrol.Name.Substring(10, 1) == (whichUnit + 1).ToString()))
                    if (unitList[whichUnit].status == "Moving")
                        statuscontrol.Enabled = true;
                    else
                        statuscontrol.Enabled = false;
            }
        }

        private void chatSendButton_Click(object sender, EventArgs e)
        {
            if (timetochat)
            {
                if (textBox1.Text != "")
                {
                    richTextBox1.ForeColor = Color.Green;
                    richTextBox1.Text = "OPS: " + textBox1.Text;
                    textBox1.Text = "";
                    chattime = intTime;



                }
            }
        }
    }
}
