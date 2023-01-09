using System;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Web;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSVFileFormat
{
    internal class BCSVHash
    {
        private static string downloadUrl = "https://raw.githubusercontent.com/SunakazeKun/pyjmap/main/pyjmap/lookup_supermariogalaxy.txt";

        public readonly static string HashTableFilePath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, "lookup_supermariogalaxy.txt");

        internal static void ReadResourcesHashDictionary() 
        {
            
        }

        /// <summary>
        /// <see href="targetURL"/>で指定したURLからハッシュデータリストを取得します。
        /// </summary>
        /// <param name="targetURL">ハッシュ情報が記載されたWebサイトのURL</param>
        internal static async void FeatchHashCollectionFromWebSite()
        {
            string featchBodyString = await WebConnection.FeatchPageData(downloadUrl);

            //テスト機能として対象のギャラクシープロジェクトのStageDataなどと同じディレクトリに保存する。
            File.WriteAllText(HashTableFilePath, featchBodyString, Encoding.UTF8);

            bool foundHash = false;
            Properties.Settings.Default.BCSVHashToTextDictionary = new Dictionary<uint, string>();
            var hashes = File.ReadAllLines(HashTableFilePath, Encoding.UTF8);
            foreach (string hashName in hashes) 
            {

                if (hashName == "### General names") 
                {
                    foundHash= true;
                    //continue;
                }

                if (!foundHash) continue;

                Properties.Settings.Default.BCSVHashToTextDictionary.Add(ConvertFromText(hashName),hashName);
            }
            Properties.Settings.Default.Save();

            //MessageBox.Show("BCSVHashの取得に成功");

            //テスト機能として対象のギャラクシープロジェクトのStageDataなどと同じディレクトリに保存する。
            File.WriteAllText(HashTableFilePath, featchBodyString, Encoding.UTF8);
        }

        /// <summary>
        /// <see href="targetURL"/>で指定したURLからハッシュデータリストを取得します。
        /// </summary>
        /// <param name="targetURL">ハッシュ情報が記載されたWebサイトのURL</param>
        internal static async void FeatchHashCollectionFromWebSite(string targetURL) 
        {
            string featchBodyString = await WebConnection.FeatchPageData(targetURL);

            //テスト機能として対象のギャラクシープロジェクトのStageDataなどと同じディレクトリに保存する。
            File.WriteAllText(HashTableFilePath,featchBodyString,Encoding.UTF8);
        }

        /// <summary>
        /// <see cref="string"/>型のテキストからハッシュ値を取得します。
        /// <para>計算方法は下記を参照</para>
        /// <para><see href="https://kuribo64.net/wiki/?page=BCSV#The_fields"/></para>
        /// </summary>
        /// <param name="convertTargetText"></param>
        /// <returns><see cref="uint"/> Hash</returns>
        public static uint ConvertFromText(string convertTargetText)
        {
            uint ret = 0;
            foreach (char ch in convertTargetText)
            {
                ret *= 0x1F;
                ret += ch;
            }
            return ret;
        }
    }
}
