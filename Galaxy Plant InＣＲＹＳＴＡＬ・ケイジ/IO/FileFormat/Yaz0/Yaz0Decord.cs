using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0
{
    public sealed class Yaz0Decord : Yaz0
    {
        public byte[]? BinaryData { get; private set; }

        public Yaz0Decord(string fileFullPath) 
        {
            using (FileStream fs = new(fileFullPath, FileMode.Open)) 
            {
                using (BinaryReader br = new(fs)) 
                {
                    Header = new(br);
                    if (Header.SectionName == 0x59617A30) 
                    {
                        Decord(br);
                    }
                    
                };
            };
        }

        public void Save(string savefullpath, string changeExtention = ".rarc") 
        {
            if (BinaryData == null) return;
            File.WriteAllBytes(Path.ChangeExtension(savefullpath,changeExtention),BinaryData);
        }

        public void Decord(BinaryReader br)
        {
            List<bool> bitList = new();
            List<byte> Yaz0DecData = new();

            //解凍処理
            while (Yaz0DecData.Count < Header.OriginalDataSize)
            {
                byte StrReadType = br.ReadByte();
                byte[] bits = new byte[] { StrReadType };

                //ビット反転
                BitArray bitArray = new(bits);
                bitList = CustomBitArray.Reverser(bitArray, bitList);

                foreach (var bititem in bitList)
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
                    if (Yaz0DecData.Count == Header.OriginalDataSize) break;
                }
            }

            BinaryData = Yaz0DecData.ToArray();
        }
    }
}
