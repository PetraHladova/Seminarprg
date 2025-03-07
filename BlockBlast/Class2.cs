using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBlast
{
    internal class Square : Blocks
    {
        private int size;

        public override int CalculateScoreForBlock()
        {
            return size * 2;
        }

        public Square(int size)
        {
            this.size = size;
        }
    }
}
