using System;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV
{
    internal class BCSVHash
    {
        internal static void ReadResourcesHashDictionary() 
        {
            
        }

        internal static async Task FeatchHashDictionary(string url)
        {
            string hashTableFilePath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, "lookup_supermariogalaxy.txt");

            string downloadUrl = "https://github.com/SunakazeKun/pyjmap/blob/main/pyjmap/lookup_supermariogalaxy.txt";

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.DownloadFile(downloadUrl, hashTableFilePath);
                }
                catch
                {
                    // do nothing
                }
            }


        }

        //https://kuribo64.net/wiki/?page=BCSV#The_fields
        /// <summary>
        /// <see cref="string"/>型のテキストからハッシュ値を取得します。
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
