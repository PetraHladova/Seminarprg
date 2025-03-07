using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBlast
{
    internal class BlockL : Blocks
    {
        private int size;

        public override int CalculateScoreForBlock()
        {
            if (size == 1)
            {
                return 3;
            }
            else if (size == 2)
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }

        public BlockL(int size)
        {
            this.size = size;
        }
    }
}
