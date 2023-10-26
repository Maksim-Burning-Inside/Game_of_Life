using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Game_of_Life
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data_Move.timer = trackBar1.Value;

            Random rng = new Random();
            string mus = rng.Next(1, 5).ToString() + ".wav";
            SoundPlayer sp = new SoundPlayer(mus);
            sp.Play();
            Data_Move.f1Cb = radioButton1.Checked;
            Data_Move.f1check = checkBox1.Checked;

            if (checkBox1.Checked)
                MessageBox.Show("Внимание! На полях малого размера игнорирование задержки привёдёт к очень резкому мельканию поколений. Людям, страдающим от эпилепсии рекомендуется отключить эту настройку!");
            try
            {
                if (Convert.ToInt32(textBox1.Text) > 2 && Convert.ToInt32(textBox1.Text) < 151)
                {
                    Data_Move.num_of_cells = textBox1.Text;
                    this.Close();
                }
                else
                    MessageBox.Show("Размер поля должен быть целым числом в пределах от 3 до 150");
            }
            catch
            {
                MessageBox.Show("Размер поля должен быть целым числом в пределах от 3 до 150");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data_Move.back = false;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Random rng = new Random();

            checkBox1.BackgroundImage = Image.FromFile("p4.jpg");
            radioButton1.BackgroundImage = Image.FromFile("p4.jpg");
            radioButton2.BackgroundImage = Image.FromFile("p4.jpg");
            button1.BackgroundImage = Image.FromFile("p" + rng.Next(1, 4).ToString() + ".jpg");
            button2.BackgroundImage = Image.FromFile("p" + rng.Next(1, 4).ToString() + ".jpg");
            this.BackgroundImage = Image.FromFile("cosmos2.jpg");

            textBox1.Text = Data_Move.num_of_cells;
            trackBar1.Value = Data_Move.timer;
            if(Data_Move.f1Cb)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            checkBox1.Checked = Data_Move.f1check;
        }
    }
}
