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
    internal class UsersRequest : BaseRequest
    {
        public UsersRequest(BaseRequest baseRequest) : base(baseRequest) { }

        // /users/me
        public GetCurrentUserResult GetCurrentUser()
        {
            var result = new GetCurrentUserResult();

            HttpWebResponse response;

            if (Request_Users_Me(out response))
            {
                var json = ReadResponse(response);
                response.Close();

                result.CurrentUser = JsonConvert.DeserializeObject<GetCurrentUserResult.CurrentUserModel>(json);
                result.ProcessOK = true;
            }
            else
            {
                result.MsgErro = "Ocorreu um erro em Request_Users_Me";
            }

            return result;
        }

        private bool Request_Users_Me(out HttpWebResponse response)
        {
            response = null;

            try
            {
                //USAR URL BASE ao invés da url completa
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_urlBase + $"/users/me");

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
