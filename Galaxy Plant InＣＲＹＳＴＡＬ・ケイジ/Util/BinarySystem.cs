using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util
{
    public static class BinarySystem
    {
        public static void PaddingSkip(Stream stream)
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

        public static string ReadStringNullEnd(BinaryReader br , long nameoffset , bool isLastItem = false) {
            var oldpos = br.BaseStream.Position;

            var strPos = br.BaseStream.Seek(oldpos + (long)nameoffset, SeekOrigin.Begin);

            Debug.WriteLine(strPos.ToString("X"));

            List<byte> stringBytes = new();
            while (true) 
            {
                stringBytes.Add(br.ReadByte());
                if (stringBytes[^1] == 0x00) 
                {
                    break;
                }
            }

            if(!isLastItem)
            br.BaseStream.Seek(oldpos, SeekOrigin.Begin);

            var bitarray = stringBytes.ToArray();
            var str = Encoding.GetEncoding(65001).GetString(bitarray) ;

            return str[0..^1];
        }

        public static string ReadStringNullEnd(BinaryReader br) 
        {
            List<byte> stringBytes = new();
            while (true)
            {
                stringBytes.Add(br.ReadByte());
                if (stringBytes[^1] == 0x00)
                {
                    break;
                }
            }

            var bitarray = stringBytes.ToArray();
            var nameString = Encoding.GetEncoding(65001).GetString(bitarray);

            return nameString[0..^1];
        }

        /// <summary>
        /// <see href="seekStringOffset"/> で指定した場所までSeekを行い文字列をNull末端まで取得します。<br/>
        /// その後Seek直前の位置まで現在のストリーム位置をSeekします。
        /// </summary>
        /// <param name="br"></param>
        /// <param name="seekStringOffset"></param>
        /// <returns></returns>
        public static string ReadSeekStringNullEndAndSeekFix(BinaryReader br, long seekStringOffset) 
        {
            long fixPosition = br.BaseStream.Position;

            //ファイル名の取得
            br.BaseStream.Seek(seekStringOffset, SeekOrigin.Begin);
            string dirName = BinarySystem.ReadStringNullEnd(br);
            //Debug.WriteLine("StringEndPosition: " + br.BaseStream.Position.ToString("X"));

            //ストリームの位置を元に戻す
            br.BaseStream.Seek(fixPosition, SeekOrigin.Begin);

            return dirName;
        }
    }
}
