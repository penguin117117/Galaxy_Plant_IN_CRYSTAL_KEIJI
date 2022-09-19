using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util
{
    public static class BinarySystemPadding
    {
        
        public static void SkipEndPosition(Stream stream)
        {
            if (stream.Position % 32f != 0)
            {
                while (true)
                {
                    if (stream.Position % 32f == 0) break;
                    stream.Position++;
                }
            }
        }
    }
}
