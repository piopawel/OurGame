using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Classes.Games
{
    class DeceptiveArrow 
    {
        public static string player = "PIO";
        public static float points;
        public static int gameMode = 5;
        public static List<Arrow> arrows = new List<Arrow>();

        public static void resetArrows()
        {
            arrows.Clear();
        }
    }
}
