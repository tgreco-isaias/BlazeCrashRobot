using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Result
{
    public class RoundEnterResult : BaseResult
    {
        public RoundEnterResultModel Model { get; set; }

        public class RoundEnterResultModel
        {
            public string Id { get; set; }
            public object CashedOutAt { get; set; }
            public string Amount { get; set; }
            public string CurrencyType { get; set; }
            public string AutoCashoutAt { get; set; }
            public UserModel User { get; set; }
            public object WinAmount { get; set; }
            public string Status { get; set; }
        }

        public class UserModel
        {
            public long Id { get; set; }
            public string IdStr { get; set; }
            public string Username { get; set; }
            public string Rank { get; set; }
        }
    }
}
