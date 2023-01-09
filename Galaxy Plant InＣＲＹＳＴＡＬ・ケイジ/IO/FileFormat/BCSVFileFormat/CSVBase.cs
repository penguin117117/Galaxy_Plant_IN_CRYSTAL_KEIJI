using System.Data;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSVFileFormat
{
    public abstract class CSVBase
    {
        
        public abstract DataTable DataTable { get; protected set; }

        public abstract void Read(BinaryReader br);
    }
}