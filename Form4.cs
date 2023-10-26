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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data_Move.num_of_cells = "20";

            Data_Move.population_census1.Clear();
            Data_Move.population_census2.Clear();


            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1.Add(false);
            }
            for (int i = 0; i <= int.Parse(Data_Move.num_of_cells) * int.Parse(Data_Move.num_of_cells); i++)
            {
                Data_Move.population_census2.Add(false);
            }

            Data_Move.population_census1[179] = true; Data_Move.population_census1[180] = true; Data_Move.population_census1[203] = true; Data_Move.population_census1[226] = true; Data_Move.population_census1[248] = true; Data_Move.population_census1[270] = true; Data_Move.population_census1[291] = true; Data_Move.population_census1[311] = true; Data_Move.population_census1[312] = true;
            Data_Move.population_census2[143] = true; Data_Move.population_census2[144] = true; Data_Move.population_census2[165] = true; Data_Move.population_census2[206] = true; Data_Move.population_census2[186] = true; Data_Move.population_census2[226] = true; Data_Move.population_census2[245] = true; Data_Move.population_census2[263] = true; Data_Move.population_census2[264] = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data_Move.num_of_cells = "20";

            Data_Move.population_census1.Clear();
            Data_Move.population_census2.Clear();


            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1.Add(false);
            }
            for (int i = 0; i <= int.Parse(Data_Move.num_of_cells) * int.Parse(Data_Move.num_of_cells); i++)
            {
                Data_Move.population_census2.Add(false);
            }

            Data_Move.population_census1[115] = true; Data_Move.population_census1[116] = true; Data_Move.population_census1[117] = true; Data_Move.population_census1[118] = true; Data_Move.population_census1[119] = true; Data_Move.population_census1[120] = true; Data_Move.population_census1[137] = true; Data_Move.population_census1[138] = true; Data_Move.population_census1[139] = true; Data_Move.population_census1[140] = true; Data_Move.population_census1[141] = true; Data_Move.population_census1[142] = true;
            Data_Move.population_census2[84] = true; Data_Move.population_census2[85] = true; Data_Move.population_census2[86] = true; Data_Move.population_census2[87] = true; Data_Move.population_census2[88] = true; Data_Move.population_census2[89] = true; Data_Move.population_census2[104] = true; Data_Move.population_census2[105] = true; Data_Move.population_census2[106] = true; Data_Move.population_census2[107] = true; Data_Move.population_census2[108] = true; Data_Move.population_census2[109] = true;

            Data_Move.population_census1[122] = true; Data_Move.population_census1[123] = true; Data_Move.population_census1[144] = true; Data_Move.population_census1[145] = true; Data_Move.population_census1[166] = true; Data_Move.population_census1[167] = true; Data_Move.population_census1[188] = true; Data_Move.population_census1[189] = true; Data_Move.population_census1[210] = true; Data_Move.population_census1[211] = true; Data_Move.population_census1[232] = true; Data_Move.population_census1[233] = true;
            Data_Move.population_census2[91] = true; Data_Move.population_census2[92] = true; Data_Move.population_census2[111] = true; Data_Move.population_census2[112] = true; Data_Move.population_census2[131] = true; Data_Move.population_census2[132] = true; Data_Move.population_census2[151] = true; Data_Move.population_census2[152] = true; Data_Move.population_census2[171] = true; Data_Move.population_census2[172] = true; Data_Move.population_census2[191] = true; Data_Move.population_census2[192] = true;

            Data_Move.population_census2[227] = true; Data_Move.population_census2[228] = true; Data_Move.population_census2[229] = true; Data_Move.population_census2[230] = true; Data_Move.population_census2[231] = true; Data_Move.population_census2[232] = true; Data_Move.population_census2[247] = true; Data_Move.population_census2[248] = true; Data_Move.population_census2[249] = true; Data_Move.population_census2[250] = true; Data_Move.population_census2[251] = true; Data_Move.population_census2[252] = true;
            Data_Move.population_census1[272] = true; Data_Move.population_census1[273] = true; Data_Move.population_census1[274] = true; Data_Move.population_census1[275] = true; Data_Move.population_census1[276] = true; Data_Move.population_census1[277] = true; Data_Move.population_census1[294] = true; Data_Move.population_census1[295] = true; Data_Move.population_census1[296] = true; Data_Move.population_census1[297] = true; Data_Move.population_census1[298] = true; Data_Move.population_census1[299] = true;

            Data_Move.population_census1[181] = true; Data_Move.population_census1[182] = true; Data_Move.population_census1[203] = true; Data_Move.population_census1[204] = true; Data_Move.population_census1[225] = true; Data_Move.population_census1[226] = true; Data_Move.population_census1[247] = true; Data_Move.population_census1[248] = true; Data_Move.population_census1[269] = true; Data_Move.population_census1[270] = true; Data_Move.population_census1[291] = true; Data_Move.population_census1[292] = true;
            Data_Move.population_census2[144] = true; Data_Move.population_census2[145] = true; Data_Move.population_census2[164] = true; Data_Move.population_census2[165] = true; Data_Move.population_census2[184] = true; Data_Move.population_census2[185] = true; Data_Move.population_census2[204] = true; Data_Move.population_census2[205] = true; Data_Move.population_census2[224] = true; Data_Move.population_census2[225] = true; Data_Move.population_census2[244] = true; Data_Move.population_census2[245] = true;

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Data_Move.num_of_cells = "20";

            Data_Move.population_census1.Clear();
            Data_Move.population_census2.Clear();


            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1.Add(false);
            }
            for (int i = 0; i <= int.Parse(Data_Move.num_of_cells) * int.Parse(Data_Move.num_of_cells); i++)
            {
                Data_Move.population_census2.Add(false);
            }

            Data_Move.population_census1[207] = true; Data_Move.population_census1[208] = true; Data_Move.population_census1[209] = true; Data_Move.population_census1[229] = true; Data_Move.population_census1[230] = true; Data_Move.population_census1[231] = true; Data_Move.population_census1[251] = true; Data_Move.population_census1[252] = true; Data_Move.population_census1[253] = true;
            Data_Move.population_census2[168] = true; Data_Move.population_census2[169] = true; Data_Move.population_census2[170] = true; Data_Move.population_census2[188] = true; Data_Move.population_census2[189] = true; Data_Move.population_census2[190] = true; Data_Move.population_census2[208] = true; Data_Move.population_census2[209] = true; Data_Move.population_census2[210] = true;

            Data_Move.population_census1[276] = true; Data_Move.population_census1[277] = true; Data_Move.population_census1[278] = true; Data_Move.population_census1[298] = true; Data_Move.population_census1[299] = true; Data_Move.population_census1[300] = true; Data_Move.population_census1[320] = true; Data_Move.population_census1[321] = true; Data_Move.population_census1[322] = true;
            Data_Move.population_census2[231] = true; Data_Move.population_census2[232] = true; Data_Move.population_census2[233] = true; Data_Move.population_census2[251] = true; Data_Move.population_census2[252] = true; Data_Move.population_census2[253] = true; Data_Move.population_census2[271] = true; Data_Move.population_census2[272] = true; Data_Move.population_census2[273] = true;

            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("cosmos4.jpg");
            button1.BackgroundImage = Image.FromFile("f1.jpg");
            button2.BackgroundImage = Image.FromFile("f2.jpg");
            button3.BackgroundImage = Image.FromFile("f3.jpg");
            button4.BackgroundImage = Image.FromFile("f4.jpg");
            button5.BackgroundImage = Image.FromFile("f5.jpg");
            button6.BackgroundImage = Image.FromFile("f6.jpg");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Data_Move.num_of_cells = "20";

            Data_Move.population_census1.Clear();
            Data_Move.population_census2.Clear();


            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1.Add(false);
            }
            for (int i = 0; i <= int.Parse(Data_Move.num_of_cells) * int.Parse(Data_Move.num_of_cells); i++)
            {
                Data_Move.population_census2.Add(false);
            }

            Data_Move.population_census1[140] = true; Data_Move.population_census1[163] = true; Data_Move.population_census1[183] = true; Data_Move.population_census1[184] = true; Data_Move.population_census1[185] = true; 
            Data_Move.population_census2[107] = true; Data_Move.population_census2[128] = true; Data_Move.population_census2[146] = true; Data_Move.population_census2[147] = true; Data_Move.population_census2[148] = true;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Data_Move.num_of_cells = "20";

            Data_Move.population_census1.Clear();
            Data_Move.population_census2.Clear();


            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1.Add(false);
            }
            for (int i = 0; i <= int.Parse(Data_Move.num_of_cells) * int.Parse(Data_Move.num_of_cells); i++)
            {
                Data_Move.population_census2.Add(false);
            }

            Data_Move.population_census1[143] = true; Data_Move.population_census1[166] = true; Data_Move.population_census1[182] = true; Data_Move.population_census1[188] = true; Data_Move.population_census1[205] = true; Data_Move.population_census1[206] = true; Data_Move.population_census1[207] = true; Data_Move.population_census1[208] = true; Data_Move.population_census1[209] = true; Data_Move.population_census1[210] = true;
            Data_Move.population_census2[110] = true; Data_Move.population_census2[131] = true; Data_Move.population_census2[145] = true; Data_Move.population_census2[151] = true; Data_Move.population_census2[166] = true; Data_Move.population_census2[167] = true; Data_Move.population_census2[168] = true; Data_Move.population_census2[169] = true; Data_Move.population_census2[170] = true; Data_Move.population_census2[171] = true;

            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Data_Move.num_of_cells = "20";

            Data_Move.population_census1.Clear();
            Data_Move.population_census2.Clear();


            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1.Add(false);
            }
            for (int i = 0; i <= int.Parse(Data_Move.num_of_cells) * int.Parse(Data_Move.num_of_cells); i++)
            {
                Data_Move.population_census2.Add(false);
            }

            Data_Move.population_census2[131] = true; Data_Move.population_census2[132] = true; Data_Move.population_census2[152] = true; Data_Move.population_census2[171] = true; Data_Move.population_census2[169] = true; Data_Move.population_census2[209] = true; Data_Move.population_census2[207] = true; Data_Move.population_census2[226] = true; Data_Move.population_census2[246] = true; Data_Move.population_census2[247] = true;
            Data_Move.population_census1[166] = true; Data_Move.population_census1[167] = true; Data_Move.population_census1[189] = true; Data_Move.population_census1[210] = true; Data_Move.population_census1[208] = true; Data_Move.population_census1[252] = true; Data_Move.population_census1[250] = true; Data_Move.population_census1[271] = true; Data_Move.population_census1[293] = true; Data_Move.population_census1[294] = true;

            this.Close();
        }
    }
}
