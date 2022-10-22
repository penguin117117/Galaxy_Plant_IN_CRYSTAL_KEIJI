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
            if (br.BaseStream is null) 
            {
                throw new NullReferenceException(nameof(br.BaseStream));
            }

            if (br.BaseStream.CanRead == false) 
            {
                throw new ArgumentException(
                    "このストリームは読み取りが出来ないかストリームが終了しています。"
                    );
            }
            
            //ヘッダーの読み込み
            RARCHeader = new(br);
            RARCEntryHeader = new(br);

            //各セクションの情報を読み込みます。
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
            foreach (DirectoryNode directoryNode in DirectoryNodes) 
            {
                directoryNode.RARCEntries = ReadRARCEntries(br, directoryNode.FolderDirectoryCount);
            }
            BinarySystem.PaddingSkip(br.BaseStream);

            //String Table
            stringDataTablePosition = br.BaseStream.Position;
            br.ReadBytes(RARCEntryHeader.StringTableLength);

            //FileDataSection
            foreach (DirectoryNode directoryNode in DirectoryNodes)
            {
                foreach (RARCEntry rarcEntry in directoryNode.RARCEntries)
                {
                    //ファイル制御またはディレクトリの情報のどちらかを制御します。
                    if ((rarcEntry.EntryType & RARCEntryType.File) == RARCEntryType.File)
                    {
                        //ファイルデータの取得
                        byte[] fileBinaryData = br.ReadBytes((int)rarcEntry.Argments.Item2);
                        BinarySystem.PaddingSkip(br.BaseStream);

                        //ファイル名の取得
                        string fileName = BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.NameOffset);

                        //ディレクトリのファイル一覧に追加
                        directoryNode.IncludeFileNameBinaryPairs.Add((fileName,(uint)rarcEntry.ID), fileBinaryData);
                    }
                    else if ((rarcEntry.EntryType & RARCEntryType.Directory) == RARCEntryType.Directory)
                    {
                        //ディレクトリの名前を取得します。
                        string directoryName = 
                            BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.NameOffset);

                        //名前が「.」の場合は現在のディレクトリの情報を取得
                        //名前が「..」の場合は親ディレクトリの情報を取得
                        //それ以外の場合は、現在のディレクトリのサブフォルダの情報を取得
                        if (directoryName == ".")
                        {
                            directoryNode.CurrentDirectoryName = 
                                BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + directoryNode.DirectoryNameOffset);
                        }
                        else if (directoryName == "..")
                        {
                            //親ディレクトリがルートディレクトリのケース
                            if (rarcEntry.Argments.Item1 == 0xFFFFFFFF)
                            {
                                directoryNode.ParentDirectoryName = "ROOT";
                                continue;
                            }
                            directoryNode.ParentDirectoryName = 
                                BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.NameOffset);
                        }
                        else
                        {
                            directoryNode.SubDirectories.Add(directoryName);
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

            return directoryNodes;
        }

        private  List<RARCEntry> ReadRARCEntries(BinaryReader br,short folderDirectoryCount)
        {
            //FileNodeSection
            List<RARCEntry> rarcEntries = new();
            for (int entryIndex = 0; entryIndex < folderDirectoryCount; entryIndex++)
            {
                rarcEntries.Add(new RARCEntry(br));
            }

            return rarcEntries;
        }
    }
}
