using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public static class RARCFile
    {
        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName) 
        {
        
        }

        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName) 
        {
            if (!File.Exists(sourceArchiveFileName)) 
            {
                Debug.WriteLine($"このアーカイブファイルは存在しません\n{sourceArchiveFileName}");
                return;
            }

            using FileStream fs = new(sourceArchiveFileName, FileMode.Open);
            RARCArchive rarcArchive = new(fs);
            //foreach (RARCArchiveEntry entry in rarcArchive.Entries) 
            //{

            //}
        }

        public static void ExtractToDirectory(byte[] sourceArchiveBinaries, string yaz0FullPath)
        {
            using MemoryStream ms = new(sourceArchiveBinaries);
            RARCArchive rarcArchive = new(ms);
            string yaz0IncludeDirectory = Path.GetDirectoryName(yaz0FullPath);

            string rootDirName = Path.GetFileNameWithoutExtension(yaz0FullPath);
            

            if (!Directory.Exists(yaz0IncludeDirectory)) 
            {
                throw new DirectoryNotFoundException();
            }

            //ルートディレクトリの作成
            string rootDirFullPath = Path.Combine(yaz0IncludeDirectory, rootDirName);
            if (!Directory.Exists(rootDirFullPath)) 
            {
                Directory.CreateDirectory(rootDirFullPath);
            }

            //foreach (var fileEntry in rarcArchive.FileKeyValuePairs)
            //{
            //    using FileStream fs = new(Path.Combine(Path.Combine(destinationDirectoryName, @"Export"), fileEntry.Key), FileMode.Create);
            //    using BinaryWriter bw = new(fs);
            //    bw.Write(fileEntry.Value);
            //}

            Dictionary<string,string> directoryNodeDirectoryNames = new();
            for (int dirIndex = 0; dirIndex < rarcArchive.DirectoryNodes.Length; dirIndex++) 
            {
                
                if (rarcArchive.DirectoryNodes[dirIndex].ParentDirectoryName == "ROOT")
                {
                    //現在のディレクトリの作成
                    string curPath = Path.Combine(rootDirFullPath, rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName);
                    if (!Directory.Exists(curPath))
                    {
                        Directory.CreateDirectory(curPath);
                    }
                    directoryNodeDirectoryNames.Add(rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName, curPath);

                    //現在のディレクトリ内のサブディレクトリの作成
                    foreach (string subDirName in rarcArchive.DirectoryNodes[dirIndex].SubDirectories)
                    {
                        string subPath = Path.Combine(curPath, subDirName);
                        if (!Directory.Exists(subPath))
                        {
                            Directory.CreateDirectory(subPath);
                        }
                        directoryNodeDirectoryNames.Add(subDirName,subPath);
                    }

                    //現在のディレクトリ内にあるファイルを生成
                    foreach (KeyValuePair<string, byte[]> includeFile in rarcArchive.DirectoryNodes[dirIndex].IncludeFileNameBinaryPairs)
                    {
                        string fileFullPath = Path.Combine(curPath, includeFile.Key);
                        using FileStream fs = new(fileFullPath, FileMode.Create);
                        using BinaryWriter bw = new(fs);
                        bw.Write(includeFile.Value);
                    }
                }
                else 
                {
                    string? serchDir = directoryNodeDirectoryNames.Keys.LastOrDefault(rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName);

                    if (serchDir == default)
                    {
                        //if (!Directory.Exists())
                        //{
                        //    Directory.CreateDirectory(curPath);
                        //}
                        Debug.WriteLine("\n\r\n\rSarchDir_DEF↓"+serchDir);
                    }
                    else 
                    {
                        Debug.WriteLine("\n\r\n\rSarchDir↓" + serchDir);
                        Debug.WriteLine(rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName);
                        Debug.WriteLine("////////////////////////////////////////");
                        string parentDirFullPath = directoryNodeDirectoryNames[rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName];

                        //現在のディレクトリの作成
                        string curPath = parentDirFullPath;
                        //string curPath = Path.Combine(parentDirFullPath, rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName);
                        if (!Directory.Exists(curPath))
                        {
                            Directory.CreateDirectory(curPath);
                            directoryNodeDirectoryNames.Add(rarcArchive.DirectoryNodes[dirIndex].CurrentDirectoryName, curPath);
                        }
                        

                        foreach (string subDirName in rarcArchive.DirectoryNodes[dirIndex].SubDirectories)
                        {
                            DirectoryUtil.CreateDirectoryWhenDirectoryNotExist(curPath,subDirName,out string subPath);
                            directoryNodeDirectoryNames.Add(subDirName, subPath);
                        }

                        foreach (KeyValuePair<string, byte[]> includeFile in rarcArchive.DirectoryNodes[dirIndex].IncludeFileNameBinaryPairs)
                        {
                            string fileFullPath = Path.Combine(curPath, includeFile.Key);
                            using FileStream fs = new(fileFullPath, FileMode.Create);
                            using BinaryWriter bw = new(fs);
                            bw.Write(includeFile.Value);
                        }
                    }
                    
                }
            }
        }

        public static RARCArchive Open(string arciveFileName) 
        {
            throw new NotImplementedException();
        }

        public static RARCArchive OpenRead(string arciveFileName) 
        {
            using (FileStream fs = new(arciveFileName, FileMode.Open))
            {
                return new RARCArchive(fs);
            };
        }

        public static RARCArchive OpenRead(byte[] arciveBinaries)
        {
            using (MemoryStream ms = new(arciveBinaries))
            {
                return new RARCArchive(ms);
            };
        }
    }
}
