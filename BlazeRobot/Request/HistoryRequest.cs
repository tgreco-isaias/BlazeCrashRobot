using BlazeRobot.Result;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Request
{
    internal class HistoryRequest : BaseRequest
    {
        public HistoryRequest(BaseRequest baseRequest) : base(baseRequest) { }

        // /users/me
        public HistoryResult GetHistory(DateTime dataInicio, DateTime dataFim, int page)
        {
            var result = new HistoryResult();

            HttpWebResponse response;

            if (Request_History(out response, dataInicio, dataFim, page))
            {
                var json = ReadResponse(response);
                response.Close();

                var jsonDynamic = JsonConvert.DeserializeObject<dynamic>(json);

                result.History = new HistoryResult.HistoryModel()
                {
                    TotalPages = int.Parse(jsonDynamic.total_pages.ToString()),
                    Records = new List<HistoryResult.Record>()
                };



                foreach (var item in jsonDynamic.records)
                {
                    result.History.Records.Add(new HistoryResult.Record()
                    {
                        Id = item.id.ToString(),
                        CrashPoint = Decimal.Parse(item.crash_point.ToString(), new CultureInfo("en-US") { NumberFormat = new NumberFormatInfo() { NumberDecimalSeparator = "." } }),
                        //CreatedAt = DateTime.ParseExact(item.created_at.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                    });
                }

                result.ProcessOK = true;
            }
            else
            {
                result.MsgErro = "Ocorreu um erro em Request_Users_Me";
            }

            return result;
        }

        private bool Request_History(out HttpWebResponse response, DateTime dataInicio, DateTime dataFim, int page)
        {
            response = null;

            try
            {
                //USAR URL BASE ao invés da url completa
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_urlBase + $"/crash_games/history?startDate={dataInicio.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}&endDate={dataFim.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}&page={page}");

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
