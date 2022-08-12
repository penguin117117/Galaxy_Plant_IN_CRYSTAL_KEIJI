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
        private static string _magic;
        private static int _unknown1, _unknown2;
        public string Magic
        {
            set => _magic = value;
            get
            {
                _magic = "Yaz0";
                return _magic;
            }
        }
        public int OriginalDataSize { get; set; }
        public int Unknown1
        {
            set
            {
                if (value != 0x00000000)
                {
                    throw new Exception("Error:Yaz0のUnknown1プロパティでエラーが発生しました。");
                }
                _unknown1 = value;
            }
            get
            {
                _unknown1 = 0x00000000;
                return _unknown1;
            }

        }
        public int Unknown2
        {
            set
            {
                if (value != 0x00000000)
                {
                    throw new Exception("Error:Yaz0のUnknown2プロパティでエラーが発生しました。");
                }
                _unknown2 = value;
            }
            get
            {
                _unknown2 = 0x00000000;
                return _unknown2;
            }
        }

        public void Decord(string filepath)
        {
            List<bool> bitlist = new();
            List<byte> Yaz0DecData = new();

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
            while (Yaz0DecData.Count < OriginalDataSize)
            {

                byte StrReadType = br.ReadByte();
                byte[] bits = new byte[] { StrReadType };


                //ビット反転
                BitArray bitArray = new(bits);
                bitlist = BitArrayReverser(bitArray, bitlist);



                foreach (var bititem in bitlist)
                {

                    if (bititem == true)
                    {

                        //ビットが1の場合1バイトをそのまま読み込む
                        var writedata = br.ReadByte();
                        Yaz0DecData.Add(writedata);
                    }
                    else
                    {
                        //ビットが0の場合の処理
                        var bita = br.ReadByte();
                        var bitb = br.ReadByte();
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
                        }
                        else
                        {
                            writebyteNum = a_top4 + 2;
                        }

                        for (int i = 0; i < writebyteNum; i++)
                        {
                            var sameindex = Yaz0DecData.Count - pos_same_String;
                            Yaz0DecData.Add(Yaz0DecData[sameindex]);
                        }
                    }
                    if (Yaz0DecData.Count == OriginalDataSize) break;
                }
            }

            FileStream fs2 = new(savefullpath, FileMode.Create);
            BinaryWriter bwYaz0 = new(fs2);
            bwYaz0.Write(Yaz0DecData.ToArray());


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
