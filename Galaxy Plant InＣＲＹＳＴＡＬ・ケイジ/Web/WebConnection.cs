using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Buffers;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Web
{
    internal class WebConnection
    {
        /// <summary>
        /// ウェブページにアクセスするためのクライアントクラス
        /// <para>
        /// <see langword="static"/> <see langword="readonly"/> 修飾子がついている理由は<br/>
        /// <see cref="SocketException"/> を防ぐために一度だけ取得します。<br/>
        /// 詳しくは下記を参照。<br/>
        /// <see href="https://learn.microsoft.com/ja-jp/dotnet/api/system.net.http.httpclient?view=net-7.0"/>
        /// </para>
        /// </summary>
        private static HttpClient httpClient = new();

        private static string downloadUrl = "https://raw.githubusercontent.com/SunakazeKun/pyjmap/main/pyjmap/lookup_supermariogalaxy.txt";

        /// <summary>
        /// WebページのBody要素を取得します。
        /// </summary>
        /// <exception cref="HttpRequestException">Httpのリクエストが失敗した場合に発生するエラー</exception>
        /// <param name="url"></param>
        /// <returns></returns>
        internal static async Task<string> FeatchPageData(string url)
        {
            string responseBody = string.Empty;

            try
            {
                using HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClient = new HttpClient(httpClientHandler);
                responseBody = await httpClient.GetStringAsync(downloadUrl);
                
            }
            catch (HttpRequestException httpRequestException)
            {
                MessageBox.Show(httpRequestException.Message);
            }

            return responseBody;

        }
    }
}
