using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Classes.Games
{
    class Arrow
    {
        Colors color;
        Directions direction;
        Sizes size;
        public Arrow()
        {

        }
        public Arrow(Colors color, Directions direction, Sizes size)
        {
            this.color = color;
            this.direction = direction;
            this.size = size;
        }
    }
    public enum Colors {red, blue};
    public enum Directions { E, W , N, S}
    public enum Sizes { big, small}
}
