using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSVFileFormat
{
    public class BCSV : CSVBase
    {
        internal BCSVHeader BCSVHeader { get; private set; }
        internal BCSVColumns BCSVColumns { get; private set; }

        /// <summary>
        /// BCSVの行と列の情報を保持します。
        /// </summary>
        /// <!-- 
        /// DataGridViewクラスの制御に使用するためにこの型に入れる方が便利である。
        /// -->
        public override DataTable DataTable { get; protected set; }

        internal BCSV() 
        {
            DataTable= new DataTable();
            BCSVHeader   = new BCSVHeader();
            BCSVColumns  = new BCSVColumns();
            
        }

        public override void Read(BinaryReader br) 
        {
            BCSVHeader.Read(br);
            var bcsvColumns = BCSVColumns.Read(br ,BCSVHeader.ColumnsCount);
            DataTable.Columns.AddRange(bcsvColumns);
        }

        
    }
}
