using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0
{
    internal class Yaz0Encord
    {
        const int HeaderIndex = 16;

        public readonly byte[]? BinaryData;
        public readonly int DecordDataSize;

        private byte[]? SourceData;
        private int FileSize;

        private readonly byte[] Header = new byte[HeaderIndex];
        private int ErrorCode = 0; //Can't Compress = 1,IO Error 2,Other 3

        public Yaz0Encord(byte[]? Argv_SourceData)
        {
            if(Argv_SourceData.Length <= 8)
            {
                ErrorCode = 1;
                return;
            }
            DecordDataSize = Argv_SourceData.Length;
            SourceData = Argv_SourceData;
            byte[] BinaryDataBuf = Encord();

            CreateHeader();
            BinaryData = new byte[FileSize + HeaderIndex];
            for(int i = 0; i < HeaderIndex; i++)
            {
                BinaryData[i] = Header[i];
            }

            for(int i = 0; i < FileSize; i++)
            {
                BinaryData[i + HeaderIndex] = BinaryDataBuf[i];
            }
        }

        public void FileWrite(string savefullpath, string changeExtention = "yaz0")
        {
            if (BinaryData == null) return;
            File.WriteAllBytes(Path.ChangeExtension(savefullpath, changeExtention), BinaryData);
        }

        private struct Dictionary
        {
            public UInt32 CompressLenghe;
            public UInt32 Offset;

            public Dictionary(UInt32 argv, UInt32 argv1)
            {
                CompressLenghe = argv;
                Offset = argv1;
            }
        }

        private void CreateHeader()
        {
            int HeaderPlace = 0;
            Header[HeaderPlace++] = (byte)'Y';
            Header[HeaderPlace++] = (byte)'a';
            Header[HeaderPlace++] = (byte)'z';
            Header[HeaderPlace++] = (byte)'0';

            for(int i = 4; i > 0;)
            {
                i--;
                Header[HeaderPlace++] = (byte)(DecordDataSize >> (8 * i) & 0xff);
            }

            for(int i = 0; i < 8; i++)
            {
                Header[HeaderPlace++] = 0x00;
            }
            return;
        }

        private byte[]? Encord()
        {
            byte[]? CompressedVal = new byte[SourceData.Length];

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
                    UncompressFlagCoount = 8;
                }
                UncompressFlagCoount--;


                //serch(function)
                Dictionary dictionary = SerchDictionaly((int)SourceDataPlace);


                if (dictionary.CompressLenghe <= 2)
                {
                    //don't compress
                    CompressedVal[UncompressFlagWritePlace] |= (byte)(0x01 << UncompressFlagCoount);
                    CompressedVal[CompressedPlace++] = SourceData[SourceDataPlace++];

                }
                else
                {
                    //compress
                    uint TergetLength = dictionary.CompressLenghe;
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

            FileSize = CompressedPlace;

            return CompressedVal;
        }


        private Dictionary SerchDictionaly(int SourceDataPlace)
        {
            int CompLength = 0,
                CompLengthBuf = 0,
                CompLengthOffset = 0,
                MinReferencePlace = SourceDataPlace - 1,
                MaxReferencePlace = MinReferencePlace - 0x0fff; // 0xfff は参照できる最大要素数

            if(MaxReferencePlace < 0)
            {
                MaxReferencePlace = 0;

            }

            for(int DictionaryPlace = MaxReferencePlace; DictionaryPlace < SourceDataPlace; DictionaryPlace++)
            {
                CompLengthBuf = 0;

                while (SourceData[DictionaryPlace + CompLengthBuf] == SourceData[SourceDataPlace + CompLengthBuf])
                {
                    CompLengthBuf++;

                    if (SourceDataPlace + CompLengthBuf == DecordDataSize ||
                        CompLengthBuf > 0x0112 //0x0112 = (0x10 + 0x2) + 0x100 : 最大圧縮データサイズ = 2Byteの要素数 + 3Byteの要素数
                        )
                    {
                        CompLengthBuf--;
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
