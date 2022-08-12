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
            UInt32 mazic;  //0x00
            UInt32 fileSize;   //0x04
            UInt32 dataHeaderOffset;   //0x08
            UInt32 fileDataSectionOffset;  //0x0c
            UInt32 fileDataSectionLength;  //0x10
            UInt32 fileDataSectionAllMRAM; //0x14
            UInt32 fileDataSectionAllARAM; //0x18
            UInt32 fileDataSectionAllROM;  //0x1c
        }

        struct dataHeader //0x20
        {
            UInt32 dirNodeNumber;  //0x00
            UInt32 dirNodeOffset;  //0x04
            UInt32 fileNodeNumber; //0x08
            UInt32 fileNodeOffset; //0x0c
            UInt32 stringNodeNumber;   //0x10
            UInt32 stringNodeOffset;   //0x14
            UInt16 nextAvailableFileIndex; //0x18
            char keepIDSync;  //0x1a
            char padding1;    //0x1b
            char padding2;
            char padding3;
            char padding4;
            char padding5;
        }

        struct dirNodeSection //0x10
        {
            UInt32 nodeNameFirst4String;    //0x00
            UInt32 nodeNameOffsetIntoStringTable;   //0x04
            UInt16 nameHash;    //0x08
            UInt16 fileNodeEntryNumb;  //0x0a
            UInt32 fileNodeOffset; //0x0c
        }

        struct fileNodeSection //0x10
        {
            UInt16 nodeIndex;  //0x00
            UInt16 nameHash;   //0x02
            char nodeAttributesFlag;  //0x04
            char padding; //0x05
            UInt16 nodeNameOffsetIntoStringTable;  //0x06
            UInt32 dataIndex;  //0x08
            UInt32 sizeForDataindex;   //0x0c
        }
    }
}
