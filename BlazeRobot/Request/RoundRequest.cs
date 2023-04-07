using BlazeRobot.Result;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Request
{
    internal class RoundRequest : BaseRequest
    {
        public RoundRequest(BaseRequest baseRequest) : base(baseRequest) { }

        // /users/me
        public RoundEnterResult Enter(RoundRequestModel aposta)
        {
            var result = new RoundEnterResult();

            try
            {
                HttpWebResponse response;

                if (Request_Enter(out response, aposta))
                {
                    var json = ReadResponse(response);
                    response.Close();

                    result.Model = JsonConvert.DeserializeObject<RoundEnterResult.RoundEnterResultModel>(json);

                    result.ProcessOK = true;
                    return result;
                }
                else
                {
                    result.MsgErro = "Ocorreu um erro em Request_Wallet";
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.MsgErro = ex.Message;
            }

            return result;
        }

        private bool Request_Enter(out HttpWebResponse response, RoundRequestModel aposta)
        {
            response = null;

            try
            {
                //USAR URL BASE ao invés da url completa
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_urlBase + $"/crash/round/enter");

                request.KeepAlive = true;
                request.Headers.Add("sec-ch-ua", @"""Google Chrome"";v=""111"", ""Not(A:Brand"";v=""8"", ""Chromium"";v=""111""");
                request.Headers.Add("X-Client-Version", @"5a7a30ab6");
                request.Headers.Add("sec-ch-ua-mobile", @"?0");
                request.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + _sessionToken);
                //request.Headers.Set(HttpRequestHeader.Authorization, "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MTg5NTcyMDcsImJsb2NrcyI6W10sImlhdCI6MTY3OTEwMTAxNCwiZXhwIjoxNjg0Mjg1MDE0fQ.bMOm1Uq818F6461YbCX2e4_lMiHPoR7ErdI8-2GnULo");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";
                request.ContentType = "application/json;charset=UTF-8";
                request.Accept = "application/json, text/plain, */*";
                request.Headers.Add("X-Client-Language", @"pt");
                request.Headers.Add("sec-ch-ua-platform", @"""Windows""");
                request.Headers.Add("Origin", @"https://blaze.com");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Sec-Fetch-Dest", @"empty");
                request.Referer = "https://blaze.com/pt/games/crash";
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "pt-PT,pt;q=0.9,en-US;q=0.8,en;q=0.7");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                //Sempre usar sessão
                request.CookieContainer = _session;

                NumberFormatInfo numberFormat = new NumberFormatInfo();
                numberFormat.NumberDecimalSeparator = ".";

                var data = new
                {
                    amount = aposta.Amount.ToString("0.00", numberFormat),
                    type = "BRL",
                    auto_cashout_at = aposta.AutoCashoutAt == null ? (object)null : aposta.AutoCashoutAt?.ToString("0.00", numberFormat),
                    wallet_id = aposta.WalletId
                };

                string json = JsonConvert.SerializeObject(data);

                byte[] postBytes = Encoding.UTF8.GetBytes(json);
                request.ContentLength = postBytes.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();


                //Sempre usar sessão
                request.CookieContainer = _session;

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return false;
            }

            return true;
        }
    }

    public partial class RoundRequestModel
    {
        public double Amount { get; set; }
        public string Type { get; set; }
        public double? AutoCashoutAt { get; set; }
        public long WalletId { get; set; }
    }
}
