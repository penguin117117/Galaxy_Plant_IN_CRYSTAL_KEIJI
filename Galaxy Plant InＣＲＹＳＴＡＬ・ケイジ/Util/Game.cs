using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util
{
    internal class Game
    {
        internal static GameVersion Version { get; set; }

        internal Game() 
        {
            
        }

        internal enum GameVersion :byte
        {
            None = 0b00000000,
            SMG1 = 0b00000001,
            SMG2 = 0b00000010
        }
    }
}
