using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game_of_Life
{
    class Data_Move
    {
        /* This is a static class that is used to move data
         * between forms and form elements */

        public static string num_of_cells = "50";
        public static int one_cells = 10;
        public static List<bool> population_census1 = new List<bool>();
        public static List<bool> population_census2 = new List<bool>();
        public static List<bool> population_census3 = new List<bool>();


        public static bool no_evolution = true;
        public static int timer = 1;
        public static bool back = true;
        public static bool f1Cb = true;
        public static bool f1check = false;

        public static int rules_of_life = 1;
    }
}
