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
    public partial class Form3 : Form
    {
        string tbtext = Form2.tbtext;
        bool arrow = Form2.arrow;
        bool blue = Form2.blue;
        string direction = Form2.direction;

        public Form3()
        {
            InitializeComponent();
            textBox1.Text = tbtext;
            if (!arrow)
            {
                pictureBox1.Visible = false;
                textBox1.Dock = DockStyle.Fill;
            }
            if (!blue)
            {
                panel1.BackColor = Color.Green;
                textBox1.ForeColor = Color.Green;
            }
            if (direction == "left")
            {
                pictureBox1.Image = Exp2TutorialNoSources.Properties.Resources.Picture11;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
