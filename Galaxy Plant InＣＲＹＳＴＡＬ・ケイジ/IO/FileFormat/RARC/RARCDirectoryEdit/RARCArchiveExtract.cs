using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCDirectoryEdit
{
    internal class RARCArchiveExtract
    {
        private static string rarcExtractDirectoryFullPath = string.Empty;
        private static string workingDirectoryName = string.Empty;
        private static string workingDirFullPath = string.Empty;
        private static bool isCreateDirectoryAndFile;
        private static Dictionary<(string, uint), string> directoryNodeDirectoryNames = new();

        private static void Init() 
        {
            rarcExtractDirectoryFullPath = string.Empty;
            workingDirectoryName = string.Empty;
            workingDirFullPath = string.Empty;
            directoryNodeDirectoryNames = new();
        }

        /// <summary>
        /// <see cref="RARCArchive"/> をディレクトリに展開し辞書ファイルに取り込みます。
        /// </summary>
        /// <param name="rarcArchive"></param>
        /// <param name="destinationDirectoryName"></param>
        internal static void ToDirectory(RARCArchive rarcArchive, string destinationDirectoryName)
        {
            isCreateDirectoryAndFile = true;
            Init();

            SetWorkingDirectoryPath(destinationDirectoryName);
            CreateDirectoryWhenDirectoryNotExist(workingDirFullPath);

            ReadDirectoryData(rarcArchive);
        }

        /// <summary>
        /// <see cref="RARCArchive"/> を辞書ファイルに取り込みます。
        /// </summary>
        /// <param name="rarcArchive"></param>
        /// <param name="destinationDirectoryName"></param>
        internal static void ToDictionary(RARCArchive rarcArchive, string destinationDirectoryName)
        {
            isCreateDirectoryAndFile = false;
            Init();

            SetWorkingDirectoryPath(destinationDirectoryName);

            ReadDirectoryData(rarcArchive);
        }

        /// <summary>
        /// ディレクトリの情報を取得するためのクラス
        /// </summary>
        /// <param name="rarcArchive"></param>
        private static void ReadDirectoryData(RARCArchive rarcArchive)
        {
            foreach (DirectoryNode directoryNode in rarcArchive.DirectoryNodeSection.DirectoryNodes)
            {
                uint currentDirectoryID = directoryNode.DirectoryItems[^2].Argments.Item1;

                if (directoryNode.ParentDirectoryName == "ROOT")
                {
                    string rootDirectoryFullPath = Path.Combine(workingDirFullPath, rarcArchive.StringTableSection.ReadRootName());

                    SetCurrentDirectoryInfomation(rarcArchive, directoryNode, currentDirectoryID, rootDirectoryFullPath);

                    continue;
                }

                var FoundSerchDirectory = directoryNodeDirectoryNames.ContainsKey
                    ((directoryNode.CurrentDirectoryName, currentDirectoryID));

                if (FoundSerchDirectory)
                {
                    string curPath = directoryNodeDirectoryNames[(directoryNode.CurrentDirectoryName, currentDirectoryID)];

                    SetCurrentDirectoryInfomation(rarcArchive, directoryNode, currentDirectoryID, curPath);

                    continue;
                }

                uint parentDirectoryIndex = directoryNode.DirectoryItems[^1].Argments.Item1;

                string parentDirFullPath = directoryNodeDirectoryNames[(rarcArchive.DirectoryNodeSection.DirectoryNodes[parentDirectoryIndex].CurrentDirectoryName, parentDirectoryIndex)];

                string curFullPath = Path.Combine(parentDirFullPath, directoryNode.CurrentDirectoryName);

                SetCurrentDirectoryInfomation(rarcArchive, directoryNode, currentDirectoryID, curFullPath);

            }
        }

        private static void SetCurrentDirectoryInfomation(RARCArchive rarcArchive, DirectoryNode directoryNode, uint currentDirectoryID, string curPath)
        {
            SetCurrentDirectory(directoryNode, currentDirectoryID, curPath);

            SetSubDirectory(directoryNode, curPath);

            SetIncludeFiles(rarcArchive, directoryNode, curPath);
        }

        /// <summary>
        /// ディレクトリノードセクションの現在のディレクトリ情報を取得します。
        /// </summary>
        /// <param name="directoryNode"></param>
        /// <param name="currentDirectoryID"></param>
        /// <param name="curPath"></param>
        private static void SetCurrentDirectory(DirectoryNode directoryNode, uint currentDirectoryID, string curPath)
        {
            if (isCreateDirectoryAndFile)
            {
                CreateDirectoryWhenDirectoryNotExist(curPath);
            }

            directoryNodeDirectoryNames.Add((directoryNode.CurrentDirectoryName, currentDirectoryID), curPath);
        }

        private static void SetSubDirectory(DirectoryNode directoryNode, string currentDirectoryFullPath)
        {
            foreach (string subDirName in directoryNode.SubDirectories)
            {
                string subPath = Path.Combine(currentDirectoryFullPath, subDirName);

                if (isCreateDirectoryAndFile)
                {
                    CreateDirectoryWhenDirectoryNotExist(subPath);
                }

                var directoryNodeDirectoryName = (subDirName, (uint)directoryNode.SubDirectories.IndexOf(subDirName));

                if (directoryNodeDirectoryNames.ContainsKey(directoryNodeDirectoryName))
                {
                    continue;
                }

                directoryNodeDirectoryNames.Add(directoryNodeDirectoryName, subPath);
            }
        }

        private static void SetIncludeFiles(RARCArchive rarcArchive, DirectoryNode directoryNode, string currentPath)
        {
            foreach (KeyValuePair<(string, uint), byte[]> includeFile in directoryNode.IncludeFileNameBinaryPairs)
            {
                string fileFullPath = Path.Combine(currentPath, includeFile.Key.Item1);

                if (isCreateDirectoryAndFile)
                {
                    using FileStream fs = new(fileFullPath, FileMode.Create);
                    using BinaryWriter bw = new(fs);
                    bw.Write(includeFile.Value);
                }

                rarcArchive.FilePathBinaryDataPairs.Add(fileFullPath.Substring(workingDirFullPath.Length), includeFile.Value);
            }
        }

        /// <summary>
        /// ファイルを展開する作業ファイルのパスを作成します。
        /// </summary>
        /// <param name="destinationDirectoryName"></param>
        private static void SetWorkingDirectoryPath(string destinationDirectoryName)
        {
            rarcExtractDirectoryFullPath = GetExtractTargetDirectory(destinationDirectoryName);

            workingDirectoryName = Path.GetFileNameWithoutExtension(destinationDirectoryName);

            workingDirFullPath = Path.Combine(rarcExtractDirectoryFullPath, workingDirectoryName);
        }

        /// <summary>
        /// RARCファイルを展開する作業ディレクトリのフルパスを取得します。
        /// </summary>
        /// <param name="destinationDirectoryName"></param>
        /// <returns><see cref="string"/>型 作業ディレクトリのフルパス</returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        private static string GetExtractTargetDirectory(string destinationDirectoryName)
        {
            string? rarcFileDirectory = Path.GetDirectoryName(destinationDirectoryName);

            if (!Directory.Exists(rarcFileDirectory))
            {
                throw new DirectoryNotFoundException($"{nameof(rarcFileDirectory)}で指定された{rarcFileDirectory}のディレクトリは存在しません。");
            }

            return rarcFileDirectory;
        }

        private static void CreateDirectoryWhenDirectoryNotExist(string rootDirFullPath)
        {
            if (!Directory.Exists(rootDirFullPath))
            {
                Directory.CreateDirectory(rootDirFullPath);
            }
        }
    }
}
