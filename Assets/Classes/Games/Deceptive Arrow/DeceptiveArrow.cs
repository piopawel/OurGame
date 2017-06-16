using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Classes.Games
{
    class DeceptiveArrow 
    {
        private static Random random;
        private static bool alreadyAnArrow = false;
        private Player player;
        private double points;
        private int gameMode;
        //time?

        private Colors usedColor;

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

            if (this.gameMode == 1)
                direction = (Directions)random.Next(0, 2);
            else
                direction = (Directions)random.Next(0, 4);

            if (!alreadyAnArrow)
            {
                size = Sizes.big;
                color = usedColor = (Colors)random.Next(0, 2);
            }
            else {
                size = Sizes.small;
                if (usedColor == Colors.red)
                    color = Colors.blue;
                else
                    color = Colors.red;
            }

            Arrow arrow = new Arrow(color, direction, size);
            alreadyAnArrow = true;
            return arrow;
        }
        private static void resetArrows()
        {
           alreadyAnArrow = false;
        }
    }
}
