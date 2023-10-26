using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Game_of_Life
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap buffer = new Bitmap(600, 600);

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rng = new Random();
            string mus = rng.Next(1, 5).ToString() + ".wav";
            SoundPlayer sp = new SoundPlayer(mus);
            sp.Play();

            this.BackgroundImage = Image.FromFile("cosmos.jpg");
            menuStrip1.BackgroundImage = Image.FromFile("cosmos.jpg");

            // Setting the form parameters

            this.Height = 702;
            this.Width = 654;

            // Calculate the size of one cell
            Data_Move.one_cells = (600 - (600 % int.Parse(Data_Move.num_of_cells))) / (int.Parse(Data_Move.num_of_cells));
            pictureBox1.Height = 602 - (602 % Data_Move.one_cells);
            pictureBox1.Width = 602 - (602 % Data_Move.one_cells);

            // Drawing a field for our cellular automaton

            Graphics cells = Graphics.FromImage(buffer);
            Pen pen_for_cells = new Pen(Color.Blue, 1);

            cells.FillRectangle(new SolidBrush(Color.Black), 0, 0, 602, 602);
            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, i, 0, i, 600);
            }
            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, 0, i, 600, i);
            }

            pictureBox1.Image = buffer;


            /* Create a list consisting of consecutive numbers of all cells.
             * Each number can be positive or negative. 
             * The number sign carries information about life in this cell.
             * Living cell of positive sign, dead cell of negative sign. */

            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1.Add(false);
            }
            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells)) * (int.Parse(Data_Move.num_of_cells)); i++)
            {
                Data_Move.population_census2.Add(false);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Click to Create Life in a Cell
            Random rng = new Random();
            Graphics cells = Graphics.FromImage(buffer);

            Point point_of_click = e.Location;
            int cell_alignment_x = point_of_click.X - (point_of_click.X % Data_Move.one_cells);
            int cell_alignment_y = point_of_click.Y - (point_of_click.Y % Data_Move.one_cells);

            Color color = new Color();
            color = Color.FromArgb(rng.Next(80, 255), rng.Next(80, 255), rng.Next(80, 255));

            //If the cell is dead, paint it black and animate it with its number and vice versa.

            int point_to_number_correlation = (cell_alignment_y / Data_Move.one_cells) * int.Parse(Data_Move.num_of_cells) + (cell_alignment_x / Data_Move.one_cells) + 1;
            point_to_number_correlation = point_to_number_correlation + 2 * (cell_alignment_y / Data_Move.one_cells);

            if (Data_Move.f1Cb && Data_Move.population_census1[point_to_number_correlation + int.Parse(Data_Move.num_of_cells) + 2] == false)
            {
                cells.FillRectangle(new SolidBrush(Color.White), cell_alignment_x + 1, cell_alignment_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                pictureBox1.Image = buffer;
                Data_Move.population_census1[point_to_number_correlation + int.Parse(Data_Move.num_of_cells) + 2] = true;
            }
            else if (Data_Move.f1Cb && Data_Move.population_census1[point_to_number_correlation + int.Parse(Data_Move.num_of_cells) + 2])
            {
                cells.FillRectangle(new SolidBrush(Color.Black), cell_alignment_x + 1, cell_alignment_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                pictureBox1.Image = buffer;
                Data_Move.population_census1[point_to_number_correlation + int.Parse(Data_Move.num_of_cells) + 2] = false;
            }
            else if (Data_Move.f1Cb == false && Data_Move.population_census1[point_to_number_correlation + int.Parse(Data_Move.num_of_cells) + 2])
            {
                cells.FillRectangle(new SolidBrush(Color.Black), cell_alignment_x + 1, cell_alignment_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                pictureBox1.Image = buffer;
                Data_Move.population_census1[point_to_number_correlation + int.Parse(Data_Move.num_of_cells) + 2] = true;
            }
            else
            {
                cells.FillRectangle(new SolidBrush(color), cell_alignment_x + 1, cell_alignment_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                pictureBox1.Image = buffer;
                Data_Move.population_census1[point_to_number_correlation + int.Parse(Data_Move.num_of_cells) + 2] = true;
            }
        }

        private async void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;

            Data_Move.no_evolution = false;
            Local_Method change_generation = new Local_Method();
            Graphics cells = Graphics.FromImage(buffer);
            cells.FillRectangle(new SolidBrush(Color.Black), 0, 0, 602, 602);

            Form2 f2 = new Form2();
            if (Data_Move.rules_of_life == 1)
            {
                for (; ; )
                {
                    Data_Move.no_evolution = false;
                    await Task.Run(() => change_generation.Change_generation1(cells, buffer));
                    pictureBox1.Refresh();
                    if (Data_Move.no_evolution)
                        break;
                }
            }
            else if(Data_Move.rules_of_life == 2)
            {
                for (; ; )
                {
                    Data_Move.no_evolution = false;
                    await Task.Run(() => change_generation.Change_generation2(cells, buffer));
                    pictureBox1.Refresh();
                    if (Data_Move.no_evolution)
                        break;
                }
            }
            else if (Data_Move.rules_of_life == 3)
            {
                for (; ; )
                {
                    Data_Move.no_evolution = false;
                    await Task.Run(() => change_generation.Change_generation3(cells, buffer));
                    pictureBox1.Refresh();
                    if (Data_Move.no_evolution)
                        break;
                }
            }
            else if (Data_Move.rules_of_life == 4)
            {
                for (; ; )
                {
                    Data_Move.no_evolution = false;
                    await Task.Run(() => change_generation.Change_generation4(cells, buffer));
                    pictureBox1.Refresh();
                    if (Data_Move.no_evolution)
                        break;
                }
            }
            else if (Data_Move.rules_of_life == 5)
            {
                for (; ; )
                {
                    Data_Move.no_evolution = false;
                    await Task.Run(() => change_generation.Change_generation5(cells, buffer));
                    pictureBox1.Refresh();
                    if (Data_Move.no_evolution)
                        break;
                }
            }
            else if (Data_Move.rules_of_life == 6)
            {
                for (; ; )
                {
                    Data_Move.no_evolution = false;
                    await Task.Run(() => change_generation.Change_generation6(cells, buffer));
                    pictureBox1.Refresh();
                    if (Data_Move.no_evolution)
                        break;
                }
            }
            else if (Data_Move.rules_of_life == 7)
            {
                for (; ; )
                {
                    Data_Move.no_evolution = false;
                    await Task.Run(() => change_generation.Change_generation7(cells, buffer));
                    pictureBox1.Refresh();
                    if (Data_Move.no_evolution)
                        break;
                }
            }
            else
            {
                for (; ; )
                {
                    Data_Move.no_evolution = false;
                    await Task.Run(() => change_generation.Change_generation8(cells, buffer));
                    pictureBox1.Refresh();
                    if (Data_Move.no_evolution)
                        break;
                }
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen pen_for_cells = new Pen(Color.Blue, 1);
            Graphics cells = Graphics.FromImage(buffer);

            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, i, 0, i, 600);
            }
            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, 0, i, 600, i);
            }

            Data_Move.no_evolution = true;
            pictureBox1.Enabled = true;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Move.no_evolution = true;

            Form3 open = new Form3();
            open.ShowDialog();

            pictureBox1.Enabled = true;
            Data_Move.one_cells = (600 - (600 % int.Parse(Data_Move.num_of_cells))) / (int.Parse(Data_Move.num_of_cells));
            Graphics cells = Graphics.FromImage(buffer);
            Pen pen_for_cells = new Pen(Color.Blue, 1);

            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, i, 0, i, 600);
            }
            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, 0, i, 600, i);
            }

            pictureBox1.Refresh();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Move.no_evolution = true;

            Form2 open = new Form2();
            open.ShowDialog();

            if (Data_Move.back)
            {
                Data_Move.one_cells = (600 - (600 % int.Parse(Data_Move.num_of_cells))) / (int.Parse(Data_Move.num_of_cells));
                Graphics cells = Graphics.FromImage(buffer);
                Pen pen_for_cells = new Pen(Color.Blue, 1);
                cells.FillRectangle(new SolidBrush(Color.Black), 0, 0, 602, 602);

                for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
                {
                    cells.DrawLine(pen_for_cells, i, 0, i, 600);
                }
                for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
                {
                    cells.DrawLine(pen_for_cells, 0, i, 600, i);
                }

                pictureBox1.Location = new Point(pictureBox1.Location.X + ((pictureBox1.Height - (600 - (600 % int.Parse(Data_Move.num_of_cells)))) / 2), pictureBox1.Location.Y + ((pictureBox1.Height - (600 - (600 % int.Parse(Data_Move.num_of_cells))))) / 2);
                pictureBox1.Height = 600 - (600 % int.Parse(Data_Move.num_of_cells));
                pictureBox1.Width = 600 - (600 % int.Parse(Data_Move.num_of_cells));
                pictureBox1.Image = buffer;


                Data_Move.population_census1.Clear();
                Data_Move.population_census2.Clear();

                for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
                {
                    Data_Move.population_census1.Add(false);
                }
                for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells)) * (int.Parse(Data_Move.num_of_cells)); i++)
                {
                    Data_Move.population_census2.Add(false);
                }
            }
            else
            {
                Data_Move.back = true;
                Data_Move.one_cells = (600 - (600 % int.Parse(Data_Move.num_of_cells))) / (int.Parse(Data_Move.num_of_cells));
                Graphics cells = Graphics.FromImage(buffer);
                Pen pen_for_cells = new Pen(Color.Blue, 1);

                for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
                {
                    cells.DrawLine(pen_for_cells, i, 0, i, 600);
                }
                for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
                {
                    cells.DrawLine(pen_for_cells, 0, i, 600, i);
                }
            }
            pictureBox1.Enabled = true;
            pictureBox1.Refresh();
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Move.no_evolution = true;

            Thread.Sleep(1000);

            Random rng = new Random();
            Graphics cells = Graphics.FromImage(buffer);
            Color color = new Color();
            int j = 0;

            for (int i = 0; i < Data_Move.population_census2.Count; i++)
            {
                if (rng.Next(-1, 1) == 0)
                {
                    if (Data_Move.f1Cb)
                    {
                        cells.FillRectangle(new SolidBrush(Color.White), (i % Convert.ToInt32(Data_Move.num_of_cells)) * Data_Move.one_cells + 1, j * Data_Move.one_cells + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                        pictureBox1.Image = buffer;
                        Data_Move.population_census1[i] = true;
                    }
                    else
                    {
                        color = Color.FromArgb(rng.Next(80, 255), rng.Next(80, 255), rng.Next(80, 255));

                        cells.FillRectangle(new SolidBrush(color), (i % Convert.ToInt32(Data_Move.num_of_cells)) * Data_Move.one_cells + 1, j * Data_Move.one_cells + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                        pictureBox1.Image = buffer;
                        Data_Move.population_census1[i] = true;

                    }
                }
                else
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), (i % Convert.ToInt32(Data_Move.num_of_cells)) * Data_Move.one_cells + 1, j * Data_Move.one_cells + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                    pictureBox1.Image = buffer;
                    Data_Move.population_census1[i] = false;
                }
                if ((i + 1) % Convert.ToInt32(Data_Move.num_of_cells) == 0)
                    j++;
            }
            pictureBox1.Refresh();
        }

        private void figureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Move.no_evolution = true;
            Random rng = new Random();

            Form4 f4 = new Form4();
            f4.ShowDialog();

            Graphics cells = Graphics.FromImage(buffer);
            Data_Move.one_cells = (600 - (600 % int.Parse(Data_Move.num_of_cells))) / (int.Parse(Data_Move.num_of_cells));
            Pen pen_for_cells = new Pen(Color.Blue, 1);

            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, i, 0, i, 600);
            }
            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, 0, i, 600, i);
            }

            Color color = new Color();

            if (Data_Move.f1Cb)
            {
                for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
                {
                    int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                    int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;
                    if (Data_Move.population_census2[i])
                    {
                        cells.FillRectangle(new SolidBrush(Color.White), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                    }
                    else
                    {
                        cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
                {
                    color = Color.FromArgb(rng.Next(80, 255), rng.Next(80, 255), rng.Next(80, 255));
                    int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                    int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;
                    if (Data_Move.population_census2[i])
                    {
                        cells.FillRectangle(new SolidBrush(color), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                    }
                    else
                    {
                        cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                    }
                }
            }

            pictureBox1.Location = new Point(pictureBox1.Location.X + ((pictureBox1.Height - (600 - (600 % int.Parse(Data_Move.num_of_cells)))) / 2), pictureBox1.Location.Y + ((pictureBox1.Height - (600 - (600 % int.Parse(Data_Move.num_of_cells))))) / 2);
            pictureBox1.Height = 600 - (600 % int.Parse(Data_Move.num_of_cells));
            pictureBox1.Width = 600 - (600 % int.Parse(Data_Move.num_of_cells));

            pictureBox1.Image = buffer;
            pictureBox1.Refresh();
        }

        private void rulesOfLifeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Move.no_evolution = true;

            Form5 f5 = new Form5();
            f5.ShowDialog();

            pictureBox1.Enabled = true;
            Data_Move.one_cells = (600 - (600 % int.Parse(Data_Move.num_of_cells))) / (int.Parse(Data_Move.num_of_cells));
            Graphics cells = Graphics.FromImage(buffer);
            Pen pen_for_cells = new Pen(Color.Blue, 1);

            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, i, 0, i, 600);
            }
            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, 0, i, 600, i);
            }

            pictureBox1.Refresh();
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Move.no_evolution = true;

            Thread.Sleep(1000);

            pictureBox1.Enabled = true;

            Graphics cells = Graphics.FromImage(buffer);
            Pen pen_for_cells = new Pen(Color.Blue, 1);

            cells.FillRectangle(new SolidBrush(Color.Black), 0, 0, 602, 602);
            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, i, 0, i, 600);
            }
            for (int i = Data_Move.one_cells; i <= 600 + Data_Move.one_cells; i = i + Data_Move.one_cells)
            {
                cells.DrawLine(pen_for_cells, 0, i, 600, i);
            }

            pictureBox1.Image = buffer;

            Data_Move.population_census1.Clear();
            Data_Move.population_census2.Clear();

            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1.Add(false);
            }
            for (int i = 1; i <= (int.Parse(Data_Move.num_of_cells)) * (int.Parse(Data_Move.num_of_cells)); i++)
            {
                Data_Move.population_census2.Add(false);
            }
        }
    }
}
