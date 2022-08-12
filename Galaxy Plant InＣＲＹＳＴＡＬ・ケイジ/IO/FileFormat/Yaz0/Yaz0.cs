using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0
{
    public class Yaz0
    {
        private static string s_magic;
        private static int s_unknown1, s_unknown2;
        public string Magic
        {
            set => s_magic = value;
            get
            {
                s_magic = "Yaz0";
                return s_magic;
            }
        }
        public int OriginalDataSize { get; set; }
        public int Unknown1
        {
            set
            {
                if (value != 0x00000000)
                {
                    Console.WriteLine("Yaz0のUnknown1プロパティで例外が発生しました");
                    Console.WriteLine("下記のエラー内容を最下段のURLに報告してください。");
                    Console.WriteLine("エラー：Unknown1「" + value.ToString("X8") + "」");
                    Console.WriteLine("https://github.com/penguin117117/ARCTool/issues");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                s_unknown1 = value;
            }
            get
            {
                s_unknown1 = 0x00000000;
                return s_unknown1;
            }

        }
        public int Unknown2
        {
            set
            {
                if (value != 0x00000000)
                {
                    Console.WriteLine("Yaz0のUnknown1プロパティで例外が発生しました");
                    Console.WriteLine("下記のエラー内容を最下段のURLに報告してください。");
                    Console.WriteLine("エラー：Unknown1「" + value.ToString("X8") + "」");
                    Console.WriteLine("https://github.com/penguin117117/ARCTool/issues");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                s_unknown2 = value;
            }
            get
            {
                s_unknown2 = 0x00000000;
                return s_unknown2;
            }
        }

        private readonly Byte[] IsNormalRead = {
            0b_1000_0000 ,
            0b_0100_0000 ,
            0b_0010_0000 ,
            0b_0001_0000 ,
            0b_0000_1000 ,
            0b_0000_0100 ,
            0b_0000_0010 ,
            0b_0000_0001
        };
        //private readonly bool[] IsNormalRead = { true, true, true, true, true, true, true };

        public struct ChunkData
        {
            public bool IsNormalRead;
            public List<byte> ByteList;
            public ChunkData(bool isRead, List<byte> byteList)
            {
                IsNormalRead = isRead;
                ByteList = new List<byte>(byteList);

            }
        }

        private ChunkData[] ChunkDatas = new ChunkData[8];

        private static List<string> s_debug = new List<string>();
        public void Decord(string filepath)
        {

            List<bool> bitlist = new();
            List<byte> Yaz0DecDeta = new();
            //var DecFile = 0;
            var savedirectory = filepath.Substring(0, filepath.LastIndexOf(@"\"));
            var savefilename = Path.GetFileNameWithoutExtension(filepath) + ".rarc";
            var savefullpath = Path.Combine(savedirectory, savefilename);

            FileStream fs = new(filepath, FileMode.Open);
            BinaryReader br = new(fs);

            //Yaz0ヘッダー
            Magic = Calculation.Byte2Char(br);
            OriginalDataSize = Calculation.Byte2Int(br);
            Unknown1 = Calculation.Byte2Int(br);
            Unknown2 = Calculation.Byte2Int(br);

            //解凍処理
            while (Yaz0DecDeta.Count < OriginalDataSize)
            {

                byte StrReadType = br.ReadByte();
                byte[] bits = new byte[] { StrReadType };


                //ビット反転
                System.Collections.BitArray bitArray = new(bits);
                bitlist = BitArrayReverser(bitArray, bitlist);



                foreach (var bititem in bitlist)
                {

                    if (bititem == true)
                    {

                        //ビットが1の場合1バイトをそのまま読み込む
                        var writedata = br.ReadByte();
                        Yaz0DecDeta.Add(writedata);
                    }
                    else
                    {
                        //ビットが0の場合の処理
                        var bita = br.ReadByte();
                        var bitb = br.ReadByte();
                        //s_debug.Add(bita.ToString("X2"));
                        //s_debug.Add(bitb.ToString("X2"));
                        byte a_top4 = (byte)(bita >> 4);
                        byte a_last4 = (byte)(bita << 4);
                        int pos_same_String = (a_last4 << 4 | bitb) + 1;
                        int writebyteNum;

                        //a_top4が0の場合と0以外の場合で読み込み方法が変わる。
                        if (a_top4 == 0)
                        {
                            //a_top4のサイズが0xFが最大なのでそれよりも大きい場合の処理
                            byte ByteC = br.ReadByte();
                            writebyteNum = ByteC + 0x12;
                            //s_debug.Add(ByteC.ToString("X2"));
                        }
                        else
                        {
                            writebyteNum = a_top4 + 2;
                        }

                        //s_debug.Add("\n");
                        for (int i = 0; i < writebyteNum; i++)
                        {
                            var sameindex = Yaz0DecDeta.Count - pos_same_String;
                            Yaz0DecDeta.Add(Yaz0DecDeta[sameindex]);
                            s_debug.Add(Yaz0DecDeta[sameindex].ToString("X2") + " ");

                        }
                        //s_debug.Add("\n");
                    }
                    if (Yaz0DecDeta.Count == OriginalDataSize) break;
                }
            }

            FileStream fs2 = new(savefullpath, FileMode.Create);
            BinaryWriter bwYaz0 = new(fs2);
            bwYaz0.Write(Yaz0DecDeta.ToArray());


            br.Close();
            fs.Close();
            bwYaz0.Close();
            fs2.Close();
        }

        private static List<bool> BitArrayReverser(BitArray bitArray, List<bool> bitlist)
        {
            bitlist = new List<bool>();
            foreach (var tes in bitArray) bitlist.Add((bool)tes);
            bitlist.Reverse();
            return bitlist;
        }
    }


}
