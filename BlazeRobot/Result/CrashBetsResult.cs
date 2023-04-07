using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Result
{
    public class CrashBetsResult : BaseResult
    {
        public HistoryModel History { get; set; }

        public class HistoryModel
        {
            [JsonProperty("total_pages")]
            public int TotalPages { get; set; }

            [JsonProperty("records")]
            public List<Record> Records { get; set; }

        }

        public class Record
        {
            public string CurrencyType { get; set; }
            public decimal Amount { get; set; }
            public decimal WinAmount { get; set; }
            public decimal Multiplier { get; set; }
            public decimal Profit { get; set; }
            public string Status { get; set; }
            public decimal GameCrashPoint { get; set; }
            public DateTimeOffset? CreatedAt { get; set; }
            public DateTimeOffset? BetPlacedAt { get; set; }
            public DateTimeOffset? BetSettledAt { get; set; }
            public DateTimeOffset? GameStartedAt { get; set; }
            public DateTimeOffset? GameSettledAt { get; set; }
            public decimal AutoCashoutAt { get; set; }
            public object CashedOutAt { get; set; }
            public decimal CrashPoint { get; set; }
            public string RoundId { get; set; }
            public string GameId { get; set; }
        }
    }
}
