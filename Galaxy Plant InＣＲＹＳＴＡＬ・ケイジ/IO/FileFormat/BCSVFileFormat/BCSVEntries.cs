using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSVFileFormat
{
    internal class BCSVEntries<BCSVEntry> : List<BCSVEntry>
    {
        

        internal void Read(BinaryReader br , DataTable dataTable , BCSVColumns bcsvColumns) 
        {

            for (int i = 0; i < bcsvColumns.Columns.Count(); i++) 
            {
                bcsvColumns.Columns[i].GetTest(br);
            }
            dataTable.Rows.Add();
        }
    }

    internal class BCSVEntry
    {
        private void Set() 
        {

            
            

        }
    }
}
