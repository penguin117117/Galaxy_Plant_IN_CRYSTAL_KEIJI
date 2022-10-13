using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO
{
    public class DirectoryUtil
    {
        /// <summary>
        /// 指定したディレクトリが 「存在しない」 場合にディレクトリを作成します。
        /// </summary>
        /// <param name="parentDirectoryFullPath">新しくフォルダを作成するディレクトリ</param>
        /// <param name="createDirectoryName"><seealso href="parentDirectoryFullPath"/>に作成するディレクトリの名称</param>
        /// <param name="createDirectoryFullPath"><seealso href="parentDirectoryFullPath"/>に作成するディレクトリのフルパス</param>
        /// <returns>
        /// ディレクトリを「作成した」場合に<see langword="true"/>を返します。<br/>
        /// 「作成しなかった」 場合に<see langword="false"/>を返します。
        /// </returns>
        public static bool CreateDirectoryWhenDirectoryNotExist(string parentDirectoryFullPath ,string createDirectoryName, out string createDirectoryFullPath) 
        {
            createDirectoryFullPath = 
                Path.Combine(parentDirectoryFullPath, createDirectoryName);
            
            if (Directory.Exists(createDirectoryFullPath))
                return false;
            
            Directory.CreateDirectory(createDirectoryFullPath);
            return true;
        }
    }
}
