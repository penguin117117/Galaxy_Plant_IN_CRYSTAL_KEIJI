using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV
{
    /*
    TODO:
    このクラスとサブクラス設計と整理
     */
    internal class BCSV
    {
        internal BCSVHeader BCSVHeader { get; private set; }
        internal BCSVColumns BCSVColumns { get; private set; }

        /// <summary>
        /// BCSVの行と列の情報を保持します。
        /// </summary>
        /// <!-- 
        /// DataGridViewクラスの制御に使用するためにこの型に入れる方が便利である。
        /// -->
        internal DataTable BCSVDataTable { get; private set; }

        internal BCSV() 
        {
            BCSVDataTable= new DataTable();
            BCSVHeader   = new BCSVHeader();
            BCSVColumns  = new BCSVColumns();
        }

        internal void Read(BinaryReader br) 
        {
            BCSVHeader.Read(br);
            var bcsvColumns = BCSVColumns.Read(br ,BCSVHeader.ColumnsCount);

            BCSVDataTable.Columns.AddRange(bcsvColumns);
        }

        
    }
}
