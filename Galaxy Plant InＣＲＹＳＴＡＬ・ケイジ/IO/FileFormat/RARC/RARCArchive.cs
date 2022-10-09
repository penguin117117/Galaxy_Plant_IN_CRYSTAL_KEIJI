using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System.Diagnostics;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public class RARCArchive : IDisposable
    {
        public RARCHeader RARCHeader { get; private set; }
        public RARCEntryHeader RARCEntryHeader { get; private set; }
        public DirectoryNode[] DirectoryNodes { get; private set; }
        //public List<RARCEntry> RARCEntries { get; private set; }
        public Dictionary<string, byte[]> FileKeyValuePairs{ get; private set; }
        private Dictionary<uint, string> directoryKeyValuePairs;

        private Stream _stream;

        private long stringDataTablePosition;
        private long fileDataEndPosition;

        public RARCArchive(Stream stream) 
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));
            if (!stream.CanRead) throw new ArgumentException("このストリームは読み取りが出来ないかストリームが終了しています。");

            _stream = stream;
            using BinaryReader br = new(_stream);
            RARCHeader = new(br);
            RARCEntryHeader = new(br);

            DirectoryNodes = ReadDirectoryNodeSection(br);
            for (int dirNodeIndex = 0; dirNodeIndex < DirectoryNodes.Length; dirNodeIndex++) 
            {
                DirectoryNodes[dirNodeIndex].RARCEntries = ReadRARCEntries(br,DirectoryNodes[dirNodeIndex].FolderDirectoryCount);
            }
            BinarySystem.PaddingSkip(br.BaseStream);
            

            //String Table
            stringDataTablePosition = br.BaseStream.Position;
            br.ReadBytes(RARCEntryHeader.StringTableLength);
            Debug.WriteLine("StringTableSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            //FileDataSection
            FileKeyValuePairs = new Dictionary<string, byte[]>();
            foreach (DirectoryNode directoryNode in DirectoryNodes)
            {
                string dirPath = string.Empty;
                foreach (RARCEntry rarcEntry in directoryNode.RARCEntries)
                {
                    //ファイルデータの取得
                    Debug.WriteLine((RARCEntryType)rarcEntry.EntryType);
                    if ((rarcEntry.EntryType & RARCEntryType.File) == RARCEntryType.File)
                    {
                        byte[] fileBinaryData = br.ReadBytes((int)rarcEntry.Argments.Item2);
                        BinarySystem.PaddingSkip(br.BaseStream);
                        Debug.WriteLine("FileEnd::" + br.BaseStream.Position.ToString("X"));
                        fileDataEndPosition = br.BaseStream.Position;

                        //ファイル名の取得
                        br.BaseStream.Seek(stringDataTablePosition + rarcEntry.NameOffset, SeekOrigin.Begin);
                        string fileName = BinarySystem.ReadStringNullEnd(br);
                        Debug.WriteLine("StringEndPosition: " + br.BaseStream.Position.ToString("X"));

                        //ストリームの位置を元に戻す
                        br.BaseStream.Seek(fileDataEndPosition, SeekOrigin.Begin);

                        Debug.WriteLine(fileName);
                        //ファイルのデータを格納
                        FileKeyValuePairs.Add(fileName, fileBinaryData);
                    }
                    else if ((rarcEntry.EntryType & RARCEntryType.Directory) == RARCEntryType.Directory)
                    {
                        long DirDataEndPosition = br.BaseStream.Position;

                        //ファイル名の取得
                        br.BaseStream.Seek(stringDataTablePosition + rarcEntry.NameOffset, SeekOrigin.Begin);
                        string dirName = BinarySystem.ReadStringNullEnd(br);
                        Debug.WriteLine("StringEndPosition: " + br.BaseStream.Position.ToString("X"));

                        //ストリームの位置を元に戻す
                        br.BaseStream.Seek(DirDataEndPosition, SeekOrigin.Begin);

                        if (dirName == ".")
                        {
                            directoryNode.Name = dirName;
                            Debug.WriteLine("dirName::" + dirName);
                        }
                    }
                    else
                    {
                        throw new DataMisalignedException("このRARCファイルは、ファイルエントリセクションのRARCEntryTypeが壊れています。");
                        Application.Exit();
                    }
                }
            }

            //Dictionary<string, Dictionary<string, byte[]>> DirectoryPathFileNameValuePairs = new();
            //FileKeyValuePairs = new Dictionary<string, byte[]>();
            //Dictionary<uint,string>DirectoriesPath = new();
            //foreach (DirectoryNode directoryNode in DirectoryNodes) 
            //{
            //    string dirPath = string.Empty;
            //    foreach (RARCEntry rarcEntry in directoryNode.RARCEntries) 
            //    {
            //        //ファイルデータの取得
            //        Debug.WriteLine((RARCEntryType)rarcEntry.EntryType);
            //        if ((rarcEntry.EntryType & RARCEntryType.File) == RARCEntryType.File)
            //        {
            //            byte[] fileBinaryData = br.ReadBytes((int)rarcEntry.Argments.Item2);
            //            BinarySystem.PaddingSkip(br.BaseStream);
            //            Debug.WriteLine("FileEnd::" + br.BaseStream.Position.ToString("X"));
            //            fileDataEndPosition = br.BaseStream.Position;

            //            //ファイル名の取得
            //            br.BaseStream.Seek(stringDataTablePosition + rarcEntry.NameOffset, SeekOrigin.Begin);
            //            string fileName = BinarySystem.ReadStringNullEnd(br);
            //            Debug.WriteLine("StringEndPosition: " + br.BaseStream.Position.ToString("X"));

            //            //ストリームの位置を元に戻す
            //            br.BaseStream.Seek(fileDataEndPosition, SeekOrigin.Begin);

            //            //ファイルのデータを格納
            //            FileKeyValuePairs.Add(fileName, fileBinaryData);
            //        }
            //        else if ((rarcEntry.EntryType & RARCEntryType.Directory) == RARCEntryType.Directory)
            //        {
            //            fileDataEndPosition = br.BaseStream.Position;

            //            //ファイル名の取得
            //            br.BaseStream.Seek(stringDataTablePosition + rarcEntry.NameOffset, SeekOrigin.Begin);
            //            string dirName = BinarySystem.ReadStringNullEnd(br);
            //            Debug.WriteLine("StringEndPosition: " + br.BaseStream.Position.ToString("X"));

            //            //ストリームの位置を元に戻す
            //            br.BaseStream.Seek(fileDataEndPosition, SeekOrigin.Begin);

            //            //ファイルのデータを格納
            //            if (!DirectoriesPath.ContainsKey(rarcEntry.Argments.Item1))
            //                DirectoriesPath.Add(rarcEntry.Argments.Item1,dirName);
            //        }
            //        else 
            //        {
            //            throw new DataMisalignedException("このRARCファイルは、ファイルエントリセクションのRARCEntryTypeが壊れています。");
            //            Application.Exit();
            //        }
            //    }

            //    DirectoryPathFileNameValuePairs.Add(DirectoriesPath[(uint)DirectoriesPath.Count - 2],FileKeyValuePairs);
            //}



            //FileKeyValuePairs = new Dictionary<string, byte[]>();
            //string dirPath = string.Empty;

            //directoryKeyValuePairs = new Dictionary<uint, string>();
            //foreach (RARCEntry rarcEntry in RARCEntries) 
            //{
            //    //ファイルデータの取得
            //    Debug.WriteLine((RARCEntryType)rarcEntry.EntryType);
            //    if ((rarcEntry.EntryType & RARCEntryType.File) == RARCEntryType.File)
            //    {
            //        byte[] fileBinaryData = br.ReadBytes((int)rarcEntry.Argments.Item2);
            //        BinarySystem.PaddingSkip(br.BaseStream);
            //        Debug.WriteLine("FileEnd::" + br.BaseStream.Position.ToString("X"));
            //        fileDataEndPosition = br.BaseStream.Position;

            //        //ファイル名の取得
            //        br.BaseStream.Seek(stringDataTablePosition + rarcEntry.NameOffset, SeekOrigin.Begin);
            //        string fileName = BinarySystem.ReadStringNullEnd(br);
            //        Debug.WriteLine("StringEndPosition: " + br.BaseStream.Position.ToString("X"));

            //        //ストリームの位置を元に戻す
            //        br.BaseStream.Seek(fileDataEndPosition, SeekOrigin.Begin);

            //        //ファイルのデータを格納
            //        FileKeyValuePairs.Add(fileName, fileBinaryData);
            //    }
            //    else if ((rarcEntry.EntryType & RARCEntryType.Directory) == RARCEntryType.Directory)
            //    {
            //        long defaultPos = br.BaseStream.Position;
            //        switch (rarcEntry.Argments.Item1) 
            //        {
            //            case 0xFFFFFFFF:
            //                br.BaseStream.Seek(stringDataTablePosition + rarcEntry.NameOffset, SeekOrigin.Begin);
            //                string directoryName = BinarySystem.ReadStringNullEnd(br);
            //                dirPath += directoryName;
            //                break;
            //        }

            //        br.BaseStream.Position = defaultPos;

            //    }
            //    else 
            //    {
            //        throw new DataMisalignedException("このRARCファイルは、ファイルエントリセクションのRARCEntryTypeが壊れています。");
            //        Application.Exit();
            //    }

            //}
        }

        private DirectoryNode[] ReadDirectoryNodeSection(BinaryReader br) 
        {
            //DirectoryNodeSection
            DirectoryNode[] directoryNodes = new DirectoryNode[RARCEntryHeader.NodeLength];
            for (int entryIndex = 0; entryIndex < RARCEntryHeader.NodeLength; entryIndex++)
            {
                directoryNodes[entryIndex] = DirectoryNode.Read(br);
            }
            BinarySystem.PaddingSkip(br.BaseStream);
            Debug.WriteLine("DirectoryNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            return directoryNodes;
        }

        private List<RARCEntry> ReadRARCEntries(BinaryReader br) 
        {
            //FileNodeSection
            List<RARCEntry> rarcEntries = new();
            for (int entryIndex = 0; entryIndex < RARCEntryHeader.TotalDirectoryCount; entryIndex++) 
            {
                rarcEntries.Add(new RARCEntry(br));
                //Debug.WriteLine(rarcEntries[entryIndex].NameOffset.ToString("X"));
            }
            BinarySystem.PaddingSkip(br.BaseStream);
            Debug.WriteLine("FileNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            return rarcEntries;
        }

        private  List<RARCEntry> ReadRARCEntries(BinaryReader br,short folderDirectoryCount)
        {
            //FileNodeSection
            List<RARCEntry> rarcEntries = new();
            for (int entryIndex = 0; entryIndex < folderDirectoryCount; entryIndex++)
            {
                rarcEntries.Add(new RARCEntry(br));
                //Debug.WriteLine(rarcEntries[entryIndex].NameOffset.ToString("X"));
            }
            //BinarySystem.PaddingSkip(br.BaseStream);
            Debug.WriteLine("FileNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            return rarcEntries;
        }

        public RARCArchiveEntry CreateEntry(string entryName) 
        {
            throw new NotImplementedException();
        }

        public RARCArchiveEntry? GetEntry(string entryName) 
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _stream.Close();
        }
    }
}
