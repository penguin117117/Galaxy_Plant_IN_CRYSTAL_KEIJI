using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.rarc
{
    namespace rarcFormat
    {
        struct header //0x20
        {
            internal UInt32 mazic;  //0x00
            internal UInt32 fileSize;   //0x04
            internal UInt32 dataHeaderOffset;   //0x08
            internal UInt32 fileDataSectionOffset;  //0x0c
            internal UInt32 fileDataSectionLength;  //0x10
            internal UInt32 fileDataSectionAllMRAM; //0x14
            internal UInt32 fileDataSectionAllARAM; //0x18
            internal UInt32 fileDataSectionAllROM;  //0x1c
        }

        struct dataHeader //0x20
        {
            internal UInt32 dirNodeNumber;  //0x00
            internal UInt32 dirNodeOffset;  //0x04
            internal UInt32 fileNodeNumber; //0x08
            internal UInt32 fileNodeOffset; //0x0c
            internal UInt32 stringNodeNumber;   //0x10
            internal UInt32 stringNodeOffset;   //0x14
            internal UInt16 nextAvailableFileIndex; //0x18
            internal char keepIDSync;  //0x1a
            internal char padding1;    //0x1b
            internal char padding2;
            internal char padding3;
            internal char padding4;
            internal char padding5;
        }

        struct dirNodeSection //0x10
        {
            internal UInt32 nodeNameFirst4String;    //0x00
            internal UInt32 nodeNameOffsetIntoStringTable;   //0x04
            internal UInt16 nameHash;    //0x08
            internal UInt16 fileNodeEntryNumb;  //0x0a
            internal UInt32 fileNodeOffset; //0x0c
        }

        struct fileNodeSection //0x10
        {
            internal UInt16 nodeIndex;  //0x00
            internal UInt16 nameHash;   //0x02
            internal char nodeAttributesFlag;  //0x04
            internal char padding; //0x05
            internal UInt16 nodeNameOffsetIntoStringTable;  //0x06
            internal UInt32 dataIndex;  //0x08
            internal UInt32 sizeForDataindex;   //0x0c
        }
    }
}
