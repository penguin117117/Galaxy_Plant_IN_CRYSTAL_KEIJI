using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCDirectoryEdit;
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
        /// <summary>
        /// ディレクトリ情報からRARCファイルを作成します。
        /// <para><paramref name="sourceDirectoryPath"/>で指定したディレクトリからRARCファイルを作成して</para>
        /// <para><paramref name="destinationDirectoryPath"/>で指定されたディレクトリに保存します。</para>
        /// </summary>
        /// <param name="sourceDirectoryPath">アーカイブ化したいディレクトリのパス</param>
        /// <param name="destinationDirectoryPath">保存先のディレクトリパス</param>
        public static void CreateFromDirectory(string sourceDirectoryPath, string destinationDirectoryPath) 
        {
        
        }

        /// <summary>
        /// RARCファイルを指定したディレクトリに展開します。
        /// </summary>
        /// <param name="sourceArchiveFileName"></param>
        /// <param name="destinationDirectoryName"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName) 
        {
            if (!File.Exists(sourceArchiveFileName)) 
            {
                throw new FileNotFoundException($"このRARCファイルは存在しません\n{sourceArchiveFileName}");
            }

            using FileStream fs = new(sourceArchiveFileName, FileMode.Open);
            ExtractToDirectoryFromStream(fs, destinationDirectoryName);
        }

        /// <summary>
        /// RARCファイル形式のバイナリファイルを指定したディレクトリに展開します。
        /// </summary>
        /// <param name="sourceArchiveBinaries">読み込むバイナリデータ</param>
        /// <param name="destinationDirectoryName">解凍後のファイルを保存するディレクトリ</param>
        /// <exception cref="NullReferenceException"><paramref name="sourceArchiveBinaries"/>がNullでした。</exception>
        public static void ExtractToDirectory(byte[]? sourceArchiveBinaries, string destinationDirectoryName)
        {
            sourceArchiveBinaries = 
                sourceArchiveBinaries ?? throw new NullReferenceException($"{nameof(sourceArchiveBinaries)}がNullでした。");

            using MemoryStream ms = new(sourceArchiveBinaries);
            ExtractToDirectoryFromStream(ms, destinationDirectoryName);
        }

        private static void ExtractToDirectoryFromStream(Stream stream ,string destinationDirectoryName) 
        {
            using BinaryReader br = new(stream);
            RARCArchive rarcArchive = new();
            rarcArchive.Read(br);
            RARCArchiveExtract.ToDictionary(rarcArchive,destinationDirectoryName);
        }

        public static RARCArchive Open(string arciveFileName) 
        {
            throw new NotImplementedException();
        }

        public static RARCArchive? OpenRead(string arciveFileName) 
        {
            using FileStream fs = new(arciveFileName, FileMode.Open);
            using BinaryReader br = new(fs);

            try
            {
                RARCArchive rarcArchive = new();
                rarcArchive.Read(br);
                return rarcArchive;
            }
            catch (DataMisalignedException dataMisalignedException) 
            {
                MessageBox.Show(dataMisalignedException.Message);
                return null;
            }
            
        }

        public static RARCArchive OpenRead(byte[] arciveBinaries)
        {
            using MemoryStream ms = new(arciveBinaries);
            using BinaryReader br = new(ms);
            RARCArchive rarcArchive = new();
            rarcArchive.Read(br);
            return rarcArchive;
        }
    }
}
