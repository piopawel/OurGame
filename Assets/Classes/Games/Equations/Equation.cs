using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Classes.Games.Equations
{
    class Equation
    {
        private int first;
        private string sign;
        private int second;
        private int equals;

        public Equation(int first, string sign, int second, int equals)
        {
            this.first = first;
            this.sign = sign;
            this.second = second;
            this.equals = equals;
        }
    }
}
