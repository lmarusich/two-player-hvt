namespace Exp2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            ProgBar.cBlendItems cBlendItems2 = new ProgBar.cBlendItems();
            ProgBar.cFocalPoints cFocalPoints2 = new ProgBar.cFocalPoints();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.unitRichTB = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chatSendButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.assignUnitButton = new System.Windows.Forms.Button();
            this.assignUnitLbl1 = new System.Windows.Forms.Label();
            this.assignUnitTB = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.stopButton4 = new System.Windows.Forms.Button();
            this.stopButton3 = new System.Windows.Forms.Button();
            this.stopButton2 = new System.Windows.Forms.Button();
            this.stopButton1 = new System.Windows.Forms.Button();
            this.p4StatusLabel = new System.Windows.Forms.Label();
            this.p3StatusLabel = new System.Windows.Forms.Label();
            this.p2StatusLabel = new System.Windows.Forms.Label();
            this.p1StatusLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.hvtpbPlus = new ProgBar.ProgBarPlus();
            this.label8 = new System.Windows.Forms.Label();
            this.nhvtLabel = new System.Windows.Forms.Label();
            this.checkPanel = new System.Windows.Forms.TableLayoutPanel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.hvtpb = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hvtpb)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.unitRichTB);
            this.panel6.Location = new System.Drawing.Point(786, 152);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(275, 725);
            this.panel6.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Intel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Spot Reports:";
            // 
            // unitRichTB
            // 
            this.unitRichTB.BackColor = System.Drawing.Color.White;
            this.unitRichTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unitRichTB.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitRichTB.Location = new System.Drawing.Point(13, 391);
            this.unitRichTB.Name = "unitRichTB";
            this.unitRichTB.ReadOnly = true;
            this.unitRichTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.unitRichTB.ShowSelectionMargin = true;
            this.unitRichTB.Size = new System.Drawing.Size(245, 321);
            this.unitRichTB.TabIndex = 11;
            this.unitRichTB.TabStop = false;
            this.unitRichTB.Text = "";
            this.unitRichTB.TextChanged += new System.EventHandler(this.scrolltoBottom);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chatSendButton);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(1078, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 390);
            this.panel1.TabIndex = 24;
            this.panel1.Visible = false;
            // 
            // chatSendButton
            // 
            this.chatSendButton.Location = new System.Drawing.Point(154, 358);
            this.chatSendButton.Name = "chatSendButton";
            this.chatSendButton.Size = new System.Drawing.Size(75, 23);
            this.chatSendButton.TabIndex = 15;
            this.chatSendButton.Text = "Send";
            this.chatSendButton.UseVisualStyleBackColor = true;
            this.chatSendButton.Click += new System.EventHandler(this.chatSendButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 320);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 32);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chat:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.ShowSelectionMargin = true;
            this.richTextBox1.Size = new System.Drawing.Size(216, 276);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.scrolltoBottom);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.assignUnitButton);
            this.panel2.Controls.Add(this.assignUnitLbl1);
            this.panel2.Controls.Add(this.assignUnitTB);
            this.panel2.Location = new System.Drawing.Point(283, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 70);
            this.panel2.TabIndex = 25;
            this.panel2.Visible = false;
            // 
            // assignUnitButton
            // 
            this.assignUnitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.assignUnitButton.Enabled = false;
            this.assignUnitButton.Location = new System.Drawing.Point(142, 42);
            this.assignUnitButton.Name = "assignUnitButton";
            this.assignUnitButton.Size = new System.Drawing.Size(69, 23);
            this.assignUnitButton.TabIndex = 7;
            this.assignUnitButton.Text = "GO";
            this.assignUnitButton.UseVisualStyleBackColor = true;
            this.assignUnitButton.Click += new System.EventHandler(this.assignUnitButton_Click);
            // 
            // assignUnitLbl1
            // 
            this.assignUnitLbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.assignUnitLbl1.AutoSize = true;
            this.assignUnitLbl1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignUnitLbl1.Location = new System.Drawing.Point(8, 9);
            this.assignUnitLbl1.Name = "assignUnitLbl1";
            this.assignUnitLbl1.Size = new System.Drawing.Size(127, 18);
            this.assignUnitLbl1.TabIndex = 6;
            this.assignUnitLbl1.Text = "Platoon 1:   E4 to";
            // 
            // assignUnitTB
            // 
            this.assignUnitTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.assignUnitTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignUnitTB.Location = new System.Drawing.Point(142, 5);
            this.assignUnitTB.Name = "assignUnitTB";
            this.assignUnitTB.Size = new System.Drawing.Size(69, 26);
            this.assignUnitTB.TabIndex = 5;
            this.assignUnitTB.TextChanged += new System.EventHandler(this.assignUnitTB_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.stopButton4);
            this.panel3.Controls.Add(this.stopButton3);
            this.panel3.Controls.Add(this.stopButton2);
            this.panel3.Controls.Add(this.stopButton1);
            this.panel3.Controls.Add(this.p4StatusLabel);
            this.panel3.Controls.Add(this.p3StatusLabel);
            this.panel3.Controls.Add(this.p2StatusLabel);
            this.panel3.Controls.Add(this.p1StatusLabel);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(537, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 105);
            this.panel3.TabIndex = 26;
            // 
            // stopButton4
            // 
            this.stopButton4.Enabled = false;
            this.stopButton4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton4.Location = new System.Drawing.Point(164, 75);
            this.stopButton4.Name = "stopButton4";
            this.stopButton4.Size = new System.Drawing.Size(50, 23);
            this.stopButton4.TabIndex = 11;
            this.stopButton4.Tag = "4";
            this.stopButton4.Text = "Stop";
            this.stopButton4.UseVisualStyleBackColor = true;
            this.stopButton4.Click += new System.EventHandler(this.StopUnitMovementButton);
            // 
            // stopButton3
            // 
            this.stopButton3.Enabled = false;
            this.stopButton3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton3.Location = new System.Drawing.Point(164, 51);
            this.stopButton3.Name = "stopButton3";
            this.stopButton3.Size = new System.Drawing.Size(50, 23);
            this.stopButton3.TabIndex = 10;
            this.stopButton3.Tag = "3";
            this.stopButton3.Text = "Stop";
            this.stopButton3.UseVisualStyleBackColor = true;
            this.stopButton3.Click += new System.EventHandler(this.StopUnitMovementButton);
            // 
            // stopButton2
            // 
            this.stopButton2.Enabled = false;
            this.stopButton2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton2.Location = new System.Drawing.Point(164, 27);
            this.stopButton2.Name = "stopButton2";
            this.stopButton2.Size = new System.Drawing.Size(50, 23);
            this.stopButton2.TabIndex = 9;
            this.stopButton2.Tag = "2";
            this.stopButton2.Text = "Stop";
            this.stopButton2.UseVisualStyleBackColor = true;
            this.stopButton2.Click += new System.EventHandler(this.StopUnitMovementButton);
            // 
            // stopButton1
            // 
            this.stopButton1.Enabled = false;
            this.stopButton1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton1.Location = new System.Drawing.Point(164, 3);
            this.stopButton1.Name = "stopButton1";
            this.stopButton1.Size = new System.Drawing.Size(50, 23);
            this.stopButton1.TabIndex = 8;
            this.stopButton1.Tag = "1";
            this.stopButton1.Text = "Stop";
            this.stopButton1.UseVisualStyleBackColor = true;
            this.stopButton1.Click += new System.EventHandler(this.StopUnitMovementButton);
            // 
            // p4StatusLabel
            // 
            this.p4StatusLabel.AutoSize = true;
            this.p4StatusLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p4StatusLabel.Location = new System.Drawing.Point(89, 78);
            this.p4StatusLabel.Name = "p4StatusLabel";
            this.p4StatusLabel.Size = new System.Drawing.Size(64, 18);
            this.p4StatusLabel.TabIndex = 7;
            this.p4StatusLabel.Tag = "4";
            this.p4StatusLabel.Text = "At Base";
            // 
            // p3StatusLabel
            // 
            this.p3StatusLabel.AutoSize = true;
            this.p3StatusLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p3StatusLabel.Location = new System.Drawing.Point(89, 54);
            this.p3StatusLabel.Name = "p3StatusLabel";
            this.p3StatusLabel.Size = new System.Drawing.Size(64, 18);
            this.p3StatusLabel.TabIndex = 6;
            this.p3StatusLabel.Tag = "3";
            this.p3StatusLabel.Text = "At Base";
            // 
            // p2StatusLabel
            // 
            this.p2StatusLabel.AutoSize = true;
            this.p2StatusLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2StatusLabel.Location = new System.Drawing.Point(89, 30);
            this.p2StatusLabel.Name = "p2StatusLabel";
            this.p2StatusLabel.Size = new System.Drawing.Size(64, 18);
            this.p2StatusLabel.TabIndex = 5;
            this.p2StatusLabel.Tag = "2";
            this.p2StatusLabel.Text = "At Base";
            // 
            // p1StatusLabel
            // 
            this.p1StatusLabel.AutoSize = true;
            this.p1StatusLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1StatusLabel.Location = new System.Drawing.Point(89, 6);
            this.p1StatusLabel.Name = "p1StatusLabel";
            this.p1StatusLabel.Size = new System.Drawing.Size(64, 18);
            this.p1StatusLabel.TabIndex = 4;
            this.p1StatusLabel.Tag = "1";
            this.p1StatusLabel.Text = "At Base";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Platoon 4:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Platoon 3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Platoon 2:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Platoon 1:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.hvtpbPlus);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.nhvtLabel);
            this.panel4.Controls.Add(this.checkPanel);
            this.panel4.Location = new System.Drawing.Point(797, 12);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(402, 105);
            this.panel4.TabIndex = 27;
            // 
            // hvtpbPlus
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.Navy,
        System.Drawing.Color.Blue};
            cBlendItems2.iPoint = new float[] {
        0F,
        1F};
            this.hvtpbPlus.BarColorBlend = cBlendItems2;
            this.hvtpbPlus.BarColorSolid = System.Drawing.Color.SteelBlue;
            this.hvtpbPlus.BarColorSolidB = System.Drawing.Color.White;
            this.hvtpbPlus.BarPadding = new System.Windows.Forms.Padding(0);
            this.hvtpbPlus.BarStyleFill = ProgBar.ProgBarPlus.eBarStyle.Solid;
            this.hvtpbPlus.BarStyleLinear = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.hvtpbPlus.BarStyleTexture = null;
            this.hvtpbPlus.Corners.All = 0;
            this.hvtpbPlus.CylonMove = 5F;
            cFocalPoints2.CenterPoint = ((System.Drawing.PointF)(resources.GetObject("cFocalPoints2.CenterPoint")));
            cFocalPoints2.FocusScales = ((System.Drawing.PointF)(resources.GetObject("cFocalPoints2.FocusScales")));
            this.hvtpbPlus.FocalPoints = cFocalPoints2;
            this.hvtpbPlus.Location = new System.Drawing.Point(77, 3);
            this.hvtpbPlus.Name = "hvtpbPlus";
            this.hvtpbPlus.Orientation = ProgBar.ProgBarPlus.eOrientation.Vertical;
            this.hvtpbPlus.ShapeTextFont = new System.Drawing.Font("Arial Black", 30F);
            this.hvtpbPlus.Size = new System.Drawing.Size(25, 95);
            this.hvtpbPlus.TabIndex = 18;
            this.hvtpbPlus.TextFormat = "Process {1}% Done";
            this.hvtpbPlus.Value = 0;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 37);
            this.label8.TabIndex = 13;
            this.label8.Text = "Targets  Captured:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nhvtLabel
            // 
            this.nhvtLabel.AutoSize = true;
            this.nhvtLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhvtLabel.Location = new System.Drawing.Point(31, 54);
            this.nhvtLabel.Name = "nhvtLabel";
            this.nhvtLabel.Size = new System.Drawing.Size(21, 22);
            this.nhvtLabel.TabIndex = 14;
            this.nhvtLabel.Text = "0";
            // 
            // checkPanel
            // 
            this.checkPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.checkPanel.ColumnCount = 4;
            this.checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.checkPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkPanel.Location = new System.Drawing.Point(153, 0);
            this.checkPanel.Margin = new System.Windows.Forms.Padding(0);
            this.checkPanel.Name = "checkPanel";
            this.checkPanel.RowCount = 5;
            this.checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.checkPanel.Size = new System.Drawing.Size(245, 101);
            this.checkPanel.TabIndex = 4;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.hvtpb);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(50, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(208, 105);
            this.panel5.TabIndex = 8;
            this.panel5.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 18);
            this.label10.TabIndex = 30;
            this.label10.Text = "(drag to map)";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(59, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "HVTs:";
            // 
            // hvtpb
            // 
            this.hvtpb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hvtpb.Image = global::Exp2.Properties.Resources.hvticon;
            this.hvtpb.Location = new System.Drawing.Point(115, 14);
            this.hvtpb.Name = "hvtpb";
            this.hvtpb.Size = new System.Drawing.Size(78, 78);
            this.hvtpb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hvtpb.TabIndex = 28;
            this.hvtpb.TabStop = false;
            this.hvtpb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hvtpb_MouseDown);
            this.hvtpb.MouseEnter += new System.EventHandler(this.hvtpb_MouseEnter);
            this.hvtpb.MouseLeave += new System.EventHandler(this.hvtpb_MouseLeave);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Yellow;
            this.panel7.Location = new System.Drawing.Point(112, 11);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(84, 84);
            this.panel7.TabIndex = 31;
            this.panel7.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 886);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Quit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mapPanel
            // 
            this.mapPanel.AllowDrop = true;
            this.mapPanel.Location = new System.Drawing.Point(50, 152);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(714, 714);
            this.mapPanel.TabIndex = 29;
            this.mapPanel.Visible = false;
            this.mapPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.mapPanel_DragDrop);
            this.mapPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.mapPanel_DragEnter);
            this.mapPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseClick);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.richTextBox2);
            this.panel8.Location = new System.Drawing.Point(1078, 152);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(247, 102);
            this.panel8.TabIndex = 30;
            this.panel8.Visible = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.White;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(13, 14);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox2.ShowSelectionMargin = true;
            this.richTextBox2.Size = new System.Drawing.Size(216, 68);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 912);
            this.ControlBox = false;
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hvtpb)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox unitRichTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button chatSendButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button assignUnitButton;
        private System.Windows.Forms.Label assignUnitLbl1;
        private System.Windows.Forms.TextBox assignUnitTB;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button stopButton4;
        private System.Windows.Forms.Button stopButton3;
        private System.Windows.Forms.Button stopButton2;
        private System.Windows.Forms.Button stopButton1;
        private System.Windows.Forms.Label p4StatusLabel;
        private System.Windows.Forms.Label p3StatusLabel;
        private System.Windows.Forms.Label p2StatusLabel;
        private System.Windows.Forms.Label p1StatusLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label nhvtLabel;
        private System.Windows.Forms.TableLayoutPanel checkPanel;
        private ProgBar.ProgBarPlus hvtpbPlus;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox hvtpb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}