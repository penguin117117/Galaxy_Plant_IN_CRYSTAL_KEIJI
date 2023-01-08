using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI.ControlsSetting.ProjectControls
{
    internal class BCSVComboBoxSetting
    {
        /// <summary>
        /// ディレクトリの名前からファイルのパスへのアクセスを容易にするためのデータ。
        /// <para>パス：このアプリケーション内で扱いやすくするためのパス</para>
        /// </summary>
        internal Dictionary<string, string[]> NameAndPathDictionary { get; private set; }

        internal BCSVComboBoxSetting() 
        {
            NameAndPathDictionary = new();
        }

        internal void SetComboBoxItems(ComboBox rootDirComboBox,string[] targetDirectoryFullPath) 
        {
            rootDirComboBox.Items.Clear();

            foreach (string projectSubDirectoryFullPath in targetDirectoryFullPath)
            {
                string projectSubDataName = Path.GetFileName(projectSubDirectoryFullPath);
                string[] subDataArray = Array.Empty<string>();

                //ファイル名の取得
                rootDirComboBox.Items.Add(projectSubDataName);

                if (Directory.Exists(projectSubDirectoryFullPath))
                {
                    //サブディレクトリに含まれる「ディレクトリ」
                    //または「ファイル」のフルパスを取得
                    subDataArray = Directory.GetFileSystemEntries(projectSubDirectoryFullPath);

                }
                else
                {
                    //サブディレクトリに含まれる「ファイル」のフルパスを取得
                    subDataArray = new string[] { projectSubDirectoryFullPath };

                }

                NameAndPathDictionary.Add(projectSubDataName, subDataArray);
            }
        }
    }
}
