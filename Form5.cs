using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Random rng = new Random();

            if(Data_Move.rules_of_life == 1)
            {
                radioButton1.Checked = true;
            }
            else if(Data_Move.rules_of_life == 2)
            {
                radioButton2.Checked = true;
            }
            else if (Data_Move.rules_of_life == 3)
            {
                radioButton3.Checked = true;
            }
            else if (Data_Move.rules_of_life == 4)
            {
                radioButton4.Checked = true;
            }
            else if(Data_Move.rules_of_life == 5)
            {
                radioButton5.Checked = true;
            }
            else if (Data_Move.rules_of_life == 6)
            {
                radioButton6.Checked = true;
            }
            else if (Data_Move.rules_of_life == 7)
            {
                radioButton7.Checked = true;
            }
            else 
            {
                radioButton8.Checked = true;
            }

            button1.BackgroundImage = Image.FromFile("p" + rng.Next(1, 4).ToString() + ".jpg");
            button2.BackgroundImage = Image.FromFile("p" + rng.Next(1, 4).ToString() + ".jpg");
            radioButton1.BackgroundImage = Image.FromFile("p4.jpg");
            radioButton2.BackgroundImage = Image.FromFile("p4.jpg");
            radioButton3.BackgroundImage = Image.FromFile("p4.jpg");
            radioButton4.BackgroundImage = Image.FromFile("p4.jpg");
            radioButton5.BackgroundImage = Image.FromFile("p4.jpg");
            radioButton6.BackgroundImage = Image.FromFile("p4.jpg");
            radioButton7.BackgroundImage = Image.FromFile("p4.jpg");
            radioButton8.BackgroundImage = Image.FromFile("p4.jpg");
            this.BackgroundImage = Image.FromFile("cosmos3.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Data_Move.rules_of_life = 1;
            }
            else if (radioButton2.Checked)
            {
                Data_Move.rules_of_life = 2;
            }
            else if (radioButton3.Checked)
            {
                Data_Move.rules_of_life = 3;
            }
            else if (radioButton4.Checked)
            {
                Data_Move.rules_of_life = 4;
            }
            else if (radioButton5.Checked)
            {
                Data_Move.rules_of_life = 5;
            }
            else if (radioButton6.Checked)
            {
                Data_Move.rules_of_life = 6;
            }
            else if (radioButton7.Checked)
            {
                Data_Move.rules_of_life = 7;
            }
            else
            {
                Data_Move.rules_of_life = 8;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
