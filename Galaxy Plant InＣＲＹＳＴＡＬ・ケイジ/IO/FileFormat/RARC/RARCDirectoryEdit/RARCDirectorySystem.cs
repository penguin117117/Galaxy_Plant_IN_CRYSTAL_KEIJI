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
        private static string GetWorkingDirectory(string destinationDirectoryName) 
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
            string? rarcExtractDirectoryPath = 
                GetWorkingDirectory(destinationDirectoryName);

            string rootDirectoryName = 
                Path.GetFileNameWithoutExtension(destinationDirectoryName);

            string rootDirFullPath = 
                Path.Combine(rarcExtractDirectoryPath, rootDirectoryName);

            CreateDirectoryWhenDirectoryNotExist(rootDirFullPath);

            Dictionary<(string,uint), string> directoryNodeDirectoryNames = new();

            for (int dirIndex = 0; dirIndex < rarcArchive.DirectoryNodes.Length; dirIndex++)
            {
                uint curDirectoryID = rarcArchive.DirectoryNodes[dirIndex].
                    RARCEntries[rarcArchive.DirectoryNodes[dirIndex].RARCEntries.Count() - 2].Argments.Item1;

                if (rarcArchive.DirectoryNodes[dirIndex].ParentDirectoryName == "ROOT")
                {
                    //ルートディレクトリの作成
                    string curPath = Path.Combine(rootDirFullPath, rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName);
                    if (!Directory.Exists(curPath))
                    {
                        Directory.CreateDirectory(curPath);
                    }
                    directoryNodeDirectoryNames.Add((rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName, curDirectoryID), curPath);

                    //現在のディレクトリ内のサブディレクトリの作成
                    foreach (string subDirName in rarcArchive.DirectoryNodes[dirIndex].SubDirectories)
                    {
                        string subPath = Path.Combine(curPath, subDirName);
                        if (!Directory.Exists(subPath))
                        {
                            Directory.CreateDirectory(subPath);
                        }

                        directoryNodeDirectoryNames.Add((subDirName, (uint)rarcArchive.DirectoryNodes[dirIndex].SubDirectories.IndexOf(subDirName)), subPath);

                        //foreach (var a in rarcArchive.DirectoryNodes[dirIndex].RARCEntries) 
                        //{
                        //    if(a.EntryType)

                        //}

                    }

                    //現在のディレクトリ内にあるファイルを生成
                    foreach (KeyValuePair<(string,uint), byte[]> includeFile in rarcArchive.DirectoryNodes[dirIndex].IncludeFileNameBinaryPairs)
                    {
                        string fileFullPath = Path.Combine(curPath, includeFile.Key.Item1);
                        Debug.WriteLine(fileFullPath);
                        using FileStream fs = new(fileFullPath, FileMode.Create);
                        using BinaryWriter bw = new(fs);
                        bw.Write(includeFile.Value);
                    }
                }
                else
                {
                    var FoundSerchDirectory = directoryNodeDirectoryNames.ContainsKey
                        ((rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName,curDirectoryID));

                    if (!FoundSerchDirectory)
                    {
                        int rarcEntryCount = rarcArchive.DirectoryNodes[dirIndex].RARCEntries.Count();
                        uint parentDirectoryIndex =rarcArchive.DirectoryNodes[dirIndex].RARCEntries[rarcEntryCount -1].Argments.Item1;
                        
                        string parentDirFullPath = directoryNodeDirectoryNames[(rarcArchive.DirectoryNodes[parentDirectoryIndex].CurrentDirectoryName, parentDirectoryIndex)];
                        string curFullPath = Path.Combine(parentDirFullPath, rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName);
                        //var a = Path.Combine(rarcArchive.DirectoryNodes[(int)rarcArchive.DirectoryNodes[dirIndex].RARCEntries[rarcArchive.DirectoryNodes[dirIndex].RARCEntries.Count() -2] , rarcArchive.DirectoryNodes[dirIndex].SubDirectories[(int)directoryID]);
                        if (!Directory.Exists(curFullPath))
                        {
                            Directory.CreateDirectory(curFullPath);
                        }
                        directoryNodeDirectoryNames.Add((rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName, curDirectoryID), curFullPath);

                        foreach (string subDirName in rarcArchive.DirectoryNodes[dirIndex].SubDirectories)
                        {
                            //var a = rarcArchive.DirectoryNodes[dirIndex].SubDirectories.IndexOf(subDirName);
                            //uint SubDirectoryID = rarcArchive.DirectoryNodes[dirIndex].
                            //    RARCEntries[rarcArchive.DirectoryNodes[dirIndex].RARCEntries.Count() - 2 /*- (1 + a)*/].Argments.Item1;
                            DirectoryUtil.CreateDirectoryWhenDirectoryNotExist(curFullPath, subDirName, out string subPath);
                            directoryNodeDirectoryNames.Add((subDirName, curDirectoryID), subPath);
                        }

                        foreach (KeyValuePair<(string, uint), byte[]> includeFile in rarcArchive.DirectoryNodes[dirIndex].IncludeFileNameBinaryPairs)
                        {
                            string fileFullPath = Path.Combine(curFullPath, includeFile.Key.Item1);
                            Debug.WriteLine(fileFullPath);
                            using FileStream fs = new(fileFullPath, FileMode.Create);
                            using BinaryWriter bw = new(fs);
                            bw.Write(includeFile.Value);
                        }

                        //Debug.WriteLine("\n\r\n\rSarchDir_DEF↓" + serchDir);
                        Debug.WriteLine("DEF//////////////////////////////////////");
                    }
                    else
                    {
                        //Debug.WriteLine("\n\r\n\rSarchDir↓" + serchDir);
                        //Debug.WriteLine(rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName);
                        //Debug.WriteLine("////////////////////////////////////////");

                        string parentDirFullPath = directoryNodeDirectoryNames[(rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName, curDirectoryID)];
                            //= directoryNodeDirectoryNames[serchDirectory/*(rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName, directoryID)*/];

                        //現在のディレクトリの作成
                        string curPath = parentDirFullPath;
                        //string curPath = Path.Combine(parentDirFullPath, rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName);
                        if (!Directory.Exists(curPath))
                        {
                            Directory.CreateDirectory(curPath);
                            
                        }
                        directoryNodeDirectoryNames.Add((rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName, curDirectoryID), curPath);

                        foreach (string subDirName in rarcArchive.DirectoryNodes[dirIndex].SubDirectories)
                        {
                            //var a = rarcArchive.DirectoryNodes[dirIndex].SubDirectories.IndexOf(subDirName);
                            //uint SubDirectoryID = rarcArchive.DirectoryNodes[dirIndex].
                            //    RARCEntries[rarcArchive.DirectoryNodes[dirIndex].RARCEntries.Count() - 2 /*- (1 + a)*/].Argments.Item1;
                            DirectoryUtil.CreateDirectoryWhenDirectoryNotExist(curPath, subDirName, out string subPath);
                            directoryNodeDirectoryNames.Add((subDirName,curDirectoryID), subPath);
                        }

                        foreach (KeyValuePair<(string,uint), byte[]> includeFile in rarcArchive.DirectoryNodes[dirIndex].IncludeFileNameBinaryPairs)
                        {
                            string fileFullPath = Path.Combine(curPath, includeFile.Key.Item1);
                            Debug.WriteLine(fileFullPath);
                            using FileStream fs = new(fileFullPath, FileMode.Create);
                            using BinaryWriter bw = new(fs);
                            bw.Write(includeFile.Value);
                        }
                    }

                }
            }
        }
    }
}
