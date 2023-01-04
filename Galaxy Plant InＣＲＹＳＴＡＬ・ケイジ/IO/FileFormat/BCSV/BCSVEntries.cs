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

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV
{
    internal class BCSVEntries<BCSVEntry> : List<BCSVEntry>
    {
        internal void Read(BinaryReader br , BCSVColumns bcsvColumns) 
        {
            
        }
    }

    internal class BCSVEntry<T> : List<T>
    {
        DataTable DataTable = new DataTable();
        private void test() 
        {

            //DataTable.Columns.Add(,);
                
        }
    }
}
