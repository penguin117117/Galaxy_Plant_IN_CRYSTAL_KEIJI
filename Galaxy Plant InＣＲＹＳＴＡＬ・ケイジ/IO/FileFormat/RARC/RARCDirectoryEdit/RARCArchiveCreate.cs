using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCDirectoryEdit
{
    internal class RARCArchiveCreate
    {
        public static RARCArchive? FromDirectory(string sourceDirectoryName) 
        {
            string[]? sortedDirectoriesPath = ReadDirectoryNameAndSort(sourceDirectoryName);
            string[]? sortedFilesPath = ReadFilesNameAndSort(sourceDirectoryName);

            if (sortedDirectoriesPath == null) return null;
            if (sortedFilesPath == null) return null;

            var createRARCFileFullPath = GenerateDestinationPath(sourceDirectoryName);

            try
            {
                DirectoryItemCount(sortedDirectoriesPath);
            }
            catch (DirectoryNotFoundException dirNotFoundEx) 
            {
                MessageBox.Show(dirNotFoundEx.Message);
                return null;
            }
            
            //書き込みの開始
            using MemoryStream ms = new();
            using BinaryWriter bw = new(ms);

            bw.Write(Encoding.ASCII.GetBytes("RARC"));
            BinarySystem.NullWrite4Byte(bw);
            BinarySystem.WriteUint32BigEndian(bw,0x00000020);
            BinarySystem.NullWrite4Byte(bw, 5);

            RARCArchive rarcArchive = new();
            
            

            return rarcArchive;
        }

        public static void FromDirectory(string sourceDirectoryName, string destinationArchiveFileName)
        {


            string[]? sortedDirectoriesPath = ReadDirectoryNameAndSort(sourceDirectoryName);
            string[]? sortedFilesPath = ReadFilesNameAndSort(sourceDirectoryName);

            try
            {
                DirectoryItemCount(sortedDirectoriesPath);
            }
            catch (DirectoryNotFoundException dirNotFoundEx)
            {
                MessageBox.Show(dirNotFoundEx.Message);
                return;
            }


            return;

            //書き込みの開始
            using FileStream fs = new(destinationArchiveFileName, FileMode.Create);
            using BinaryWriter bw = new(fs);
        }

        private static string GenerateDestinationPath(string sourceDirectoryName) 
        {
            var workingDir = Directory.GetParent(sourceDirectoryName).Parent.FullName;
            var rarcFolder = Path.GetDirectoryName(sourceDirectoryName);
            var rarcFile = Path.GetFileName(rarcFolder);
            if (!Directory.Exists(rarcFolder)) throw new DirectoryNotFoundException();
            return Path.Combine(workingDir, rarcFile+".arc");

        }

        /// <summary>
        /// アーカイブ化するディレクトリ内の「サブディレクトリ」と「ファイル」の合計を計算します。
        /// </summary>
        /// <param name="archiveDirectoriesPath"></param>
        /// <returns>フォルダの個数</returns>
        private static Dictionary<string,int> DirectoryItemCount(string[] archiveDirectoriesPath)
        {
            Dictionary<string,int> allDirectories = new();

            foreach (string currentDirectoryPath in archiveDirectoriesPath)
            {
                string[] currentDirectorySubDirectoriesPath
                    = Directory.GetDirectories(currentDirectoryPath, "*", SearchOption.TopDirectoryOnly);

                foreach(string curDirPath in currentDirectorySubDirectoriesPath) 
                {
                    Debug.WriteLine($"curDirPath:::{curDirPath}");
                }

                string[] currentDirectoryFiles 
                    = Directory.GetFiles(currentDirectoryPath, "*", SearchOption.TopDirectoryOnly);

                foreach (string curDirFile in currentDirectoryFiles) 
                {
                    Debug.WriteLine(curDirFile);
                }

                int currentDirectoryItemCount 
                    = currentDirectorySubDirectoriesPath.Length + currentDirectoryFiles.Length + 2;

                allDirectories.Add(currentDirectoryPath,currentDirectoryItemCount);
            }

            return allDirectories;
        }

        /// <summary>
        /// <paramref name="path"/> で指定されたディレクトリに含まれるサブディレクトリを取得し名前順に並び替えます。
        /// </summary>
        /// <param name="path"></param>
        /// <returns>名前順にソートされたサブディレクトリ名の <see cref="string"/>型 の配列</returns>
        private static string[]? ReadDirectoryNameAndSort(string path)
        {
            string[]? sortedDirectoriesPath = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).OrderBy(sort => sort).ToArray();

            if (sortedDirectoriesPath.Length < 1)
            {
                MessageBox.Show("このフォルダは、内包されたディレクトリが無いため圧縮できません。");
                return null;
            }

            return sortedDirectoriesPath;
        }

        /// <summary>
        /// <paramref name="path"/> で指定されたディレクトリに含まれるファイルを取得し名前順に並び替えます。
        /// </summary>
        /// <param name="path"></param>
        /// <returns>名前順にソートされたファイル名の <see cref="string"/>型 の配列</returns>
        private static string[]? ReadFilesNameAndSort(string path)
        {
            string[]? sortedFilesPath = Directory.GetFiles(path, "*", SearchOption.AllDirectories).OrderBy(sort => sort).ToArray();

            if (sortedFilesPath.Length < 1)
            {
                MessageBox.Show("このフォルダは、内包されたファイルが無いため圧縮できません。");
                return null;
            }

            return sortedFilesPath;
        }
    }
}
