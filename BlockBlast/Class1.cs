using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBlast
{
    internal class Blocks
    {
        public virtual int CalculateScoreForBlock()
        {
            Console.WriteLine("Neznámý block, nemá nastavené score.");
            return 0;
        }
    }
}