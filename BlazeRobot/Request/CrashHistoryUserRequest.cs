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
    internal class CrashHistoryUserRequest : BaseRequest
    {
        public CrashHistoryUserRequest(BaseRequest baseRequest) : base(baseRequest) { }

        // /users/me
        public CrashBetsResult GetHistory(int page)
        {
            var result = new CrashBetsResult();

            HttpWebResponse response;

            if (Request_History(out response, page))
            {
                var json = ReadResponse(response);
                response.Close();

                var jsonDynamic = JsonConvert.DeserializeObject<dynamic>(json);

                result.History = new CrashBetsResult.HistoryModel()
                {
                    TotalPages = int.Parse(jsonDynamic.total_pages.ToString()),
                    Records = new List<CrashBetsResult.Record>()
                };

                var cultureInfo = new CultureInfo("en-US") { NumberFormat = new NumberFormatInfo() { NumberDecimalSeparator = "." } };

                foreach (var item in jsonDynamic.records)
                {
                    result.History.Records.Add(new CrashBetsResult.Record()
                    {
                        CurrencyType = item.currency_type.ToString(),
                        Amount = decimal.Parse(item.amount.ToString(), cultureInfo),
                        WinAmount = decimal.Parse(item.win_amount.ToString(), cultureInfo),
                        Multiplier = decimal.Parse(item.multiplier.ToString(), cultureInfo),
                        Profit = decimal.Parse(item.profit.ToString(), cultureInfo),
                        Status = item.status.ToString(),
                        GameCrashPoint = decimal.Parse(item.game_crash_point.ToString(), cultureInfo),
                        //CreatedAt = DateTime.ParseExact(item.created_at.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                        //BetPlacedAt = DateTime.ParseExact(item.created_at.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                        //BetSettledAt = DateTime.ParseExact(item.created_at.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                        //GameStartedAt = DateTime.ParseExact(item.created_at.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                        //GameSettledAt = DateTime.ParseExact(item.created_at.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                        AutoCashoutAt = decimal.Parse(item.auto_cashout_at.ToString(), cultureInfo),
                        CashedOutAt = null,
                        CrashPoint = decimal.Parse(item.crash_point.ToString(), cultureInfo),
                        RoundId = item.round_id.ToString(),
                        GameId = item.game_id.ToString(),
                    }) ;
                }

                result.ProcessOK = true;
            }
            else
            {
                result.MsgErro = "Ocorreu um erro em Request_History";
            }

            return result;
        }

        private bool Request_History(out HttpWebResponse response, int page)
        {
            response = null;

            try
            {
                //USAR URL BASE ao invés da url completa
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_urlBase + $"/crash_bets?page={page}");

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
