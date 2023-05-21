using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.BL
{
    class Cell
    {
        public char value;
        public int X;
        public int Y;
        public Cell (char Value, int X, int Y)
        {
            this.value = Value;
            this.X = X;
            this.Y = Y;
        }
        public char getValue()
        {
            return value;
        }
        public void setValue (char Value)
        {
            this.value = Value;
        }
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
        public bool isPacmanPresent()
        {
            if (this.value == 'P')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool isGhostPresent(char ghostCharacter)
        {
            if (this.value == ghostCharacter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
