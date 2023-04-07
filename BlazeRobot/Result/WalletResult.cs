using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Result
{
    public partial class WalletResult : BaseResult
    {
        public List<CarteiraModel> Carteiras { get; set; }

        public class CarteiraModel
        {
            public long Id { get; set; }
            public bool Primary { get; set; }
            public string Balance { get; set; }
            public string BonusBalance { get; set; }
            public string RealBalance { get; set; }
            public string CurrencyType { get; set; }
            public Currency DepositCurrency { get; set; }
            public Currency Currency { get; set; }
        }

    }


    public partial class Currency
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public bool? Fiat { get; set; }
    }
}
