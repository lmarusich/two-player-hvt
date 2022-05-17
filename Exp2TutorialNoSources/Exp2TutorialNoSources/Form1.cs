using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp2TutorialNoSources
{
    public partial class Form1 : Form
    {
        int page = -1;
        bool pagechanged = false;
        PictureBox pb = new PictureBox();

        public Form1()
        {
            InitializeComponent();
        }
        private void linkLabelNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page++;
            updatePage();
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page--;
            updatePage();
        }

        private void updatePage()
        {
            if (page == -1)
            {
                panel2.Visible = false;
                linkLabelBack.Enabled = false;
                textBox1.TextAlign = HorizontalAlignment.Left;
                textBox1.Text = "\r\nWelcome!\r\n\r\nIn this game, you will work with a partner to complete several missions.\r\n\r\nIn each mission, your goal is to find and capture high value targets (HVTs).";
                linkLabelNext.Text = "Next";

            }
            if (page == 0)
            {
                linkLabelBack.Enabled = true;
                panel2.Visible = true;
                textBox2.Visible = false;
                linkLabelNext.Text = "Next";
            }
            if (page == 1)
            {
                textBox2.Visible = true;
                linkLabelNext.Text = "Next";
                textBox4.Visible = false;
            }
            if (page == 2)
            {
                panel2.Visible = true;
                textBox4.Visible = true;
                linkLabelNext.Text = "Start Tutorial";
            }

            if (page == 3)
            {
                panel2.Visible = false;
                textBox4.Visible = false;
                linkLabelBack.Enabled = false;
                loadTutorial();
                page = 4;


            }
            if (page == 4)
            {
                if (pagechanged)
                {
                    this.Size = new Size(699, 537);
                    panel1.Size = new Size(608, 243);
                    linkLabelNext.Location = new Point(477, 380);
                    linkLabelBack.Location = new Point(32, 380);
                    textBox1.Height = 226;
                    panel1.Controls.Remove(pb);
                }

                textBox1.Text = "\r\nWhen a platoon enters the same grid square as an active target, it automatically captures and returns the HVT to base";
                label1.Text = "More Information";
                linkLabelNext.Text = "Next";
                linkLabelBack.Enabled = false;

            }
            if (page == 5)
            {
                pagechanged = true;
                this.Size = new Size(698, 752);
                panel1.Size = new Size(608, 543);
                linkLabelNext.Location = new Point(482, 667);
                linkLabelBack.Location = new Point(32, 667);
                linkLabelBack.Enabled = true;
                textBox1.Height = 175;
                textBox1.Width = 500;
                textBox1.Location = new Point(100, 108);
                textBox1.Text = "\r\nMoving platoons can be stopped and reassigned";
                pb.BackgroundImage = Exp2TutorialNoSources.Properties.Resources.stopbutton;
                pb.BackgroundImageLayout = ImageLayout.Zoom;
                pb.Size = new System.Drawing.Size(585, 585);
                pb.Location = new Point(10, 70);
                panel1.Controls.Add(pb);
            }


            if (page == 6)
            {
                textBox1.Text = "\r\n- The location information is 50% likely to be accurate.\r\n\r\n- If the information is not accurate, it will only be off by one square";
                pb.BackgroundImage = Exp2TutorialNoSources.Properties.Resources.accuracy;
            }
            if (page == 7)
            {
                textBox1.Text = "\r\nYou will receive several pieces of intel information about a single target.";
                pb.BackgroundImage = Exp2TutorialNoSources.Properties.Resources.accuracy2;
            }
            if (page == 8)
            {
                textBox1.Text = "\r\n- Sometimes the information will be different.\r\n\r\n - However, the targets DO NOT MOVE.\r\n\r\n - Any differences are because each piece of information can be accurate or off by one square.";
                pb.BackgroundImage = Exp2TutorialNoSources.Properties.Resources.accuracy3;

            }
            if (page == 9)
            {
                textBox1.Text = "\r\n In some cases, the correct location can be inferred from conflicting intel updates.";
                pb.BackgroundImage = Exp2TutorialNoSources.Properties.Resources.accuracy4;

            }
            if (page == 10)
            {
                textBox1.Text = "\r\n- You are free to use the chat window to communicate with each other.\r\n\r\n - It is up to you to decide how much you want to communicate through chat.";
                pb.BackgroundImage = Exp2TutorialNoSources.Properties.Resources.chat1;
                pb.Size = new System.Drawing.Size(585, 375);
                pb.Location = new Point(10, 155);
                textBox1.Height = 150;
                linkLabelNext.Text = "Finish";
            }
            if (page == 11)
            {
                this.Close();  
            }
        }


        private void loadTutorial()
        {
            Form2 NewForm2 = new Form2();
            NewForm2.ShowDialog();

            //this.Close();
        }
    }
}
