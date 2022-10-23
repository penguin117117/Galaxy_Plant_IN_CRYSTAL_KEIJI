using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCSectionSystem
{
    internal class FileDataSection
    {
        internal FileDataSection() 
        {
        
        }

        internal void Read(BinaryReader br, DirectoryNodeSection directoryNodeSection, StringTableSection stringTableSection) 
        {
            //FileDataSection
            foreach (DirectoryNode directoryNode in directoryNodeSection.DirectoryNodes)
            {
                foreach (DirectoryItem rarcEntry in directoryNode.DirectoryItems)
                {
                    //ファイル制御またはディレクトリの情報のどちらかを制御します。
                    if ((rarcEntry.EntryType & RARCEntryType.File) == RARCEntryType.File)
                    {
                        //ファイルデータの取得

                        long originPos = br.BaseStream.Position;

                        long fileEndPos = originPos + rarcEntry.Argments.Item2;

                        int padding = (int)BinarySystem.GetPaddingReaderCount(fileEndPos);

                        byte[] fileBinaryData = br.ReadBytes((int)rarcEntry.Argments.Item2+padding);
                        //BinarySystem.PaddingSkip(br.BaseStream);

                        //ファイル名の取得
                        string fileName = stringTableSection.ReadNullEnd(rarcEntry.NameOffset);

                        //ディレクトリのファイル一覧に追加
                        directoryNode.IncludeFileNameBinaryPairs.Add((fileName, (uint)rarcEntry.ID), fileBinaryData);
                    }
                    else if ((rarcEntry.EntryType & RARCEntryType.Directory) == RARCEntryType.Directory)
                    {
                        //ディレクトリの名前を取得します。
                        string directoryName = stringTableSection.ReadNullEnd(rarcEntry.NameOffset);


                        //名前が「.」の場合は現在のディレクトリの情報を取得
                        //名前が「..」の場合は親ディレクトリの情報を取得
                        //それ以外の場合は、現在のディレクトリのサブフォルダの情報を取得
                        if (directoryName == ".")
                        {
                            directoryNode.CurrentDirectoryName = stringTableSection.ReadNullEnd(directoryNode.DirectoryNameOffset);
                        }
                        else if (directoryName == "..")
                        {
                            //親ディレクトリがルートディレクトリのケース
                            if (rarcEntry.Argments.Item1 == 0xFFFFFFFF)
                            {
                                directoryNode.ParentDirectoryName = "ROOT";
                                continue;
                            }
                            directoryNode.ParentDirectoryName = stringTableSection.ReadNullEnd(rarcEntry.NameOffset);
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
    }
}
