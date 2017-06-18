using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Classes.Games
{
    class DeceptiveArrow 
    {
        private static Random random;
        public static Player player;
        public static float points;
        public static int gameMode;
        public static List<Arrow> arrows = new List<Arrow>();
        //time?

        //private Colors usedColor;

        public DeceptiveArrow()//Player player, int gameMode)
        {
            random = new Random();
            //this.player = player;
            //this.gameMode = gameMode;
        }
        /*
         *  This method creates an Arrow object. 
         *  The color of an arrow is random, regardeless of the game level. 
         *  However, the small arrow must be the opposite color to the big one.
         *  
         *  The direction of an arrow is random. However if the gameLevel is 1, the direction can only be W or E.
         *  
         *  The size of an arrow is big. If a small arrow is generated, then the size is small.
         */
        public Arrow generateArrow()
        {
            Colors color;
            Directions direction;
            Sizes size;

            if (gameMode == 1)
                direction = (Directions)random.Next(0, 2);
            else
                direction = (Directions)random.Next(0, 4);

            if (arrows.Count == 0)
            {
                size = Sizes.big;
                //color = usedColor = (Colors)random.Next(0, 2);
                color = (Colors)random.Next(0, 2);
            }
            else {
                size = Sizes.small;
                if (arrows[0].color == Colors.red)
                    color = Colors.blue;
                else
                    color = Colors.red;
            }

            Arrow arrow = new Arrow(color, direction, size);
            arrows.Add(arrow);
            return arrow;
        }
        public static void resetArrows()
        {
            arrows.Clear();
        }
    }
}
