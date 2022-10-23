using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCSectionSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCDirectoryEdit
{
    public sealed class RARCDirectorySystem
    {
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

        /// <summary>
        /// RARCファイルをディレクトリに展開するためのコアメソッド
        /// </summary>
        /// <param name="rarcArchive"></param>
        /// <param name="destinationDirectoryName"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static void ExtractToDirectoryCore(RARCArchive rarcArchive, string destinationDirectoryName) 
        {
            string? rarcExtractDirectoryFullPath = GetExtractTargetDirectory(destinationDirectoryName);

            string workingDirectoryName = Path.GetFileNameWithoutExtension(destinationDirectoryName);

            string workingDirFullPath = Path.Combine(rarcExtractDirectoryFullPath, workingDirectoryName);

            CreateDirectoryWhenDirectoryNotExist(workingDirFullPath);

            Dictionary<(string,uint), string> directoryNodeDirectoryNames = new();

            for (int dirIndex = 0; dirIndex < rarcArchive.DirectoryNodeSection.DirectoryNodes.Length; dirIndex++)
            {

                uint currentDirectoryID = rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].DirectoryItems[^2].Argments.Item1;

                if (rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].ParentDirectoryName == "ROOT")
                {
                    //ルートディレクトリの作成
                    string rootDirectoryFullPath = Path.Combine(workingDirFullPath, rarcArchive.StringTableSection.ReadRootName());
                    if (!Directory.Exists(rootDirectoryFullPath))
                    {
                        Directory.CreateDirectory(rootDirectoryFullPath);
                    }
                    directoryNodeDirectoryNames.Add((rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].CurrentDirectoryName, currentDirectoryID), rootDirectoryFullPath);

                    //現在のディレクトリ内のサブディレクトリの作成
                    foreach (string subDirName in rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].SubDirectories)
                    {
                        string subPath = Path.Combine(rootDirectoryFullPath, subDirName);
                        if (!Directory.Exists(subPath))
                        {
                            Directory.CreateDirectory(subPath);
                        }

                        directoryNodeDirectoryNames.Add((subDirName, (uint)rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].SubDirectories.IndexOf(subDirName)), subPath);

                    }

                    //現在のディレクトリ内にあるファイルを生成
                    foreach (KeyValuePair<(string,uint), byte[]> includeFile in rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].IncludeFileNameBinaryPairs)
                    {
                        string fileFullPath = Path.Combine(rootDirectoryFullPath, includeFile.Key.Item1);
                        using FileStream fs = new(fileFullPath, FileMode.Create);
                        using BinaryWriter bw = new(fs);
                        bw.Write(includeFile.Value);
                        Debug.WriteLine(fileFullPath.Substring(workingDirFullPath.Length));
                        rarcArchive.FilePathBinaryDataPairs.Add(fileFullPath.Substring(workingDirFullPath.Length), includeFile.Value);
                    }
                }
                else
                {
                    var FoundSerchDirectory = directoryNodeDirectoryNames.ContainsKey
                        ((rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].CurrentDirectoryName,currentDirectoryID));

                    if (!FoundSerchDirectory)
                    {
                        int rarcEntryCount = rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].DirectoryItems.Count();
                        uint parentDirectoryIndex =rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].DirectoryItems[rarcEntryCount -1].Argments.Item1;
                        
                        string parentDirFullPath = directoryNodeDirectoryNames[(rarcArchive.DirectoryNodeSection.DirectoryNodes[parentDirectoryIndex].CurrentDirectoryName, parentDirectoryIndex)];
                        string curFullPath = Path.Combine(parentDirFullPath, rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].CurrentDirectoryName);
                        if (!Directory.Exists(curFullPath))
                        {
                            Directory.CreateDirectory(curFullPath);
                        }
                        directoryNodeDirectoryNames.Add((rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].CurrentDirectoryName, currentDirectoryID), curFullPath);

                        foreach (string subDirName in rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].SubDirectories)
                        {
                            DirectoryUtil.CreateDirectoryWhenDirectoryNotExist(curFullPath, subDirName, out string subPath);
                            directoryNodeDirectoryNames.Add((subDirName, currentDirectoryID), subPath);
                        }

                        foreach (KeyValuePair<(string, uint), byte[]> includeFile in rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].IncludeFileNameBinaryPairs)
                        {
                            string fileFullPath = Path.Combine(curFullPath, includeFile.Key.Item1);
                            //Debug.WriteLine(fileFullPath);
                            using FileStream fs = new(fileFullPath, FileMode.Create);
                            using BinaryWriter bw = new(fs);
                            bw.Write(includeFile.Value);
                            Debug.WriteLine(fileFullPath.Substring(workingDirFullPath.Length));
                            rarcArchive.FilePathBinaryDataPairs.Add(fileFullPath.Substring(workingDirFullPath.Length), includeFile.Value);
                        }
                    }
                    else
                    {
                        string parentDirFullPath = directoryNodeDirectoryNames[(rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].CurrentDirectoryName, currentDirectoryID)];
                        
                        //現在のディレクトリの作成
                        string curPath = parentDirFullPath;
                        if (!Directory.Exists(curPath))
                        {
                            Directory.CreateDirectory(curPath);
                            
                        }
                        directoryNodeDirectoryNames.Add((rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].CurrentDirectoryName, currentDirectoryID), curPath);

                        foreach (string subDirName in rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].SubDirectories)
                        {
                            DirectoryUtil.CreateDirectoryWhenDirectoryNotExist(curPath, subDirName, out string subPath);
                            directoryNodeDirectoryNames.Add((subDirName,currentDirectoryID), subPath);
                        }

                        foreach (KeyValuePair<(string,uint), byte[]> includeFile in rarcArchive.DirectoryNodeSection.DirectoryNodes[dirIndex].IncludeFileNameBinaryPairs)
                        {
                            string fileFullPath = Path.Combine(curPath, includeFile.Key.Item1);
                            using FileStream fs = new(fileFullPath, FileMode.Create);
                            using BinaryWriter bw = new(fs);
                            bw.Write(includeFile.Value);
                            Debug.WriteLine(fileFullPath.Substring(workingDirFullPath.Length));
                            rarcArchive.FilePathBinaryDataPairs.Add(fileFullPath.Substring(workingDirFullPath.Length), includeFile.Value);
                        }
                    }

                }
            }
        }
    }
}
