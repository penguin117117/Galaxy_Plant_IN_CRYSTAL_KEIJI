using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util
{
    public static class Binary SystemReadString
    {
        public static string Bytes2String_NullEnd(FileStream fs, BinaryReader br , long nameoffset) {
            var oldpos = fs.Position;

            fs.Seek((long)nameoffset, SeekOrigin.Begin);

            

            List<byte> bits = new List<byte>();
            while (true) {
                var bit = Bytes2Byte(br);
                bits.Add(bit);
                //Console.WriteLine(bit.ToString("X"));
                if (bit == 0x00) break;
            }
            //Console.WriteLine("testes");

            fs.Seek(oldpos, SeekOrigin.Begin);

            var bitarray = bits.ToArray();
            //var bitreverse = bitarray.Reverse();
            //var bitarray2 = bitreverse.ToArray();
            //Console.WriteLine(Encoding.ASCII.GetString(bitarray));
            var str = Encoding.GetEncoding(65001).GetString(bitarray) ;
            //Console.WriteLine(str.Substring(0 , str.Count()-1));
            //Console.WriteLine(oldpos.ToString("X")+" : "+str);
            //Console.WriteLine(fs.Position.ToString("X"));

            string ret = str.Substring(0, str.Length - 1);

            //Console.WriteLine(br.BaseStream.Position.ToString("X"));
            return ret;
        }
    }
}
