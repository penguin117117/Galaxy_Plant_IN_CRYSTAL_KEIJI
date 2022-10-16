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
    /// <summary>
    /// RARCのアーカイブ情報を保持します。<br/>
    /// このクラスは継承できません。
    /// </summary>
    public sealed class RARCArchive
    {
        public RARCHeader RARCHeader { get; private set; }
        public RARCEntryHeader RARCEntryHeader { get; private set; }
        public DirectoryNode[] DirectoryNodes { get; private set; }

        private long stringDataTablePosition;

        /// <summary>
        /// RARCのアーカイブ情報を保持します。<br/>
        /// このクラスは継承できません。
        /// </summary>
        /// <param name="br"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public RARCArchive(BinaryReader br) 
        {
            if(br.BaseStream == null)
                throw new NullReferenceException(nameof(br.BaseStream));
            if (!br.BaseStream.CanRead) 
                throw new ArgumentException("このストリームは読み取りが出来ないかストリームが終了しています。");

            RARCHeader = new(br);
            if (!RARCHeader.IsRARC())
            {
                byte[] littleEndian = BitConverter.GetBytes(RARCHeader.SectionName);
                byte[] bigEndian = littleEndian.Reverse().ToArray();
                throw new DataMisalignedException($"このファイルは、「RARCファイル」ではなく {Encoding.ASCII.GetString(bigEndian)}ファイルです。");
            } 
            RARCEntryHeader = new(br);
            DirectoryNodes = ReadDirectoryNodeSection(br);
            ReadArchive(br);
        }


        /// <summary>
        /// <see cref="RARCArchive"/>　を　<paramref name="br"/>　で指定した　<see cref="BinaryReader"/>　から読み込みます。
        /// </summary>
        /// <param name="br"></param>
        /// <exception cref="DataMisalignedException"></exception>
        public void ReadArchive(BinaryReader br) 
        {
            //各DirectoryNodeに含まれるRARCEntriesをセットします。
            for (int dirNodeIndex = 0; dirNodeIndex < DirectoryNodes.Length; dirNodeIndex++)
            {
                DirectoryNodes[dirNodeIndex].RARCEntries = ReadRARCEntries(br, DirectoryNodes[dirNodeIndex].FolderDirectoryCount);
                Debug.WriteLine($"DirectoryNodeIndex::::::::::::{dirNodeIndex}");
            }
            BinarySystem.PaddingSkip(br.BaseStream);

            //String Table
            stringDataTablePosition = br.BaseStream.Position;
            br.ReadBytes(RARCEntryHeader.StringTableLength);
            //Debug.WriteLine("StringTableSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            //FileDataSection
            //FileKeyValuePairs = new Dictionary<string, byte[]>();
            foreach (DirectoryNode directoryNode in DirectoryNodes)
            {
                string dirPath = string.Empty;
                foreach (RARCEntry rarcEntry in directoryNode.RARCEntries)
                {
                    //ファイルデータの取得
                    if ((rarcEntry.EntryType & RARCEntryType.File) == RARCEntryType.File)
                    {
                        byte[] fileBinaryData = br.ReadBytes((int)rarcEntry.Argments.Item2);
                        BinarySystem.PaddingSkip(br.BaseStream);
                        //Debug.WriteLine("FileEnd::" + br.BaseStream.Position.ToString("X"));

                        string fileName = BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.NameOffset);

                        Debug.WriteLine($"FileName::{(RARCEntryType)rarcEntry.EntryType}::{fileName}::{(uint)rarcEntry.ID}");
                        //ファイルのデータを格納
                        //FileKeyValuePairs.Add(fileName, fileBinaryData);
                        directoryNode.IncludeFileNameBinaryPairs.Add((fileName,(uint)rarcEntry.ID), fileBinaryData);
                    }
                    else if ((rarcEntry.EntryType & RARCEntryType.Directory) == RARCEntryType.Directory)
                    {
                        string directoryName = 
                            BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.NameOffset);

                        if (directoryName == ".")
                        {
                            directoryNode.CurrentDirectoryName = 
                                BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + directoryNode.DirectoryNameOffset);
                            //Debug.WriteLine("CurrentDirectoryName::" + directoryNode.CurrentDirectoryName);
                        }
                        else if (directoryName == "..")
                        {
                            //親ディレクトリがルートディレクトリのケース
                            if (rarcEntry.Argments.Item1 == 0xFFFFFFFF)
                            {
                                directoryNode.ParentDirectoryName = "ROOT";
                                //Debug.WriteLine("ParentDirectoryName::" + directoryNode.ParentDirectoryName);
                                continue;
                            }
                            directoryNode.ParentDirectoryName = BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.NameOffset);
                            //directoryNode.ParentDirectoryName = rarcEntry.Argments.Item1
                            Debug.WriteLine("ParentDirectoryName::" + directoryNode.ParentDirectoryName);

                        }
                        else
                        {
                            //string subDir = BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.Argments.Item1);
                            directoryNode.SubDirectories.Add(directoryName);
                            //directoryNode..Add((dirName,rarcEntry.Argments.Item1),);
                            //Debug.WriteLine("SubDirectoryName::" + dirName);
                        }
                    }
                    else
                    {
                        throw new DataMisalignedException("このRARCファイルは、ファイルエントリセクションのRARCEntryTypeが壊れています。");
                    }
                }
            }
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
            //Debug.WriteLine("DirectoryNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

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
            //Debug.WriteLine("FileNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            return rarcEntries;
        }

        private  List<RARCEntry> ReadRARCEntries(BinaryReader br,short folderDirectoryCount)
        {
            //FileNodeSection
            List<RARCEntry> rarcEntries = new();
            for (int entryIndex = 0; entryIndex < folderDirectoryCount; entryIndex++)
            {
                rarcEntries.Add(new RARCEntry(br));
                //Debug.WriteLine($"{entryIndex}");
                //Debug.WriteLine(rarcEntries[entryIndex].NameOffset.ToString("X"));
            }
            //BinarySystem.PaddingSkip(br.BaseStream);
            //Debug.WriteLine("FileNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            return rarcEntries;
        }
    }
}
