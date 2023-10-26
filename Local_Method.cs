using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using System.Threading;
using System.Drawing;

namespace Game_of_Life
{
    class Local_Method
    {
        // This method counts how many neighbors each cell located on the torus has.

        public void Change_generation1(Graphics cells, Bitmap buffer)
        {
            Form1 f1 = new Form1();

            for (int i = 1; i <= int.Parse(Data_Move.num_of_cells) + 2; i++)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + i];
            }

            int t = 1;
            for (int i = (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1[i - 1] = Data_Move.population_census1[t + int.Parse(Data_Move.num_of_cells) + 2];
                t++;
            }

            for (int i = int.Parse(Data_Move.num_of_cells) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i + (int.Parse(Data_Move.num_of_cells))];
            }

            for (int i = 2 * (int.Parse(Data_Move.num_of_cells) + 2) - 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i - (int.Parse(Data_Move.num_of_cells))];
            }

            Data_Move.population_census1[0] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 2];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2) - 1] = Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 3];
            Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 1] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1)] = Data_Move.population_census1[2 * (int.Parse(Data_Move.num_of_cells) + 2) - 2];

            Data_Move.population_census3.Clear();
            Data_Move.population_census3.AddRange(Data_Move.population_census1);

            int n, m, around_a_life = 0, j = 0;
            n = int.Parse(Data_Move.num_of_cells) + 2;
            m = int.Parse(Data_Move.num_of_cells) + 2;

            for (int i = 0; i < Data_Move.population_census1.LongCount(); i++)
            {
                if (((i + 1) % n) != 0 && (((i + 1) - 1) % n) != 0 && ((i + 1) - n) >= 1 && (((i + 1) + n) <= m * n))
                {
                    Data_Move.population_census2[j] = Data_Move.population_census1[i];
                    if (Data_Move.population_census1[(i + 1) - n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1)])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[i] == false && around_a_life == 3)
                    {
                        Data_Move.population_census2[j] = true;
                        Data_Move.population_census3[i] = true;
                    }
                    if (Data_Move.population_census1[i] && around_a_life != 3 && around_a_life != 2)
                    {
                        Data_Move.population_census2[j] = false;
                        Data_Move.population_census3[i] = false;
                    }
                    j++;
                }
                around_a_life = 0;
            }
            Random rng = new Random();
            Color color = new Color();

            for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
            {
                int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;


                if (Data_Move.f1Cb && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb && Data_Move.population_census2[i] == true)
                {
                    cells.FillRectangle(new SolidBrush(Color.White), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb == false && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else
                {
                    color = Color.FromArgb(rng.Next(80, 255), rng.Next(80, 255), rng.Next(250, 255));
                    cells.FillRectangle(new SolidBrush(color), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
            }

            Data_Move.population_census1.Clear();
            Data_Move.population_census1.AddRange(Data_Move.population_census3);

            f1.pictureBox1.Image = buffer;

            if (Data_Move.f1check == false)
                Thread.Sleep(100 * Data_Move.timer);
        }





        public void Change_generation2(Graphics cells, Bitmap buffer)
        {
            Form1 f1 = new Form1();

            for (int i = 1; i <= int.Parse(Data_Move.num_of_cells) + 2; i++)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + i];
            }

            int t = 1;
            for (int i = (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1[i - 1] = Data_Move.population_census1[t + int.Parse(Data_Move.num_of_cells) + 2];
                t++;
            }

            for (int i = int.Parse(Data_Move.num_of_cells) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i + (int.Parse(Data_Move.num_of_cells))];
            }

            for (int i = 2 * (int.Parse(Data_Move.num_of_cells) + 2) - 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i - (int.Parse(Data_Move.num_of_cells))];
            }

            Data_Move.population_census1[0] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 2];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2) - 1] = Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 3];
            Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 1] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1)] = Data_Move.population_census1[2 * (int.Parse(Data_Move.num_of_cells) + 2) - 2];

            Data_Move.population_census3.Clear();
            Data_Move.population_census3.AddRange(Data_Move.population_census1);

            int n, m, around_a_life = 0, j = 0;
            n = int.Parse(Data_Move.num_of_cells) + 2;
            m = int.Parse(Data_Move.num_of_cells) + 2;

            for (int i = 0; i < Data_Move.population_census1.LongCount(); i++)
            {
                if (((i + 1) % n) != 0 && (((i + 1) - 1) % n) != 0 && ((i + 1) - n) >= 1 && (((i + 1) + n) <= m * n))
                {
                    Data_Move.population_census2[j] = Data_Move.population_census1[i];
                    if (Data_Move.population_census1[(i + 1) - n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1)])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[i] == false && around_a_life == 3)
                    {
                        Data_Move.population_census2[j] = true;
                        Data_Move.population_census3[i] = true;
                    }
                    j++;
                }
                around_a_life = 0;
            }
            Random rng = new Random();
            Color color = new Color();

            for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
            {
                int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;


                if (Data_Move.f1Cb && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb && Data_Move.population_census2[i] == true)
                {
                    cells.FillRectangle(new SolidBrush(Color.White), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb == false && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else
                {
                    color = Color.FromArgb(rng.Next(250, 255), rng.Next(80, 255), rng.Next(80, 255));
                    cells.FillRectangle(new SolidBrush(color), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
            }

            Data_Move.population_census1.Clear();
            Data_Move.population_census1.AddRange(Data_Move.population_census3);

            f1.pictureBox1.Image = buffer;

            if (Data_Move.f1check == false)
                Thread.Sleep(100 * Data_Move.timer);
        }





        public void Change_generation3(Graphics cells, Bitmap buffer)
        {
            Form1 f1 = new Form1();

            for (int i = 1; i <= int.Parse(Data_Move.num_of_cells) + 2; i++)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + i];
            }

            int t = 1;
            for (int i = (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1[i - 1] = Data_Move.population_census1[t + int.Parse(Data_Move.num_of_cells) + 2];
                t++;
            }

            for (int i = int.Parse(Data_Move.num_of_cells) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i + (int.Parse(Data_Move.num_of_cells))];
            }

            for (int i = 2 * (int.Parse(Data_Move.num_of_cells) + 2) - 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i - (int.Parse(Data_Move.num_of_cells))];
            }

            Data_Move.population_census1[0] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 2];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2) - 1] = Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 3];
            Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 1] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1)] = Data_Move.population_census1[2 * (int.Parse(Data_Move.num_of_cells) + 2) - 2];

            Data_Move.population_census3.Clear();
            Data_Move.population_census3.AddRange(Data_Move.population_census1);

            int n, m, around_a_life = 0, j = 0;
            n = int.Parse(Data_Move.num_of_cells) + 2;
            m = int.Parse(Data_Move.num_of_cells) + 2;

            for (int i = 0; i < Data_Move.population_census1.LongCount(); i++)
            {
                if (((i + 1) % n) != 0 && (((i + 1) - 1) % n) != 0 && ((i + 1) - n) >= 1 && (((i + 1) + n) <= m * n))
                {
                    Data_Move.population_census2[j] = Data_Move.population_census1[i];
                    if (Data_Move.population_census1[(i + 1) - n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1)])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[i] == false && (around_a_life == 5 || around_a_life == 6 || around_a_life == 7 || around_a_life == 8))
                    {
                        Data_Move.population_census2[j] = true;
                        Data_Move.population_census3[i] = true;
                    }
                    if (Data_Move.population_census1[i] && (around_a_life == 0 || around_a_life == 1 || around_a_life == 2 || around_a_life == 3))
                    {
                        Data_Move.population_census2[j] = false;
                        Data_Move.population_census3[i] = false;
                    }
                    j++;
                }
                around_a_life = 0;
            }
            Random rng = new Random();
            Color color = new Color();

            for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
            {
                int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;


                if (Data_Move.f1Cb && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb && Data_Move.population_census2[i] == true)
                {
                    cells.FillRectangle(new SolidBrush(Color.White), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb == false && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else
                {
                    color = Color.FromArgb(rng.Next(250, 255), rng.Next(80, 255), rng.Next(80, 255));
                    cells.FillRectangle(new SolidBrush(color), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
            }

            Data_Move.population_census1.Clear();
            Data_Move.population_census1.AddRange(Data_Move.population_census3);

            f1.pictureBox1.Image = buffer;

            if (Data_Move.f1check == false)
                Thread.Sleep(100 * Data_Move.timer);
        }





        public void Change_generation4(Graphics cells, Bitmap buffer)
        {
            Form1 f1 = new Form1();

            for (int i = 1; i <= int.Parse(Data_Move.num_of_cells) + 2; i++)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + i];
            }

            int t = 1;
            for (int i = (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1[i - 1] = Data_Move.population_census1[t + int.Parse(Data_Move.num_of_cells) + 2];
                t++;
            }

            for (int i = int.Parse(Data_Move.num_of_cells) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i + (int.Parse(Data_Move.num_of_cells))];
            }

            for (int i = 2 * (int.Parse(Data_Move.num_of_cells) + 2) - 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i - (int.Parse(Data_Move.num_of_cells))];
            }

            Data_Move.population_census1[0] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 2];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2) - 1] = Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 3];
            Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 1] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1)] = Data_Move.population_census1[2 * (int.Parse(Data_Move.num_of_cells) + 2) - 2];

            Data_Move.population_census3.Clear();
            Data_Move.population_census3.AddRange(Data_Move.population_census1);

            int n, m, around_a_life = 0, j = 0;
            n = int.Parse(Data_Move.num_of_cells) + 2;
            m = int.Parse(Data_Move.num_of_cells) + 2;

            for (int i = 0; i < Data_Move.population_census1.LongCount(); i++)
            {
                if (((i + 1) % n) != 0 && (((i + 1) - 1) % n) != 0 && ((i + 1) - n) >= 1 && (((i + 1) + n) <= m * n))
                {
                    Data_Move.population_census2[j] = Data_Move.population_census1[i];
                    if (Data_Move.population_census1[(i + 1) - n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1)])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[i] == false && around_a_life == 1)
                    {
                        Data_Move.population_census2[j] = true;
                        Data_Move.population_census3[i] = true;
                    }
                    j++;
                }
                around_a_life = 0;
            }
            Random rng = new Random();
            Color color = new Color();

            for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
            {
                int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;


                if (Data_Move.f1Cb && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb && Data_Move.population_census2[i] == true)
                {
                    cells.FillRectangle(new SolidBrush(Color.White), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb == false && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else
                {
                    color = Color.FromArgb(rng.Next(250, 255), rng.Next(80, 255), rng.Next(80, 255));
                    cells.FillRectangle(new SolidBrush(color), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
            }

            Data_Move.population_census1.Clear();
            Data_Move.population_census1.AddRange(Data_Move.population_census3);

            f1.pictureBox1.Image = buffer;

            if (Data_Move.f1check == false)
                Thread.Sleep(100 * Data_Move.timer);
        }




        public void Change_generation5(Graphics cells, Bitmap buffer)
        {
            Form1 f1 = new Form1();

            for (int i = 1; i <= int.Parse(Data_Move.num_of_cells) + 2; i++)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + i];
            }

            int t = 1;
            for (int i = (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1[i - 1] = Data_Move.population_census1[t + int.Parse(Data_Move.num_of_cells) + 2];
                t++;
            }

            for (int i = int.Parse(Data_Move.num_of_cells) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i + (int.Parse(Data_Move.num_of_cells))];
            }

            for (int i = 2 * (int.Parse(Data_Move.num_of_cells) + 2) - 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i - (int.Parse(Data_Move.num_of_cells))];
            }

            Data_Move.population_census1[0] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 2];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2) - 1] = Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 3];
            Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 1] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1)] = Data_Move.population_census1[2 * (int.Parse(Data_Move.num_of_cells) + 2) - 2];

            Data_Move.population_census3.Clear();
            Data_Move.population_census3.AddRange(Data_Move.population_census1);

            int n, m, around_a_life = 0, j = 0;
            n = int.Parse(Data_Move.num_of_cells) + 2;
            m = int.Parse(Data_Move.num_of_cells) + 2;

            for (int i = 0; i < Data_Move.population_census1.LongCount(); i++)
            {
                if (((i + 1) % n) != 0 && (((i + 1) - 1) % n) != 0 && ((i + 1) - n) >= 1 && (((i + 1) + n) <= m * n))
                {
                    Data_Move.population_census2[j] = Data_Move.population_census1[i];
                    if (Data_Move.population_census1[(i + 1) - n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1)])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[i] == false && around_a_life == 1)
                    {
                        Data_Move.population_census2[j] = true;
                        Data_Move.population_census3[i] = true;
                    }
                    if (Data_Move.population_census1[i] && around_a_life > 1)
                    {
                        Data_Move.population_census2[j] = false;
                        Data_Move.population_census3[i] = false;
                    }
                    j++;
                }
                around_a_life = 0;
            }
            Random rng = new Random();
            Color color = new Color();

            for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
            {
                int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;


                if (Data_Move.f1Cb && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb && Data_Move.population_census2[i] == true)
                {
                    cells.FillRectangle(new SolidBrush(Color.White), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb == false && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else
                {
                    color = Color.FromArgb(rng.Next(80, 255), rng.Next(80, 255), rng.Next(250, 255));
                    cells.FillRectangle(new SolidBrush(color), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
            }

            Data_Move.population_census1.Clear();
            Data_Move.population_census1.AddRange(Data_Move.population_census3);

            f1.pictureBox1.Image = buffer;

            if (Data_Move.f1check == false)
                Thread.Sleep(100 * Data_Move.timer);
        }




        public void Change_generation6(Graphics cells, Bitmap buffer)
        {
            Form1 f1 = new Form1();

            for (int i = 1; i <= int.Parse(Data_Move.num_of_cells) + 2; i++)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + i];
            }

            int t = 1;
            for (int i = (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1[i - 1] = Data_Move.population_census1[t + int.Parse(Data_Move.num_of_cells) + 2];
                t++;
            }

            for (int i = int.Parse(Data_Move.num_of_cells) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i + (int.Parse(Data_Move.num_of_cells))];
            }

            for (int i = 2 * (int.Parse(Data_Move.num_of_cells) + 2) - 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i - (int.Parse(Data_Move.num_of_cells))];
            }

            Data_Move.population_census1[0] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 2];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2) - 1] = Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 3];
            Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 1] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1)] = Data_Move.population_census1[2 * (int.Parse(Data_Move.num_of_cells) + 2) - 2];

            Data_Move.population_census3.Clear();
            Data_Move.population_census3.AddRange(Data_Move.population_census1);

            int n, m, around_a_life = 0, j = 0;
            n = int.Parse(Data_Move.num_of_cells) + 2;
            m = int.Parse(Data_Move.num_of_cells) + 2;

            for (int i = 0; i < Data_Move.population_census1.LongCount(); i++)
            {
                if (((i + 1) % n) != 0 && (((i + 1) - 1) % n) != 0 && ((i + 1) - n) >= 1 && (((i + 1) + n) <= m * n))
                {
                    Data_Move.population_census2[j] = Data_Move.population_census1[i];
                    if (Data_Move.population_census1[(i + 1) - n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1)])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[i] == false && around_a_life == 1)
                    {
                        Data_Move.population_census2[j] = true;
                        Data_Move.population_census3[i] = true;
                    }
                    if (Data_Move.population_census1[i] && around_a_life > 3)
                    {
                        Data_Move.population_census2[j] = false;
                        Data_Move.population_census3[i] = false;
                    }
                    j++;
                }
                around_a_life = 0;
            }
            Random rng = new Random();
            Color color = new Color();

            for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
            {
                int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;


                if (Data_Move.f1Cb && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb && Data_Move.population_census2[i] == true)
                {
                    cells.FillRectangle(new SolidBrush(Color.White), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb == false && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else
                {
                    color = Color.FromArgb(rng.Next(250, 255), rng.Next(80, 255), rng.Next(80, 255));
                    cells.FillRectangle(new SolidBrush(color), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
            }

            Data_Move.population_census1.Clear();
            Data_Move.population_census1.AddRange(Data_Move.population_census3);

            f1.pictureBox1.Image = buffer;

            if (Data_Move.f1check == false)
                Thread.Sleep(100 * Data_Move.timer);
        }




        public void Change_generation7(Graphics cells, Bitmap buffer)
        {
            Form1 f1 = new Form1();

            for (int i = 1; i <= int.Parse(Data_Move.num_of_cells) + 2; i++)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + i];
            }

            int t = 1;
            for (int i = (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1[i - 1] = Data_Move.population_census1[t + int.Parse(Data_Move.num_of_cells) + 2];
                t++;
            }

            for (int i = int.Parse(Data_Move.num_of_cells) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i + (int.Parse(Data_Move.num_of_cells))];
            }

            for (int i = 2 * (int.Parse(Data_Move.num_of_cells) + 2) - 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i - (int.Parse(Data_Move.num_of_cells))];
            }

            Data_Move.population_census1[0] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 2];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2) - 1] = Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 3];
            Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 1] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1)] = Data_Move.population_census1[2 * (int.Parse(Data_Move.num_of_cells) + 2) - 2];

            Data_Move.population_census3.Clear();
            Data_Move.population_census3.AddRange(Data_Move.population_census1);

            int n, m, around_a_life = 0, j = 0;
            n = int.Parse(Data_Move.num_of_cells) + 2;
            m = int.Parse(Data_Move.num_of_cells) + 2;

            for (int i = 0; i < Data_Move.population_census1.LongCount(); i++)
            {
                if (((i + 1) % n) != 0 && (((i + 1) - 1) % n) != 0 && ((i + 1) - n) >= 1 && (((i + 1) + n) <= m * n))
                {
                    Data_Move.population_census2[j] = Data_Move.population_census1[i];
                    if (Data_Move.population_census1[(i + 1) - n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1)])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[i] == false && around_a_life == 2)
                    {
                        Data_Move.population_census2[j] = true;
                        Data_Move.population_census3[i] = true;
                    }
                    if (Data_Move.population_census1[i] && around_a_life < 9)
                    {
                        Data_Move.population_census2[j] = false;
                        Data_Move.population_census3[i] = false;
                    }
                    j++;
                }
                around_a_life = 0;
            }
            Random rng = new Random();
            Color color = new Color();

            for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
            {
                int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;


                if (Data_Move.f1Cb && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb && Data_Move.population_census2[i] == true)
                {
                    cells.FillRectangle(new SolidBrush(Color.White), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb == false && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else
                {
                    color = Color.FromArgb(rng.Next(80, 255), rng.Next(80, 255), rng.Next(250, 255));
                    cells.FillRectangle(new SolidBrush(color), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
            }

            Data_Move.population_census1.Clear();
            Data_Move.population_census1.AddRange(Data_Move.population_census3);

            f1.pictureBox1.Image = buffer;

            if (Data_Move.f1check == false)
                Thread.Sleep(100 * Data_Move.timer);
        }




        public void Change_generation8(Graphics cells, Bitmap buffer)
        {
            Form1 f1 = new Form1();

            for (int i = 1; i <= int.Parse(Data_Move.num_of_cells) + 2; i++)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + i];
            }

            int t = 1;
            for (int i = (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2); i++)
            {
                Data_Move.population_census1[i - 1] = Data_Move.population_census1[t + int.Parse(Data_Move.num_of_cells) + 2];
                t++;
            }

            for (int i = int.Parse(Data_Move.num_of_cells) + 2; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i + (int.Parse(Data_Move.num_of_cells))];
            }

            for (int i = 2 * (int.Parse(Data_Move.num_of_cells) + 2) - 1; i <= (int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 1; i = i + int.Parse(Data_Move.num_of_cells) + 2)
            {
                Data_Move.population_census1[i] = Data_Move.population_census1[i - (int.Parse(Data_Move.num_of_cells))];
            }

            Data_Move.population_census1[0] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1) - 2];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 2) - 1] = Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 3];
            Data_Move.population_census1[int.Parse(Data_Move.num_of_cells) + 1] = Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells)) + 1];
            Data_Move.population_census1[(int.Parse(Data_Move.num_of_cells) + 2) * (int.Parse(Data_Move.num_of_cells) + 1)] = Data_Move.population_census1[2 * (int.Parse(Data_Move.num_of_cells) + 2) - 2];

            Data_Move.population_census3.Clear();
            Data_Move.population_census3.AddRange(Data_Move.population_census1);

            int n, m, around_a_life = 0, j = 0;
            n = int.Parse(Data_Move.num_of_cells) + 2;
            m = int.Parse(Data_Move.num_of_cells) + 2;

            for (int i = 0; i < Data_Move.population_census1.LongCount(); i++)
            {
                if (((i + 1) % n) != 0 && (((i + 1) - 1) % n) != 0 && ((i + 1) - n) >= 1 && (((i + 1) + n) <= m * n))
                {
                    Data_Move.population_census2[j] = Data_Move.population_census1[i];
                    if (Data_Move.population_census1[(i + 1) - n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1)])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 2])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n - 1])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[(i + 1) + n])
                    {
                        around_a_life++;
                    }
                    if (Data_Move.population_census1[i] == false && (around_a_life > 1))
                    {
                        Data_Move.population_census2[j] = true;
                        Data_Move.population_census3[i] = true;
                    }
                    else if (Data_Move.population_census1[i] && around_a_life > 4)
                    {
                        Data_Move.population_census2[j] = false;
                        Data_Move.population_census3[i] = false;
                    }
                    j++;
                }
                around_a_life = 0;
            }
            Random rng = new Random();
            Color color = new Color();

            for (int i = 0; i < Data_Move.population_census2.LongCount(); i++)
            {
                int number_to_point_correlation_y = (i - ((i) % (int.Parse(Data_Move.num_of_cells)))) * Data_Move.one_cells / (int.Parse(Data_Move.num_of_cells));
                int number_to_point_correlation_x = i % (int.Parse(Data_Move.num_of_cells)) * Data_Move.one_cells;


                if (Data_Move.f1Cb && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb && Data_Move.population_census2[i] == true)
                {
                    cells.FillRectangle(new SolidBrush(Color.White), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else if (Data_Move.f1Cb == false && Data_Move.population_census2[i] == false)
                {
                    cells.FillRectangle(new SolidBrush(Color.Black), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
                else
                {
                    color = Color.FromArgb(rng.Next(80, 255), rng.Next(80, 255), rng.Next(250, 255));
                    cells.FillRectangle(new SolidBrush(color), number_to_point_correlation_x + 1, number_to_point_correlation_y + 1, Data_Move.one_cells - 1, Data_Move.one_cells - 1);
                }
            }

            Data_Move.population_census1.Clear();
            Data_Move.population_census1.AddRange(Data_Move.population_census3);

            f1.pictureBox1.Image = buffer;

            if (Data_Move.f1check == false)
                Thread.Sleep(100 * Data_Move.timer);
        }
    }
}

