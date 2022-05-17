namespace Exp2Server
{
    partial class Form1
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
            ProgBar.cBlendItems cBlendItems1 = new ProgBar.cBlendItems();
            ProgBar.cFocalPoints cFocalPoints1 = new ProgBar.cFocalPoints();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.txtDataRx = new System.Windows.Forms.TextBox();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.s3statusLabel = new System.Windows.Forms.Label();
            this.s2statusLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.unitRichTB = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.c3radioButton = new System.Windows.Forms.RadioButton();
            this.c1radioButton = new System.Windows.Forms.RadioButton();
            this.c2radioButton = new System.Windows.Forms.RadioButton();
            this.s2checkPanel = new System.Windows.Forms.TableLayoutPanel();
            this.s3checkPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nhvtLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.hvtpbPlus = new ProgBar.ProgBarPlus();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.statusPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.White;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(138, 40);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(71, 20);
            this.timeLabel.TabIndex = 18;
            this.timeLabel.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Time:";
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(72, 78);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 15;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // txtDataRx
            // 
            this.txtDataRx.BackColor = System.Drawing.Color.White;
            this.txtDataRx.Location = new System.Drawing.Point(780, 12);
            this.txtDataRx.Multiline = true;
            this.txtDataRx.Name = "txtDataRx";
            this.txtDataRx.ReadOnly = true;
            this.txtDataRx.Size = new System.Drawing.Size(275, 108);
            this.txtDataRx.TabIndex = 13;
            this.txtDataRx.TabStop = false;
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.statusPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statusPanel.Controls.Add(this.s3statusLabel);
            this.statusPanel.Controls.Add(this.s2statusLabel);
            this.statusPanel.Controls.Add(this.startButton);
            this.statusPanel.Controls.Add(this.timeLabel);
            this.statusPanel.Controls.Add(this.label1);
            this.statusPanel.Controls.Add(this.label3);
            this.statusPanel.Controls.Add(this.label2);
            this.statusPanel.Location = new System.Drawing.Point(12, 12);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(220, 108);
            this.statusPanel.TabIndex = 20;
            // 
            // s3statusLabel
            // 
            this.s3statusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.s3statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s3statusLabel.Location = new System.Drawing.Point(33, 40);
            this.s3statusLabel.Name = "s3statusLabel";
            this.s3statusLabel.Size = new System.Drawing.Size(90, 20);
            this.s3statusLabel.TabIndex = 3;
            this.s3statusLabel.Text = "Waiting...";
            // 
            // s2statusLabel
            // 
            this.s2statusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.s2statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s2statusLabel.Location = new System.Drawing.Point(33, 11);
            this.s2statusLabel.Name = "s2statusLabel";
            this.s2statusLabel.Size = new System.Drawing.Size(90, 20);
            this.s2statusLabel.TabIndex = 2;
            this.s2statusLabel.Text = "Waiting...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "S3:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "S2:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.unitRichTB);
            this.panel6.Location = new System.Drawing.Point(780, 152);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(275, 725);
            this.panel6.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Intel:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Spot Reports:";
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
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.s2checkPanel);
            this.panel1.Controls.Add(this.s3checkPanel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(251, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 108);
            this.panel1.TabIndex = 25;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(78, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(89, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Save files to:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "4",
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18"});
            this.comboBox1.Location = new System.Drawing.Point(40, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(42, 24);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.Text = "4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(416, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(85, 91);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(5, 26);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 22);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Limited";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(5, 53);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(77, 22);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Shared";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(212, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 91);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reliability:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(5, 61);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(102, 21);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Incongruent";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(5, 18);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(60, 21);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "None";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton5.Location = new System.Drawing.Point(5, 39);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(94, 21);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.Text = "Congruent";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.c3radioButton);
            this.groupBox3.Controls.Add(this.c1radioButton);
            this.groupBox3.Controls.Add(this.c2radioButton);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(329, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(80, 91);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Intel Amt:";
            // 
            // c3radioButton
            // 
            this.c3radioButton.AutoSize = true;
            this.c3radioButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c3radioButton.Location = new System.Drawing.Point(25, 61);
            this.c3radioButton.Name = "c3radioButton";
            this.c3radioButton.Size = new System.Drawing.Size(35, 22);
            this.c3radioButton.TabIndex = 3;
            this.c3radioButton.Text = "3";
            this.c3radioButton.UseVisualStyleBackColor = true;
            // 
            // c1radioButton
            // 
            this.c1radioButton.AutoSize = true;
            this.c1radioButton.Checked = true;
            this.c1radioButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1radioButton.Location = new System.Drawing.Point(25, 18);
            this.c1radioButton.Name = "c1radioButton";
            this.c1radioButton.Size = new System.Drawing.Size(35, 22);
            this.c1radioButton.TabIndex = 1;
            this.c1radioButton.TabStop = true;
            this.c1radioButton.Text = "1";
            this.c1radioButton.UseVisualStyleBackColor = true;
            // 
            // c2radioButton
            // 
            this.c2radioButton.AutoSize = true;
            this.c2radioButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2radioButton.Location = new System.Drawing.Point(25, 39);
            this.c2radioButton.Name = "c2radioButton";
            this.c2radioButton.Size = new System.Drawing.Size(35, 22);
            this.c2radioButton.TabIndex = 2;
            this.c2radioButton.Text = "2";
            this.c2radioButton.UseVisualStyleBackColor = true;
            // 
            // s2checkPanel
            // 
            this.s2checkPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.s2checkPanel.ColumnCount = 4;
            this.s2checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.s2checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.s2checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.s2checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.s2checkPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.s2checkPanel.Location = new System.Drawing.Point(0, 0);
            this.s2checkPanel.Margin = new System.Windows.Forms.Padding(0);
            this.s2checkPanel.Name = "s2checkPanel";
            this.s2checkPanel.RowCount = 5;
            this.s2checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s2checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s2checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s2checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s2checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s2checkPanel.Size = new System.Drawing.Size(156, 104);
            this.s2checkPanel.TabIndex = 31;
            this.s2checkPanel.Visible = false;
            // 
            // s3checkPanel
            // 
            this.s3checkPanel.BackColor = System.Drawing.Color.ForestGreen;
            this.s3checkPanel.ColumnCount = 4;
            this.s3checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.s3checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.s3checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.s3checkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.s3checkPanel.Location = new System.Drawing.Point(158, 0);
            this.s3checkPanel.Margin = new System.Windows.Forms.Padding(0);
            this.s3checkPanel.Name = "s3checkPanel";
            this.s3checkPanel.RowCount = 5;
            this.s3checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s3checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s3checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s3checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s3checkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.s3checkPanel.Size = new System.Drawing.Size(156, 104);
            this.s3checkPanel.TabIndex = 32;
            this.s3checkPanel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nhvtLabel);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.hvtpbPlus);
            this.panel2.Location = new System.Drawing.Point(338, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 100);
            this.panel2.TabIndex = 30;
            this.panel2.Visible = false;
            // 
            // nhvtLabel
            // 
            this.nhvtLabel.AutoSize = true;
            this.nhvtLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhvtLabel.Location = new System.Drawing.Point(28, 55);
            this.nhvtLabel.Name = "nhvtLabel";
            this.nhvtLabel.Size = new System.Drawing.Size(21, 22);
            this.nhvtLabel.TabIndex = 28;
            this.nhvtLabel.Text = "0";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 37);
            this.label8.TabIndex = 27;
            this.label8.Text = "Targets  Captured:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // hvtpbPlus
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.Navy,
        System.Drawing.Color.Blue};
            cBlendItems1.iPoint = new float[] {
        0F,
        1F};
            this.hvtpbPlus.BarColorBlend = cBlendItems1;
            this.hvtpbPlus.BarColorSolid = System.Drawing.Color.SteelBlue;
            this.hvtpbPlus.BarColorSolidB = System.Drawing.Color.White;
            this.hvtpbPlus.BarPadding = new System.Windows.Forms.Padding(0);
            this.hvtpbPlus.BarStyleFill = ProgBar.ProgBarPlus.eBarStyle.Solid;
            this.hvtpbPlus.BarStyleLinear = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.hvtpbPlus.BarStyleTexture = null;
            this.hvtpbPlus.Corners.All = 0;
            this.hvtpbPlus.CylonMove = 5F;
            cFocalPoints1.CenterPoint = ((System.Drawing.PointF)(resources.GetObject("cFocalPoints1.CenterPoint")));
            cFocalPoints1.FocusScales = ((System.Drawing.PointF)(resources.GetObject("cFocalPoints1.FocusScales")));
            this.hvtpbPlus.FocalPoints = cFocalPoints1;
            this.hvtpbPlus.Location = new System.Drawing.Point(85, 2);
            this.hvtpbPlus.Name = "hvtpbPlus";
            this.hvtpbPlus.Orientation = ProgBar.ProgBarPlus.eOrientation.Vertical;
            this.hvtpbPlus.ShapeTextFont = new System.Drawing.Font("Arial Black", 30F);
            this.hvtpbPlus.Size = new System.Drawing.Size(25, 95);
            this.hvtpbPlus.TabIndex = 29;
            this.hvtpbPlus.TextFormat = "Process {1}% Done";
            this.hvtpbPlus.Value = 0;
            // 
            // mapPanel
            // 
            this.mapPanel.Location = new System.Drawing.Point(50, 152);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(714, 714);
            this.mapPanel.TabIndex = 21;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton7);
            this.groupBox4.Controls.Add(this.radioButton6);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(129, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(76, 90);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sources?";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6.Location = new System.Drawing.Point(7, 29);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(51, 22);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Yes";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton7.Location = new System.Drawing.Point(7, 56);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(46, 22);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "No";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(1, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(115, 50);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save files to:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBox1);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(1, 54);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(115, 46);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "HVT #:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 904);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.txtDataRx);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Server";
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox txtDataRx;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label s3statusLabel;
        private System.Windows.Forms.Label s2statusLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox unitRichTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton c3radioButton;
        private System.Windows.Forms.RadioButton c1radioButton;
        private System.Windows.Forms.RadioButton c2radioButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label nhvtLabel;
        private System.Windows.Forms.Label label8;
        private ProgBar.ProgBarPlus hvtpbPlus;
        private System.Windows.Forms.TableLayoutPanel s2checkPanel;
        private System.Windows.Forms.TableLayoutPanel s3checkPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

