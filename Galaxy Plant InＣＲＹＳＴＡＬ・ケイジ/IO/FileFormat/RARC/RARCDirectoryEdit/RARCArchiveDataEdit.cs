﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCDirectoryEdit
{
    internal class RARCArchiveDataEdit
    {
        private string rarcExtractDirectoryFullPath;
        private string workingDirectoryName;
        private string workingDirFullPath;
        private bool isCreateDirectoryAndFile;
        private Dictionary<(string, uint), string> directoryNodeDirectoryNames = new();

        internal RARCArchiveDataEdit() 
        {
            rarcExtractDirectoryFullPath = string.Empty;
            workingDirectoryName = string.Empty;
            workingDirFullPath = string.Empty;
        }

        /// <summary>
        /// <see cref="RARCArchive"/> をディレクトリに展開し辞書ファイルに取り込みます。
        /// </summary>
        /// <param name="rarcArchive"></param>
        /// <param name="destinationDirectoryName"></param>
        internal void ExtractToDirectory (RARCArchive rarcArchive, string destinationDirectoryName)
        {
            isCreateDirectoryAndFile = true;

            SetWorkingDirectoryPath(destinationDirectoryName);
            CreateDirectoryWhenDirectoryNotExist(workingDirFullPath);

            foreach (DirectoryNode directoryNode in rarcArchive.DirectoryNodeSection.DirectoryNodes)
            {
                uint currentDirectoryID = directoryNode.DirectoryItems[^2].Argments.Item1;

                if (directoryNode.ParentDirectoryName == "ROOT")
                {
                    //ルートディレクトリの作成
                    string rootDirectoryFullPath = Path.Combine(workingDirFullPath, rarcArchive.StringTableSection.ReadRootName());
                    CreateCurrentDirectory(directoryNode,currentDirectoryID,rootDirectoryFullPath);

                    //現在のディレクトリ内のサブディレクトリの作成
                    DirectoryIncludeSubDirectoryWriter(directoryNode, rootDirectoryFullPath);

                    //現在のディレクトリ内にあるファイルを生成
                    DirectoryIncludeFileWriter(rarcArchive, directoryNode, rootDirectoryFullPath);
                }
                else
                {
                    var FoundSerchDirectory = directoryNodeDirectoryNames.ContainsKey
                        ((directoryNode.CurrentDirectoryName, currentDirectoryID));

                    if (!FoundSerchDirectory)
                    {
                        uint parentDirectoryIndex = directoryNode.DirectoryItems[^1].Argments.Item1;

                        string parentDirFullPath = directoryNodeDirectoryNames[(rarcArchive.DirectoryNodeSection.DirectoryNodes[parentDirectoryIndex].CurrentDirectoryName, parentDirectoryIndex)];
                        
                        string curFullPath = Path.Combine(parentDirFullPath, directoryNode.CurrentDirectoryName);

                        CreateCurrentDirectory(directoryNode, currentDirectoryID, curFullPath);

                        DirectoryIncludeSubDirectoryWriter(directoryNode,curFullPath);

                        DirectoryIncludeFileWriter(rarcArchive, directoryNode, curFullPath);
                    }
                    else
                    {
                        string curPath = directoryNodeDirectoryNames[(directoryNode.CurrentDirectoryName, currentDirectoryID)];

                        CreateCurrentDirectory(directoryNode, currentDirectoryID, curPath);

                        DirectoryIncludeSubDirectoryWriter(directoryNode,curPath);

                        DirectoryIncludeFileWriter(rarcArchive, directoryNode, curPath);
                    }

                }
            }
        }

        /// <summary>
        /// <see cref="RARCArchive"/> を辞書ファイルに取り込みます。
        /// </summary>
        /// <param name="rarcArchive"></param>
        /// <param name="destinationDirectoryName"></param>
        internal void ExtractToDictionary(RARCArchive rarcArchive, string destinationDirectoryName) 
        {
            isCreateDirectoryAndFile = false;

            SetWorkingDirectoryPath(destinationDirectoryName);

            foreach (DirectoryNode directoryNode in rarcArchive.DirectoryNodeSection.DirectoryNodes)
            {
                uint currentDirectoryID = directoryNode.DirectoryItems[^2].Argments.Item1;

                if (directoryNode.ParentDirectoryName == "ROOT")
                {
                    //ルートディレクトリの作成
                    string rootDirectoryFullPath = Path.Combine(workingDirFullPath, rarcArchive.StringTableSection.ReadRootName());
                    CreateCurrentDirectory(directoryNode, currentDirectoryID, rootDirectoryFullPath);

                    //現在のディレクトリ内のサブディレクトリの作成
                    DirectoryIncludeSubDirectoryWriter(directoryNode, rootDirectoryFullPath);

                    //現在のディレクトリ内にあるファイルを生成
                    DirectoryIncludeFileWriter(rarcArchive, directoryNode, rootDirectoryFullPath);
                }
                else
                {
                    var FoundSerchDirectory = directoryNodeDirectoryNames.ContainsKey
                        ((directoryNode.CurrentDirectoryName, currentDirectoryID));

                    if (!FoundSerchDirectory)
                    {
                        uint parentDirectoryIndex = directoryNode.DirectoryItems[^1].Argments.Item1;

                        string parentDirFullPath = directoryNodeDirectoryNames[(rarcArchive.DirectoryNodeSection.DirectoryNodes[parentDirectoryIndex].CurrentDirectoryName, parentDirectoryIndex)];

                        string curFullPath = Path.Combine(parentDirFullPath, directoryNode.CurrentDirectoryName);

                        CreateCurrentDirectory(directoryNode, currentDirectoryID, curFullPath);

                        DirectoryIncludeSubDirectoryWriter(directoryNode, curFullPath);

                        DirectoryIncludeFileWriter(rarcArchive, directoryNode, curFullPath);
                    }
                    else
                    {
                        string curPath = directoryNodeDirectoryNames[(directoryNode.CurrentDirectoryName, currentDirectoryID)];

                        CreateCurrentDirectory(directoryNode, currentDirectoryID, curPath);

                        DirectoryIncludeSubDirectoryWriter(directoryNode, curPath);

                        DirectoryIncludeFileWriter(rarcArchive, directoryNode, curPath);
                    }

                }
            }
        }

        private void CreateCurrentDirectory(DirectoryNode directoryNode, uint currentDirectoryID, string curPath) 
        {
            if(isCreateDirectoryAndFile)
                CreateDirectoryWhenDirectoryNotExist(curPath);
            directoryNodeDirectoryNames.Add((directoryNode.CurrentDirectoryName, currentDirectoryID), curPath);
        }

        private void DirectoryIncludeSubDirectoryWriter(DirectoryNode directoryNode, string currentDirectoryFullPath) 
        {
            foreach (string subDirName in directoryNode.SubDirectories)
            {
                string subPath = Path.Combine(currentDirectoryFullPath, subDirName);
                if (isCreateDirectoryAndFile)
                    CreateDirectoryWhenDirectoryNotExist(subPath);
                var directoryNodeDirectoryName = (subDirName, (uint)directoryNode.SubDirectories.IndexOf(subDirName));
                if (directoryNodeDirectoryNames.ContainsKey(directoryNodeDirectoryName)) continue;
                directoryNodeDirectoryNames.Add(directoryNodeDirectoryName, subPath);
            }
        }

        private void DirectoryIncludeFileWriter(RARCArchive rarcArchive, DirectoryNode directoryNode, string currentPath) 
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
        private void SetWorkingDirectoryPath(string destinationDirectoryName) 
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
