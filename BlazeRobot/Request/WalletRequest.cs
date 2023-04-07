using BlazeRobot.Result;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Request
{
    internal class WalletRequest : BaseRequest
    {
        public WalletRequest(BaseRequest baseRequest) : base(baseRequest) { }

        // /wallets
        public WalletResult GetWallet()
        {
            var result = new WalletResult();

            try
            {
                HttpWebResponse response;

                if (Request_Wallet(out response))
                {
                    var json = ReadResponse(response);
                    response.Close();

                    result.Carteiras = JsonConvert.DeserializeObject<List<WalletResult.CarteiraModel>>(json);
                    result.ProcessOK = true;
                    return result;
                }
                else
                {
                    result.MsgErro = "Ocorreu um erro em Request_Wallet";
                }
            }
            catch(Exception ex)
            {
                result.Exception = ex;
                result.MsgErro = ex.Message;
            }

            return result;
        }

        private bool Request_Wallet(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_urlBase + $"/wallets");

                request.KeepAlive = true;
                request.Headers.Set(HttpRequestHeader.Pragma, "no-cache");
                request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
                request.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + _sessionToken);
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";
                request.Accept = "application/json, text/plain, */*";
                request.Headers.Add("X-Client-Language", @"pt");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "pt-PT,pt;q=0.9,en-US;q=0.8,en;q=0.7");

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
}
