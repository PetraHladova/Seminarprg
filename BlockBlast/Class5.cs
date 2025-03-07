using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBlast
{
    internal class OtherBlocks : Blocks
    {
        private float type;

        public override int CalculateScoreForBlock()
        {
            return 6;
        }

        public OtherBlocks(int type)
        {
            this.type = type;
        }
    }
}
