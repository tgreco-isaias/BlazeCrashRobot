using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazeRobot.Result
{
    public class HistoryResult : BaseResult
    {
        public HistoryModel History { get; set; }

        public partial class HistoryModel
        {
            public long TotalPages { get; set; }
            public List<Record> Records { get; set; }
        }

        public partial class Record
        {
            public string Id { get; set; }
            public decimal CrashPoint { get; set; }

            public DateTime CreatedAt { get; set; }
        }

    }
}
