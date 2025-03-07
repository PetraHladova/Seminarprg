using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBlast
{
    internal class Line : Blocks
    {
        private int size;

        public override int CalculateScoreForBlock()
        {
            if (size == 1 || size == 2)
            {
                return 3;
            }
            else
            {
                return 5;
            }
        }

        public Line(int size)
        {
            this.size = size;
        }
    }
}
