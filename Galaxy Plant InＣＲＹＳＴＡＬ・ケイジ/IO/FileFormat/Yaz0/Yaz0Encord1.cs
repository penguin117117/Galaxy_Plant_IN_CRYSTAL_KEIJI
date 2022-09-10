using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0
{
    internal class Yaz0Encord : Yaz0
    {

        public byte[]? BinaryData { get; private set; }
        int DecordDataSize;

        int ErrorCode = 0; //Can't Compress = 1,IO Error 2,Other 3

        public Yaz0Encord(byte[]? SourceData)
        {
            DecordDataSize = SourceData.Length;
            if(DecordDataSize <= 8)
            {
                ErrorCode = 1;
                return;
            }
            BinaryData = Encord(SourceData);
        }

        public void FileOutput(string savefullpath, string changeExtention = "arc")
        {
            if (BinaryData == null) return;
            File.WriteAllBytes(Path.ChangeExtension(savefullpath, changeExtention), BinaryData);
        }

        private struct Dictionary
        {
            public UInt32 CompressRegth;
            public UInt32 Offset;

            public Dictionary(UInt32 argv, UInt32 argv1)
            {
                CompressRegth = argv;
                Offset = argv1;
            }
        }

        private byte[]? Encord(byte[]? SourceData)
        {
            byte[]? CompressedVal = null;

            //error chack
            if (SourceData == null)
            {
                return CompressedVal;
            
            }

            uint SourceDataPlace = 0;
            int SourceDataSizeMax = SourceData.Length;
            int CompressedPlace = 0;

            CompressedVal[CompressedPlace++] = 0xff;

            while(SourceDataPlace < 8) //8 は圧縮されないデータの長さ
            {
                //not compress dictionaly
                CompressedVal[CompressedPlace++] = SourceData[SourceDataPlace++];

            }


            //main
            int UncompressFlagCoount = 0,
                UncompressFlagWritePlace = 0;

            while (SourceDataPlace < SourceDataSizeMax)
            {
                if (UncompressFlagCoount == 0)
                {
                    UncompressFlagWritePlace = CompressedPlace++;
                    CompressedVal[UncompressFlagWritePlace] = 0x00;
                    UncompressFlagWritePlace = 8;
                }
                UncompressFlagCoount--;


                //serch(function)
                Dictionary dictionary = SerchDictionaly(SourceData, (int)SourceDataPlace, SourceData.Length);


                if (dictionary.CompressRegth <= 2)
                {
                    //don't compress
                    CompressedVal[UncompressFlagWritePlace] |= (byte)(0x01 << UncompressFlagWritePlace);
                    CompressedVal[CompressedPlace++] = SourceData[SourceDataPlace++];

                }
                else
                {
                    //compress
                    uint TergetLength = dictionary.CompressRegth;
                    if (TergetLength <= 0x11) // 0x11 compress 2byte format size
                    {
                        //2 byte format
                        TergetLength -= 0x02;
                        CompressedVal[CompressedPlace++] = (byte)(((TergetLength & 0x0f) << 4) |        //length
                                                                  (((dictionary.Offset & 0x0f00) >> 8))  //offset
                                                                 );
                        CompressedVal[CompressedPlace++] = (byte)(dictionary.Offset & 0x00ff);           //offset

                        SourceDataPlace += (TergetLength & 0x0f) + 0x02; //seek compressed length

                    }
                    else
                    {
                        //3 byte format
                        TergetLength -= 0x12;
                        CompressedVal[CompressedPlace++] = (byte)((dictionary.Offset & 0x0f00) >> 8);    //offset
                        CompressedVal[CompressedPlace++] = (byte)(dictionary.Offset & 0x00ff);           //offset
                        CompressedVal[CompressedPlace++] = (byte)(TergetLength & 0x00ff);               //length

                        SourceDataPlace += (TergetLength & 0x00ff) + 0x12; //seek compressed length

                    }

                }

            }

            while(UncompressFlagCoount != 0)
            {
                --UncompressFlagCoount;
                CompressedVal[UncompressFlagWritePlace] |= (byte)(0x01 << UncompressFlagCoount);
                CompressedVal[CompressedPlace++] = 0x00;

            }

            for(int i = 0; i < CompressedPlace % 16; i++)
            {
                CompressedVal[CompressedPlace++] = 0x00;
            
            }

            return CompressedVal;
        }


        private Dictionary SerchDictionaly(byte[]? SourceData, int SourceDataPlace, int SourceDataSize)
        {
            int CompLength = 0,
                CompLengthBuf = 0,
                CompLengthOffset = 0,
                MinReferencePlace = SourceDataPlace - 1,
                MaxReferencePlace = MinReferencePlace - 0x0fff; // 0xfff は参照できる最大要素数

            if(MaxReferencePlace == 0)
            {
                MaxReferencePlace = 0;

            }

            for(int DictionaryPlace = MaxReferencePlace; DictionaryPlace < SourceDataPlace; DictionaryPlace++)
            {
                CompLengthBuf = 0;

                while (SourceData[SourceDataPlace + CompLengthBuf] == SourceData[SourceDataPlace + CompLengthBuf])
                {
                    CompLength++;

                    if (SourceDataPlace + CompLengthBuf == SourceDataSize ||
                        CompLengthBuf > 0x0112 //0x0112 = (0x10 + 0x2) + 0x100 : 最大圧縮データサイズ = 2Byteの要素数 + 3Byteの要素数
                        )
                    {
                        CompLength--;
                        break;

                    }

                }



                if(CompLengthBuf > CompLength)
                {
                    CompLength = CompLengthBuf;
                    CompLengthOffset = MinReferencePlace - DictionaryPlace;

                }

            }

            return new Dictionary((uint)CompLength, (uint)CompLengthOffset);
        }

    }

}
